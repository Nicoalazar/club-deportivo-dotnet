using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S6_Repaso.Carrito
{
    internal class Producto
    {
        private int id;
        private string nombre;
        private double precioUnitario;
        private int cantidad;

        public Producto(int id, string nombre, double precioUnitario, int cantidad)
        {
            this.id = id;
            this.nombre = nombre;
            this.precioUnitario = precioUnitario;
            this.cantidad = cantidad;
        }


        public int getId()
        {
            return id;
        }

        public string getNombre()
        {
            return nombre;
        }

        public bool mismoNombre(string nombre)
        {
            return this.nombre.Equals(nombre);
        }

        public double getPrecioUnitario()
        {
            return precioUnitario;
        }


        public void sumarStock(int cantidad)
        {
            setCantidad(getCantidad() + cantidad);
        }

        public void restarStock(int cantidad)
        {
            setCantidad(getCantidad() - cantidad);
        }

        public int getCantidad()
        {
            return cantidad;
        }


        public void setCantidad(int cantidad)
        {
            this.cantidad = cantidad;
        }


        public void sumarCantidad(int cantidad)
        {
            setCantidad(this.cantidad + cantidad);
        }


        public override string ToString()
        {
            return "Producto [id=" + id + ", nombre=" + nombre + ", precioUnitario=" + precioUnitario + ", stock=" + cantidad
                    + "]";
        }

        public double getSubtotal()
        {
            return cantidad * precioUnitario;
        }

    }
}
