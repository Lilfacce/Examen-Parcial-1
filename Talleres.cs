using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Parcial_1
{
    internal class Talleres
    {
        int codigo;
        string nombre;
        decimal costo;

        public int Codigo { get => codigo; set => codigo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public decimal Costo { get => costo; set => costo = value; }
    }
}
