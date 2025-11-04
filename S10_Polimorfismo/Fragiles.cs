using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10_Polimorfismo
{
    internal class Fragiles: Paquete
    {
        public Fragiles(double pesoKg, double dimensionesM2, string destino)
            : base(pesoKg, dimensionesM2, destino)
        {
        }
        public override double CalcularCostoDeEnvio()
        {
            // 100% de recargo = doble del precio regular
            return pesoKg * 10 * 2;
        }
        public override void MostrarInformacionDetallada()
        {
            Console.WriteLine("Paquete Frágil");
            base.MostrarInformacionDetallada();
            Console.WriteLine($"Costo de envío: ${CalcularCostoDeEnvio():F2}\n");
        }
    }
}
