using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10_Polimorfismo
{
    internal class Regulares: Paquete
    {
        public Regulares(double pesoKg, double dimensionesM2, string destino)
            : base(pesoKg, dimensionesM2, destino)
        {
        }
        public override double CalcularCostoDeEnvio()
        {
            return pesoKg * 10; // $10 por kg
        }
        public override void MostrarInformacionDetallada()
        {
            Console.WriteLine("Paquete Regular");
            base.MostrarInformacionDetallada();
            Console.WriteLine($"Costo de envío: ${CalcularCostoDeEnvio():F2}\n");
        }
    }
}
