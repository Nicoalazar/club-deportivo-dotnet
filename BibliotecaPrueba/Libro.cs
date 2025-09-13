using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaPrueba
{
    public class Libro
    {
        public string Titulo;
        private string Autor;
        private string Editorial;

        public Libro(string titulo, string autor, string editorial)
        {
            this.Titulo = titulo;
            this.Autor = autor;
            this.Editorial = editorial;
        }
        public string GetTitulo() { return Titulo; } 

        public override string ToString()
        {
            return $"Título: {Titulo}, Autor: {Autor}, Editorial: {Editorial}";
        }
    }
}
