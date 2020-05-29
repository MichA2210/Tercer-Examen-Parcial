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
                MessageBox.Show("Por Favor, escriba un matricula", "Error");
            }

            if (Nombre.Text.Length <= 0)//si algo esta escrito, no procede
            {
                flag++;
                MessageBox.Show("Por Favor, escriba un nombre", "Error");
            }
            if (Apellido.Text.Length <= 0)
            {
                flag++;
                MessageBox.Show("Por Favor, escriba un apellido", "Error");
            }
            string nomComp = (Nombre.Text + Apellido.Text);
            foreach(char value in nomComp)
            {
                if (char.IsDigit(value))
                {
                    flag++;
                    MessageBox.Show("Por Favor, solo escriba letras en el nombre y apellido", "Error");
                    break;
                }
            }
            
            if (Carrera.Text.Length <= 0)
            {
                flag++;
                MessageBox.Show("Por Favor, escriba un carrera", "Error");
            }
            foreach (char value in Carrera.Text)
            {
                if (char.IsDigit(value))
                {
                    flag++;
                    MessageBox.Show("Por Favor, solo escriba letras en la carrera", "Error");
                    break;
                }
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
                    MessageBox.Show("Alumno registrado exitosamente!", "Exito");

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
            try
            {
                int indiceAl = AlumnosExistentes.SelectedIndex;
                string _Matricula = AlumnosExistentes.SelectedItem.ToString().Split(new char[] { ' ' })[0];
                var _Alumno = CassandraConection.execQuery("select matricula, nombre, apellido, genero, materias, fecha_nacimiento, carrera from alumnos where matricula = " + _Matricula);
                foreach (Alumno a in _Alumno)
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
                        if (Genero.Items[i].ToString() == a.Genero)
                        {
                            targetIndex = i;
                            break;
                        }
                    }
                    Genero.SelectedIndex = targetIndex;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Seleccione adecuadamente un elemento de la lista", "Exception");
            }
        }

        private void Materias_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int indice = Materias.SelectedIndex;
                Materias.Items.RemoveAt(indice);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Seleccione adecuadamente un elemento de la lista", "Exception");
            }
        }

        private void Modificar_Click(object sender, EventArgs e)
        {
            if (Matricula.Text.Length <= 0)
            {
                flag++;
                MessageBox.Show("Por Favor, escriba un matricula", "Error");
            }

            if (Nombre.Text.Length <= 0)//si algo esta escrito, no procede
            {
                flag++;
                MessageBox.Show("Por Favor, escriba un nombre", "Error");
            }
            if (Apellido.Text.Length <= 0)
            {
                flag++;
                MessageBox.Show("Por Favor, escriba un apellido", "Error");
            }
            string nomComp = (Nombre.Text + Apellido.Text);
            foreach (char value in nomComp)
            {
                if (char.IsDigit(value))
                {
                    flag++;
                    MessageBox.Show("Por Favor, solo escriba letras en el nombre y apellido", "Error");
                    break;
                }
            }

            if (Carrera.Text.Length <= 0)
            {
                flag++;
                MessageBox.Show("Por Favor, escriba un carrera", "Error");
            }
            foreach (char value in Carrera.Text)
            {
                if (char.IsDigit(value))
                {
                    flag++;
                    MessageBox.Show("Por Favor, solo escriba letras en la carrera", "Error");
                    break;
                }
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
                    MessageBox.Show("Alumno modificado exitosamente!", "Exito");

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



        private void eliminarTodosLosNombresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlumnosExistentes.Items.Clear();
            var ListaAlumnos = CassandraConection.execQuery("select matricula, nombre, apellido, genero, materias, fecha_nacimiento, carrera from alumnos");
            foreach (Alumno a in ListaAlumnos)
            {
                a.Nombre = null;
                CassandraConection.AltaAlumno(a);
                AlumnosExistentes.Items.Add(a.Matricula + " " + a.Nombre + " " + a.Apellido);
            }
            Nombre.Text = "";
            MessageBox.Show("Los nombres de todo los alumnos han sido eliminados", "Atención");
        }

        private void eliminarTodosLosApellidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlumnosExistentes.Items.Clear();
            var ListaAlumnos = CassandraConection.execQuery("select matricula, nombre, apellido, genero, materias, fecha_nacimiento, carrera from alumnos");
            foreach (Alumno a in ListaAlumnos)
            {
                a.Apellido = null;
                CassandraConection.AltaAlumno(a);
                AlumnosExistentes.Items.Add(a.Matricula + " " + a.Nombre + " " + a.Apellido);
            }

            Apellido.Text = "";
            MessageBox.Show("Los apellidos de todo los alumnos han sido eliminados", "Atención");
        }

        private void eliminarTodosLosGenerosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlumnosExistentes.Items.Clear();
            var ListaAlumnos = CassandraConection.execQuery("select matricula, nombre, apellido, genero, materias, fecha_nacimiento, carrera from alumnos");
            foreach (Alumno a in ListaAlumnos)
            {
                a.Genero = null;
                CassandraConection.AltaAlumno(a);
                AlumnosExistentes.Items.Add(a.Matricula + " " + a.Nombre + " " + a.Apellido);
            }
            Genero.Text = "";
            MessageBox.Show("Los generos de todo los alumnos han sido eliminados", "Atención");
        }

        private void eliminarTodosLasCarrerasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlumnosExistentes.Items.Clear();
            var ListaAlumnos = CassandraConection.execQuery("select matricula, nombre, apellido, genero, materias, fecha_nacimiento, carrera from alumnos");
            foreach (Alumno a in ListaAlumnos)
            {
                a.Carrera = null;
                CassandraConection.AltaAlumno(a);
                AlumnosExistentes.Items.Add(a.Matricula + " " + a.Nombre + " " + a.Apellido);
            }
            Carrera.Text = "";
            MessageBox.Show("Las carreras de todo los alumnos han sido eliminados", "Atención");
        }

        private void eliminarTodosLasFechasDeNacimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlumnosExistentes.Items.Clear();
            
            var ListaAlumnos = CassandraConection.execQuery("select matricula, nombre, apellido, genero, materias, fecha_nacimiento, carrera from alumnos");

            foreach (Alumno a in ListaAlumnos)
            {
                //a.FechaNacimiento = dto;
                //a.FechaNacimiento = null;
                CassandraConection.ExecNonQuery(string.Format("delete fecha_nacimiento from keyspace1.alumnos WHERE matricula = {0}", a.Matricula.ToString()));
               
                AlumnosExistentes.Items.Add(a.Matricula + " " + a.Nombre + " " + a.Apellido);
            }
            dateTimePicker1.Value = dateTimePicker1.MinDate;
            MessageBox.Show("Las fechas de naciemieto de todo los alumnos han sido eliminadas", "Atención");
        }

        private void eliminarTodosLosLasMateriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlumnosExistentes.Items.Clear();
            var ListaAlumnos = CassandraConection.execQuery("select matricula, nombre, apellido, genero, materias, fecha_nacimiento, carrera from alumnos");
            foreach (Alumno a in ListaAlumnos)
            {
                // a.Materias = null;
                a.Materias = "".Cast<string>();
                CassandraConection.AltaAlumno(a);
                AlumnosExistentes.Items.Add(a.Matricula + " " + a.Nombre + " " + a.Apellido);
            }
            Materias.Items.Clear();
            MessageBox.Show("Las materias de todo los alumnos han sido eliminadas", "Atención");
        }

        private void eliminarATodoElAlumnadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CassandraConection.ExecNonQuery("truncate alumnos");
            Nombre.Text = "";
            Apellido.Text = "";
            Carrera.Text = "";
            Matricula.Text = "";
            Materias.Items.Clear();
            AlumnosExistentes.Items.Clear();
            MessageBox.Show("El alumnado ha sido eliminado", "Atención");
        }
    }
}