using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S8_Herencia_Y_UML
{
    public class NoPerecedero : Producto
    {
        private string categoria;

        public NoPerecedero(string nombre, double precio, string categoria)
            : base(nombre, precio, "No Perecedero")
        {
            this.categoria = categoria;
        }

        public string Categoria
        {
            get => categoria;
            set => categoria = value;
        }

        public override void MostrarDatos()
        {
            Console.WriteLine($"Producto No Perecedero: {nombre} | Precio: ${precio} | Categoría: {categoria}");
        }
        public override double CalcularPrecioTotal(int cantidad)
        {
            return base.CalcularPrecioTotal(cantidad);
        }
    }
}
