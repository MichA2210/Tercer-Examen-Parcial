using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace CursoCSharp_actividad3_WindowsForms
{
    public partial class Form1 : Form
    {

        public int flag = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //Application.Exit(); //Esto cierra la aplicación, la pongo aqui porque no tengo boton cerrar.

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Genero.Items.Add("Masculino"); Genero.Items.Add("Femenino"); //Así es por codigo, yo lo hice directamente.
            var ListaAlumnos = CassandraConection.execQuery("select matricula, nombre, apellido, genero, materias, fecha_nacimiento, carrera from alumnos");
            foreach (Alumno a in ListaAlumnos)
            {
                AlumnosExistentes.Items.Add(a.Matricula + " " + a.Nombre + " " + a.Apellido);
            }
        }

        private void Agregar_Click(object sender, EventArgs e)
        {
            #region Testing y Cursos
            //string nombre=Nombre.Text; //Así pasamos lo escrito a una variable
            //string matricula = Matricula.Text;
            //string carrera = Carrera.Text;
            ////label1.Text = nombre; //Así modificamos el Static en el programa.

            //Alumno aux = new Alumno();
            //aux.Nombre = Nombre.Text;

            #endregion

            if (CassandraConection.MatriculaExiste(uint.Parse(Matricula.Text)) == true)
            {
                MessageBox.Show("Un alumno con esta matricula ya existe", "Error");
                flag++;
            }

            if (Matricula.Text.Length <= 0)
            {
                flag++;
                MessageBox.Show("Por Favor, escriba un matricula");
            }
            if (Nombre.Text.Length <= 0)//si algo esta escrito, no procede
            {
                flag++;
                MessageBox.Show("Por Favor, escriba un nombre");
            }
            if (Apellido.Text.Length <= 0)
            {
                flag++;
                MessageBox.Show("Por Favor, escriba un apellido");
            }
            if (Carrera.Text.Length <= 0)
            {
                flag++;
                MessageBox.Show("Por Favor, escriba un carrera");
            }

            if (flag ==0)
            {
                try
                {
                    Alumno alumno = new Alumno();

                    alumno.Matricula = uint.Parse(Matricula.Text);
                    alumno.Nombre = Nombre.Text;
                    alumno.Apellido = Apellido.Text;
                    int indice = Genero.SelectedIndex;
                    string genero = Genero.Items[indice].ToString();
                    alumno.Genero = genero;
                    alumno.Materias = Materias.Items.Cast<string>();
                    alumno.FechaNacimiento = dateTimePicker1.Value;
                    alumno.Carrera = Carrera.Text;

                    CassandraConection.AltaAlumno(alumno);
                    MessageBox.Show("Alumno registrado exitosamente!");

                    Nombre.Text = "";
                    Apellido.Text = "";
                    Carrera.Text = "";
                    Matricula.Text = "";
                    Materias.Items.Clear();

                    AlumnosExistentes.Items.Clear();
                    var ListaAlumnos = CassandraConection.execQuery("select matricula, nombre, apellido, genero, materias, fecha_nacimiento, carrera from alumnos");
                    foreach (Alumno a in ListaAlumnos)
                    {
                        AlumnosExistentes.Items.Add(a.Matricula + " " + a.Nombre + " " + a.Apellido);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception");
                }
            }
            flag = 0;
            
        }

        private void Genero_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region Testing y Cursos
            //int indice = Genero.SelectedIndex;  //Nos da la posición de la opción del ComboBox
            //string genero = Genero.Items[indice].ToString(); //Nos da la opcion seleccionada del ComboBox
            ////label4.Text = indice.ToString();
            ////label4.Text = genero;
            #endregion
        }
        private void btn1_Click(object sender, EventArgs e)
        {
            if (AgregarMateria.Text.Length > 0)
            {
                Materias.Items.Add(AgregarMateria.Text);
                AgregarMateria.Text = "";
            }
        }

        private void AlumnosExistentes_DoubleClick(object sender, EventArgs e)
        {
            int indiceAl = AlumnosExistentes.SelectedIndex;
            string _Matricula = AlumnosExistentes.SelectedItem.ToString().Split(new char[] { ' ' })[0];
            var _Alumno = CassandraConection.execQuery("select matricula, nombre, apellido, genero, materias, fecha_nacimiento, carrera from alumnos where matricula = " + _Matricula);
            foreach(Alumno a in _Alumno)
            {
                Nombre.Text = a.Nombre;
                Apellido.Text = a.Apellido;
                Carrera.Text = a.Carrera;
                Matricula.Text = a.Matricula.ToString();
                dateTimePicker1.Value = a.FechaNacimiento.DateTime;
                Materias.Items.Clear();
                if (a.Materias != null)
                {
                    foreach (string materia in a.Materias)
                    {
                        Materias.Items.Add(materia);
                    }
                }
                int targetIndex = -1;
                for (int i = 0; i < Genero.Items.Count; ++i)
                {
                    if(Genero.Items[i].ToString() == a.Genero)
                    {
                        targetIndex = i;
                        break;
                    }
                }
                Genero.SelectedIndex = targetIndex;
            }
        }

        private void Materias_DoubleClick(object sender, EventArgs e)
        {
            int indice = Materias.SelectedIndex;
            Materias.Items.RemoveAt(indice);
        }

        private void Modificar_Click(object sender, EventArgs e)
        {
            if (Matricula.Text.Length <= 0)
            {
                flag++;
                MessageBox.Show("Por Favor, escriba un matricula");
            }
            if (Nombre.Text.Length <= 0)//si algo esta escrito, no procede
            {
                flag++;
                MessageBox.Show("Por Favor, escriba un nombre");
            }
            if (Apellido.Text.Length <= 0)
            {
                flag++;
                MessageBox.Show("Por Favor, escriba un apellido");
            }
            if (Carrera.Text.Length <= 0)
            {
                flag++;
                MessageBox.Show("Por Favor, escriba un carrera");
            }

            if (flag == 0)
            {
                try
                {
                    Alumno alumno = new Alumno();

                    alumno.Matricula = uint.Parse(Matricula.Text);
                    alumno.Nombre = Nombre.Text;
                    alumno.Apellido = Apellido.Text;
                    int indice = Genero.SelectedIndex;
                    string genero = Genero.Items[indice].ToString();
                    alumno.Genero = genero;
                    alumno.Materias = Materias.Items.Cast<string>();
                    alumno.FechaNacimiento = dateTimePicker1.Value;
                    alumno.Carrera = Carrera.Text;

                    CassandraConection.AltaAlumno(alumno);
                    MessageBox.Show("Alumno modificado exitosamente!");

                    Nombre.Text = "";
                    Apellido.Text = "";
                    Carrera.Text = "";
                    Matricula.Text = "";
                    Materias.Items.Clear();

                    AlumnosExistentes.Items.Clear();
                    var ListaAlumnos = CassandraConection.execQuery("select matricula, nombre, apellido, genero, materias, fecha_nacimiento, carrera from alumnos");
                    foreach (Alumno a in ListaAlumnos)
                    {
                        AlumnosExistentes.Items.Add(a.Matricula + " " + a.Nombre + " " + a.Apellido);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception");
                }
            }
            flag = 0;
        }

        private void Borrar_Click(object sender, EventArgs e)
        {
            int indiceAl = AlumnosExistentes.SelectedIndex;
            string _Matricula = AlumnosExistentes.SelectedItem.ToString().Split(new char[]{' '})[0];
            CassandraConection.DeleteAlumno(uint.Parse(_Matricula));
            AlumnosExistentes.Items.RemoveAt(indiceAl);
        }
    }
}

////No se como funciona, pero tengo que usar esto para poner datos.
//class Alumno
//{
//   public string Nombre { get; set; }
//   public string Matricula { get; set; }
//   public string Carrera { get; set; }
//   public string Genero { get; set; }
//   public DateTime FechaRegistro { get; set; }
//   public string DataColection { get; set; } 
//}