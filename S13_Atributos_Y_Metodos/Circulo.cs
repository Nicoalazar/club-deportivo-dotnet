using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S13_Atributos_Y_Metodos
{
    public class Circulo
    {
        public static double Radio { get; set; }

        public static double CalcularArea()
        {
            return Math.PI * Math.Pow(Radio, 2);
        }

        public static double CalcularPerimetro()
        {
            return 2 * Math.PI * Radio;
        }
    }
}
