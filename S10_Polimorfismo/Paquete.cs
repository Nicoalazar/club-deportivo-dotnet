using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10_Polimorfismo
{
    public abstract class Paquete
    {
        public double pesoKg;
        public double dimensionesM2;
        public string destino;
        public Paquete(double pesoKg, double dimensionesM2, string destino)
        {
            this.pesoKg = pesoKg;
            this.dimensionesM2 = dimensionesM2;
            this.destino = destino;
        }
        // Método abstracto (será implementado por las subclases)
        public abstract double CalcularCostoDeEnvio();

        // Método virtual común para mostrar información
        public virtual void MostrarInformacionDetallada()
        {
            Console.WriteLine($"Destino: {destino}, Peso: {pesoKg} kg, Dimensiones: {dimensionesM2} m²");
        }
    }
}
