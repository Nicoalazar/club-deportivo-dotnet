using BibliotecaPrueba;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaPrueba
{
    internal class Biblioteca
    {
        private List<Libro> libros;
        private List<Lector> lectores;

        public Biblioteca()
        {
            libros = new List<Libro>();
            lectores = new List<Lector>();
        }

        public Libro BuscarLibro(string titulo)
        {
            foreach (Libro libro in libros)
            {
                if (libro.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase))
                {
                    return libro;
                }
            }
            return null; 
        }

        public bool AgregarLibro(string titulo, string autor, string editorial)
        {
            if (BuscarLibro(titulo) != null)
            {
                return false;
            }

            libros.Add(new Libro(titulo, autor, editorial));
            return true;
        }

        public bool EliminarLibro(string titulo)
        {
            Libro libro = BuscarLibro(titulo);
            if (libro != null)
            {
                libros.Remove(libro);
                return true;
            }
            return false;
        }

        public void ListarLibros()
        {
            if (libros.Count == 0)
            {
                Console.WriteLine("La biblioteca está vacía.");
            }
            else
            {
                Console.WriteLine("Libros en la biblioteca:");
                foreach (Libro libro in libros)
                {
                    Console.WriteLine(libro);
                }
            }
        }

        private Lector BuscarLectorPorDni(string dni)
        {
            foreach (var lector in lectores)
            {
                if (lector.getDni().Equals(dni))
                {
                    return lector;
                }
            }
            return null;
        }
        public bool AltaLector(string nombre, string dni)
        {
            Lector lectorExistente = BuscarLectorPorDni(dni);

            if (lectorExistente == null)
            {
                Lector nuevoLector = new Lector(nombre, dni);
                lectores.Add(nuevoLector);
                return true;
            }
            else return false;
        }
        public string PrestarLibro(string titulo, string dni)
        {
            // 1) validar lector

            Lector lector = BuscarLectorPorDni(dni);
            if (lector == null) return "LECTOR INEXISTENTE";

            // 2) validar libro disponible en biblioteca
            Libro libro = BuscarLibro(titulo);
            if (libro == null) return "LIBRO INEXISTENTE";

            // 3) validar tope de préstamos
            if (!lector.PuedeTomarPrestamo()) return "TOPE DE PRESTAMO ALCAZADO";

            // 4) efectuar el préstamo: quitar de biblioteca y agregar a lector
            libros.Remove(libro);
            lector.TomarPrestamo(libro);

            return "PRESTAMO EXITOSO";
        }

    }
}