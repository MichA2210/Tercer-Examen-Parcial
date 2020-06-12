using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cassandra;
using Cassandra.Mapping;
using System.Configuration;

namespace CursoCSharp_actividad3_WindowsForms
{
    public class CassandraConection
    {
        static private string _dbServer { set; get; }
        static private string _dbKeySpace { set; get; }
        static private Cluster _cluster;
        static private ISession _session;

        //public CassandraConection()
        //{
        //     server = ConfigurationManager.ConnectionStrings["CassandraConection"].ToString();  //Conexion local
        //     connectStr = ConfigurationManager.ConnectionStrings["CassandraKeyspace"].ToString(); //nombre de base de datos
        //}

        //public string server;
        //public string connectStr;

        static void Conectar()
        {

            _dbServer = ConfigurationManager.ConnectionStrings["CassandraConection"].ToString();
            _dbKeySpace = ConfigurationManager.ConnectionStrings["CassandraKeyspace"].ToString();

            _cluster = Cluster.Builder()
                .AddContactPoint(_dbServer)
                .Build();

            _session = _cluster.Connect(_dbKeySpace);
        }

        //public static IEnumerable<Alumno> execQuery(string query_body)
        //{
        //    var cluster = Cluster.Builder().AddContactPoint(server).Build();

        //    var session = cluster.Connect(connectStr);

        //    //IMapper mapper = new Mapper(session);
        //    //IEnumerable<Alumno> alumnos = mapper.Fetch<Alumno>(query_body);

        //    RowSet rs = session.Execute(query_body);  //obtención de las tablas en Cassandra

        //    LinkedList<Alumno> alumnos = new LinkedList<Alumno>();  //lista ligada de alumnos

        //    foreach (Row r in rs)
        //    {
        //        Alumno alumno = new Alumno();

        //        alumno.Matricula = (uint)r.GetValue<int>(0);  //Obtencion de la información en las tablas (por indice)
        //        alumno.Nombre = r.GetValue<string>(1);
        //        alumno.Apellido = r.GetValue<string>(2);
        //        alumno.Genero = r.GetValue<string>(3);
        //        alumno.Materias = r.GetValue<IEnumerable<string>>(4);
        //        Nullable<DateTimeOffset> dto = r.GetValue<Nullable<DateTimeOffset>>(5);
        //        if (dto.HasValue)
        //        {
        //            alumno.FechaNacimiento = dto.Value;
        //        }
        //        else
        //        {
        //            alumno.FechaNacimiento = new DateTime(1753, 01, 01);
        //        }
        //        alumno.Carrera = r.GetValue<string>(6);

        //        alumnos.AddLast(alumno);  //Insercion de la informacion de Cassandra en la Lista Ligada
        //    }  //Basicamente un get

        //    return alumnos;
        //}

        public IEnumerable<Alumno> Mapper(string query_body)
        {
            Conectar();
            IMapper mapper = new Mapper(_session);
            IEnumerable<Alumno> alumnos = mapper.Fetch<Alumno>(query_body);

            return alumnos;
        }

        //public static void ExecNonQuery(string query_body) //Insert y get
        //{
        //    var cluster = Cluster.Builder()
        //        .AddContactPoint(server)
        //        .Build();

        //    var session = cluster.Connect(connectStr);

        //    session.Execute(query_body);
        //}

        public void AltaAlumno(Alumno alumno)
        {
            Conectar();

            if (alumno.Materias == null)
                alumno.Materias = "".Cast<string>();
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

            _session.Execute(string.Format("BEGIN BATCH INSERT INTO keyspace1.alumnos (matricula, nombre, apellido, genero, materias, fecha_nacimiento, carrera)"
                + " VALUES({0},'{1}','{2}','{3}',{4},'{5}', '{6}') APPLY BATCH",
                alumno.Matricula, alumno.Nombre, alumno.Apellido, alumno.Genero, materias, date, alumno.Carrera));
        }

        public bool MatriculaExiste(uint matricula)
        {
            Conectar();

            RowSet rs = _session.Execute(string.Format("select matricula from keyspace1.alumnos where matricula = {0}", matricula));

            return rs.GetRows().Count() > 0 ? true : false;
        }
        
        public void DeleteAlumno(uint matricula)
        {
            Conectar();

            _session.Execute(string.Format("delete from keyspace1.alumnos where matricula = {0}", matricula));

        }
        public void DeleteAlumno(Alumno alumno)
        {
            Conectar();

            _session.Execute(string.Format("delete fecha_nacimiento from keyspace1.alumnos WHERE matricula = {0}", alumno.Matricula.ToString()));
        }
        public void DeleteAlumnos()
        {
            Conectar();

            _session.Execute("truncate alumnos");
        }

        public IEnumerable<Alumno> GetAlumnos()
        {
            Conectar();

            RowSet rs = _session.Execute("select matricula, nombre, apellido, genero, materias, fecha_nacimiento, carrera from alumnos");  //obtención de las tablas en Cassandra

            LinkedList<Alumno> alumnos = new LinkedList<Alumno>();  

            foreach (Row r in rs)
            {
                Alumno alumno = new Alumno();

                alumno.Matricula = (uint)r.GetValue<int>(0); 
                alumno.Nombre = r.GetValue<string>(1);
                alumno.Apellido = r.GetValue<string>(2);
                alumno.Genero = r.GetValue<string>(3);
                alumno.Materias = r.GetValue<IEnumerable<string>>(4);
                Nullable<DateTimeOffset> dto = r.GetValue<Nullable<DateTimeOffset>>(5);
                if (dto.HasValue)
                {
                    alumno.FechaNacimiento = dto.Value;
                }
                else
                {
                    alumno.FechaNacimiento = new DateTime(1753, 01, 01);
                }
                alumno.Carrera = r.GetValue<string>(6);

                alumnos.AddLast(alumno);  
            }  

            return alumnos;
        }
        public IEnumerable<Alumno> GetAlumnoMatricula(uint _Matricula)
        {
            Conectar();

            RowSet rs = _session.Execute("select matricula, nombre, apellido, genero, materias, fecha_nacimiento, carrera from alumnos where matricula = " + _Matricula);

            LinkedList<Alumno> alumnos = new LinkedList<Alumno>();  

            foreach (Row r in rs)
            {
                Alumno alumno = new Alumno();

                alumno.Matricula = (uint)r.GetValue<int>(0);  
                alumno.Nombre = r.GetValue<string>(1);
                alumno.Apellido = r.GetValue<string>(2);
                alumno.Genero = r.GetValue<string>(3);
                alumno.Materias = r.GetValue<IEnumerable<string>>(4);
                Nullable<DateTimeOffset> dto = r.GetValue<Nullable<DateTimeOffset>>(5);
                if (dto.HasValue)
                {
                    alumno.FechaNacimiento = dto.Value;
                }
                else
                {
                    alumno.FechaNacimiento = new DateTime(1753, 01, 01);
                }
                alumno.Carrera = r.GetValue<string>(6);

                alumnos.AddLast(alumno); 
            } 

            return alumnos;
        }





    }
}
