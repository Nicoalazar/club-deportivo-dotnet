using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S4_Abstraer_Y_Encapsular
{
    public class Empresa
    {
        private string nombre;
        private Empleado empleadoPrincipal;

        public string Nombre { get => nombre; set => nombre = value; }

        public Empleado EmpleadoPrincipal { get => empleadoPrincipal; set => empleadoPrincipal = value; }

        // Constructor
        public Empresa(string nombre, Empleado empleado)
        {
            this.nombre = nombre;
            this.empleadoPrincipal = empleado;
        }

        // Método para mostrar información del empleado principal
        public void MostrarEmpleadoPrincipal()
        {
            Console.WriteLine($"Empresa: {Nombre}");
            empleadoPrincipal.MostrarInformacion();
        }
    }
}
