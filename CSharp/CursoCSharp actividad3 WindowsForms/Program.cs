using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CursoCSharp_actividad3_WindowsForms
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            MessageBox.Show("Vienvenido al proyecto de AAVD con ejemplos de registros de alumnos. \n \n" +
                "Llene todos los campos dependiendo de su etiqueta.\n" +
                "Para agregar una materia escribala debajo de su lista correspondiente y agregue con el botón '+'. \n" +
                "Para seleccionar un alumno, de doble click sobre este. \n" +
                "Agregue con el botón Agregar, elimine con el botón Eliminar y modifique con el botón Modificar. \n" +
                "El menú 'Eliminación Masiva' eliminara un atributo a elegir de todos los alumnos (exceptuando la matrícula). " +
                "O a todos los alumnos, si así lo desea. \n \n" +
                "Creado por Miguel Angel Aguilar Gzz, Id: 1795657",
                "Instrucciones"); //Solo aceptan texto o variables tipo texto, no numericos.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
