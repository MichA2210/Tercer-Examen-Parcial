using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoCSharp_actividad3_WindowsForms
{
    class Alumno
    {
        public uint Matricula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Genero { get; set; }
        public IEnumerable<string> Materias { get; set; }
        public DateTimeOffset FechaNacimiento { get; set; }
        public string Carrera { get; set; }
    }
}
