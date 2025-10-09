namespace BibliotecaPrueba
{
    public class Lector
    {
        private string Nombre;
        public string Dni;
        public List<Libro> librosPrestados;
        private int LIMITE_LIBROS = 3;

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

        public bool PuedeTomarPrestamo() => librosPrestados.Count < LIMITE_LIBROS;
        public void TomarPrestamo(Libro libro)
        {
            if (PuedeTomarPrestamo() && libro != null )
            {
                librosPrestados.Add(libro);
            }
            else Console.WriteLine("Tope de préstamos alcanzado");
        }

        public void MostrarListado(Lector lector)
        {
            Console.WriteLine(lector.ToString());

            foreach (Libro libros in librosPrestados)
            {
                Console.WriteLine($"- {libros}");
            }
        }

        public override string ToString()
           => $"{Nombre} (DNI {Dni}) - Préstamos vigentes: {librosPrestados.Count}";

    }
}