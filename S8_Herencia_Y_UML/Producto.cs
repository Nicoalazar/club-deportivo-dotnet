using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S8_Herencia_Y_UML
{
    public class Producto
    {
        protected string nombre;
        protected double precio;
        protected string tipo;

        public Producto(string nombre, double precio, string tipo)
        {
            this.nombre = nombre;
            this.precio = precio;
            this.tipo = tipo;
        }
        public string Nombre
        {
            get => nombre;
            set => nombre = value;
        }

        public double Precio
        {
            get => precio;
            set => precio = value;
        }

        public string Tipo
        {
            get => tipo;
            set => tipo = value;
        }

        public virtual void MostrarDatos()
        {
            Console.WriteLine($"Producto: {nombre} | Precio: ${precio} | Tipo: {tipo}");
        }

        public virtual double CalcularPrecioTotal(int cantidad)
        {
            return precio * cantidad;
        }
    }
}
