using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Parcial_1
{
    internal class Reportes
    {
        string alumno;
        string taller;
        DateTime fecha;

        public string Alumno { get => alumno; set => alumno = value; }
        public string Taller { get => taller; set => taller = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
    }
}
