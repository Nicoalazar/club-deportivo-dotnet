using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10_Polimorfismo
{
    internal class Refrigerados: Paquete
    {
        public double temperatura;
        public Refrigerados(double pesoKg, double dimensionesM2, string direccion, double temperatura)
            : base(pesoKg, dimensionesM2, direccion)
        {
            this.temperatura = temperatura;
        }
        public override double CalcularCostoDeEnvio()
        {
            double costoBase = pesoKg * 10;
            if (temperatura <= 10)
                return costoBase * 3; // +200% = triple
            else
                return costoBase * 1.5; // +50%
        }

        public override void MostrarInformacionDetallada()
        {
            Console.WriteLine("Paquete Refrigerado");
            base.MostrarInformacionDetallada();
            Console.WriteLine($"Temperatura: {temperatura}°C");
            Console.WriteLine($"Costo de envío: ${CalcularCostoDeEnvio():F2}\n");
        }
    }
}
