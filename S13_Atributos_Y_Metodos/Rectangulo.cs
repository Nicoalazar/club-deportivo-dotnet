using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S13_Atributos_Y_Metodos
{
    public class Rectangulo
    {
        public static double Base { get; set; }
        public static double Altura { get; set; }

        public static double CalcularArea()
        {
            return Base * Altura;
        }

        public static double CalcularPerimetro()
        {
            return 2 * (Base + Altura);
        }
    }
}
