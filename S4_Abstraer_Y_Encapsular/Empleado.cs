using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S4_Abstraer_Y_Encapsular
{
    public class Empleado
    {
        private string nombre;
        private int edad;
        private string cargo;
        public string Nombre { get => nombre; set => nombre = value; }
        public int Edad { get => edad; set => edad = value; }
        public string Cargo { get => cargo; set => cargo = value; }

        // Constructor
        public Empleado(string nombre, int edad, string cargo)
        {
            this.Nombre = nombre;
            this.Edad = edad;
            this.Cargo = cargo;
        }


        public void MostrarInformacion()
        {
            Console.WriteLine($"{Nombre} - {Edad} años - {Cargo}");
        }
    }

}
