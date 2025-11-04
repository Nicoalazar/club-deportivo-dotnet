using S12_Interfaces_Y_Polimorfismo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S12_Interfaces_Y_Polimorfismo.Modelos
{
    public class Cuadrado : IAreaCalculable
    {
        protected double lado;

        public Cuadrado(double lado)
        {
            this.lado = lado;
        }

        public double CalcularArea()
        {
            return lado * lado;
        }
    }
}
