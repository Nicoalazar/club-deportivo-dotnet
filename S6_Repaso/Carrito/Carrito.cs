using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S6_Repaso.Carrito
{
    internal class Carrito
    {
        private int id;
        private string dni;
        private List<Producto> items;

        public Carrito(string dni, int it)
        {
            setId(id);
            setDni(dni);
            items = new List<Producto>();
        }

        private void setId(int id)
        {
            this.id = id;
        }

        private void setDni(string dni)
        {
            this.dni = dni;
        }

        private Producto buscarProducto(string nombre)
        {
            Producto productoABuscar = null;
            int i = 0;

            while (i < items.Count && productoABuscar == null)
            {
                if (items[i].mismoNombre(nombre))
                {
                    productoABuscar = items[i];
                }
                else
                {
                    i++;
                }
            }
            return productoABuscar;
        }

        public void agregarProducto(int id, string nombre, double precioUnitario, int cantidad)
        {
            Producto item = buscarProducto(nombre);
            if (item != null)
            {
                item.sumarCantidad(cantidad);
            }
            else
            {
                items.Add(new Producto(id, nombre, precioUnitario, cantidad));
            }
        }

        private double obtenerTotal()
        {
            double total = 0;
            foreach (Producto producto in items)
            {
                total += producto.getSubtotal();
            }
            return total;
        }

        public void finalizarCompra()
        {
            foreach (Producto producto in items)
            {
                Console.WriteLine(producto);
            }
            Console.WriteLine("Venta: " + id);
            Console.WriteLine("Dni: " + dni);
            Console.WriteLine("El total a abonar es : $" + obtenerTotal());
        }

        public List<Producto> getItems()
        {
            return items;
        }
    }
}
