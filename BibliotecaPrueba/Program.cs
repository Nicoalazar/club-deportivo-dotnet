namespace BibliotecaPrueba
{
    public class Program
    {
        public static void Main()
        {
            Biblioteca b = new Biblioteca();
            Console.WriteLine("--------Inicio de Programa-------");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Se comprueban libros y lectores:");
            Console.ReadKey();
            b.ListarLibros();
            Console.WriteLine("----------------------------------");
            Console.ReadKey();
            Console.WriteLine("Se agregan 5 libros y se listan.");
            Console.ReadKey();
            b.AgregarLibro("Cien años de soledad", "García Márquez", "Sudamericana");
            b.AgregarLibro("El Principito", "Saint-Exupéry", "Reynal & Hitchcock");
            b.AgregarLibro("Ficciones", "Borges", "Sur");
            b.AgregarLibro("Rayuela", "Cortázar", "Sudamericana");
            b.AgregarLibro("Pedro Páramo", "Rulfo", "FCE");
            b.ListarLibros();
            Console.WriteLine("----------------------------------");
            Console.ReadKey();
            Console.WriteLine("Se agregan dos lectores, 'Ana Perez' y 'Juan Gomez'");
            b.AltaLector("Ana Perez", "30111222");
            b.AltaLector("Juan Gomez", "28123456");
            Console.WriteLine("----------------------------------");
            Console.ReadKey();
            Console.WriteLine("Ana pide un libro");
            Console.ReadKey();
            Console.WriteLine(b.PrestarLibro("El Principito", "30111222")); // PRESTAMO EXITOSO
            Console.WriteLine("----------------------------------");
            Console.ReadKey();
            Console.WriteLine("Juan pide el mismo libro que Ana");
            Console.ReadKey();
            Console.WriteLine(b.PrestarLibro("El Principito", "28123456")); // LIBRO INEXISTENTE
            Console.WriteLine("----------------------------------");
            Console.ReadKey();
            Console.WriteLine("Juan pide otro libro");
            Console.ReadKey();
            Console.WriteLine(b.PrestarLibro("Ficciones", "28123456"));
            Console.WriteLine("----------------------------------");
            Console.ReadKey();
            Console.WriteLine("Una persona no registrada pide un libro");
            Console.ReadKey();
            Console.WriteLine(b.PrestarLibro("Ficciones", "99999999"));     // LECTOR INEXISTENTE
            Console.WriteLine("----------------------------------");
            Console.ReadKey();
            Console.WriteLine("Ana pide 2 libros mas");
            Console.ReadKey();
            Console.WriteLine(b.PrestarLibro("Cien años de soledad", "30111222")); // OK // PRESTAMO EXITOSO
            Console.WriteLine(b.PrestarLibro("Rayuela", "30111222")); // OK (3er préstamo) // // PRESTAMO EXITOSO
            Console.WriteLine("----------------------------------");
            Console.ReadKey();
            b.ListarLibros();
            Console.WriteLine("----------------------------------");
            Console.ReadKey();
            Console.WriteLine("Ana intenta pedir un cuarto libro");
            Console.ReadKey();
            Console.WriteLine(b.PrestarLibro("Pedro Páramo", "30111222")); // TOPE DE PRESTAMO ALCAZADO
            Console.WriteLine("--------------------------------");
            Console.ReadKey();
            b.ListarLibros();
            Console.WriteLine("---------Fin de Programa--------");

        }
    }
}