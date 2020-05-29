using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cassandra;
using Cassandra.Mapping;

namespace CursoCSharp_actividad3_WindowsForms
{
    class CassandraConection
    {
        private static readonly string server = "127.0.0.1";  //Conexion local
        private static readonly string connectStr = "keyspace1"; //nombre de base de datos

        public static IEnumerable<Alumno> execQuery(string query_body)
        {
            var cluster = Cluster.Builder().AddContactPoint(server).Build();

            var session = cluster.Connect(connectStr);

            //IMapper mapper = new Mapper(session);
            //IEnumerable<Alumno> alumnos = mapper.Fetch<Alumno>(query_body);

            RowSet rs = session.Execute(query_body);  //obtención de las tablas en Cassandra

            LinkedList<Alumno> alumnos = new LinkedList<Alumno>();  //lista ligada de alumnos

            foreach (Row r in rs)
            {
                Alumno alumno = new Alumno();

                alumno.Matricula = (uint)r.GetValue<int>(0);  //Obtencion de la información en las tablas (por indice)
                alumno.Nombre = r.GetValue<string>(1);
                alumno.Apellido = r.GetValue<string>(2);
                alumno.Genero = r.GetValue<string>(3);
                alumno.Materias = r.GetValue<IEnumerable<string>>(4);
                alumno.FechaNacimiento = r.GetValue<DateTimeOffset>(5);
                alumno.Carrera = r.GetValue<string>(6);

                alumnos.AddLast(alumno);  //Insercion de la informacion de Cassandra en la Lista Ligada
            }  //Basicamente un get

            return alumnos;
        }

        public static IEnumerable<Alumno> Mapper(string query_body)
        {
            var cluster = Cluster.Builder().AddContactPoint(server).Build();

            var session = cluster.Connect(connectStr);

            IMapper mapper = new Mapper(session);
            IEnumerable<Alumno> alumnos = mapper.Fetch<Alumno>(query_body);

            return alumnos;
        }

        public static void ExecNonQuery(string query_body) //Insert y get
        {
            var cluster = Cluster.Builder()
                .AddContactPoint(server)
                .Build();

            var session = cluster.Connect(connectStr);

            session.Execute(query_body);
        }

        public static void AltaAlumno(Alumno alumno)
        {
            var cluster = Cluster.Builder().AddContactPoint(server).Build();

            using (var session = cluster.Connect(connectStr))
            {
                List<string> mats = alumno.Materias.ToList(); //recuperar materias como lista
                string materias = "[";
                for (int i = 0; i < mats.Count; ++i)
                {
                    materias += "'" + mats[i] + "'";
                    if (i < mats.Count - 1)
                    {
                        materias += ",";
                    }
                }
                materias += "]";  //generar string con todas las materias.


                int day = alumno.FechaNacimiento.DateTime.Day;
                string d = day < 10 ? "0" + day.ToString() : day.ToString();

                int month = alumno.FechaNacimiento.DateTime.Month;
                string m = month < 10 ? "0" + month.ToString() : month.ToString();

                string date = alumno.FechaNacimiento.DateTime.Year.ToString() + "-" + m + "-" + d;
                //date = date.Replace("/", "-");

                session.Execute(string.Format("INSERT INTO keyspace1.alumnos (matricula, nombre, apellido, genero, materias, fecha_nacimiento, carrera)"
                    + " VALUES({0},'{1}','{2}','{3}',{4},'{5}', '{6}')",
                    alumno.Matricula, alumno.Nombre, alumno.Apellido, alumno.Genero, materias, date, alumno.Carrera));
            }
        }

        public static bool MatriculaExiste(uint matricula)
        {
            var cluster = Cluster.Builder()
                .AddContactPoint(server)
                .Build();

            var session = cluster.Connect(connectStr);

            RowSet rs = session.Execute(string.Format("select matricula from keyspace1.alumnos where matricula = {0}", matricula));

            return rs.GetRows().Count() > 0 ? true : false;
        }

        public static void UpdateAlumno(Alumno alumno)
        {
            var cluster = Cluster.Builder().AddContactPoint(server).Build();

            var session = cluster.Connect(connectStr);
        }

        public static void DeleteAlumno(uint matricula)
        {
            var cluster = Cluster.Builder().AddContactPoint(server).Build();

            var session = cluster.Connect(connectStr);

            session.Execute(string.Format("delete from keyspace1.alumnos where matricula = {0}", matricula));

        }
    }
}
