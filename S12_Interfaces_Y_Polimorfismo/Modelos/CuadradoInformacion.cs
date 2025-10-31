using S12_Interfaces_Y_Polimorfismo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S12_Interfaces_Y_Polimorfismo.Modelos
{
    public class CuadradoInformacion : Cuadrado, IInformacionFigura
    {
        public CuadradoInformacion(double lado) : base(lado) { }

        public void ObtenerInformacion()
        {
            Console.WriteLine($"Cuadrado con lado = {lado} m - Área = {CalcularArea()} m²");
        }
    }
}
