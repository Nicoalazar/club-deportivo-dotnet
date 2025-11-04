using S12_Interfaces_Y_Polimorfismo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S12_Interfaces_Y_Polimorfismo.Modelos
{
    public class Circulo : IAreaCalculable, IInformacionFigura
    {
        private double radio;

        public Circulo(double radio)
        {
            this.radio = radio;
        }

        public double CalcularArea()
        {
            return Math.PI * Math.Pow(radio, 2);
        }

        public void ObtenerInformacion()
        {
            Console.WriteLine($"Círculo con radio = {radio} m - Área = {CalcularArea():F2} m²");
        }
    }

}
