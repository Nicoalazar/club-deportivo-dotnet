using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S8_Herencia_Y_UML
{
    public class Perecedero : Producto
    {
        private int diasACaducar;

        public Perecedero(string nombre, double precio, int diasACaducar)
            : base(nombre, precio, "Perecedero")
        {
            this.diasACaducar = diasACaducar;
        }

        public int DiasACaducar
        {
            get => diasACaducar;
            set => diasACaducar = value;
        }

        public override void MostrarDatos()
        {
            Console.WriteLine($"Producto Perecedero: {nombre} | Precio: ${precio} | Días a caducar: {diasACaducar}");
        }

        public override double CalcularPrecioTotal(int cantidad)
        {
            double total = base.CalcularPrecioTotal(cantidad);

            if (diasACaducar == 1)
                total /= 4;
            else if (diasACaducar == 2)
                total /= 3;
            else if (diasACaducar == 3)
                total /= 2;

            return total;
        }
    }

}
