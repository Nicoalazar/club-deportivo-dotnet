using BibliotecaPrueba;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaPrueba
{
    public class Lector
    {
        private string Nombre;
        public string Dni;
        private List<Libro> librosPrestados;

        public Lector(string nombre, string dni)
        {
            this.Nombre = nombre;
            this.Dni = dni;
            this.librosPrestados = new List<Libro>();
        }

        public string getDni()
        {
            return Dni;
        }

        public bool PuedeTomarPrestamo() => librosPrestados.Count < 3;
        public void TomarPrestamo(Libro libro)
        {
            if (PuedeTomarPrestamo() && libro != null )
            {
                librosPrestados.Add(libro);
            }
            else Console.WriteLine("Tope de préstamos alcanzado");
        }

        public override string ToString()
            => $"{Nombre} (DNI {Dni}) - Préstamos vigentes: {librosPrestados.Count}";

    }
}
