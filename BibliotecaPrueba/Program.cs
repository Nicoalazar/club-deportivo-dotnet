using BibliotecaPrueba;

public class Program
{
    public static void Main()
    {
        Biblioteca b = new Biblioteca();
        b.AgregarLibro("Cien años de soledad", "García Márquez", "Sudamericana");
        b.AgregarLibro("El Principito", "Saint-Exupéry", "Reynal & Hitchcock");
        b.AgregarLibro("Ficciones", "Borges", "Sur");
        b.AgregarLibro("Rayuela", "Cortázar", "Sudamericana");
        b.AgregarLibro("Pedro Páramo", "Rulfo", "FCE");

        b.AltaLector("Ana Pérez", "30111222");
        b.AltaLector("Juan Gómez", "28123456");

        Console.WriteLine(b.PrestarLibro("El Principito", "30111222")); // PRESTAMO EXITOSO
        Console.WriteLine(b.PrestarLibro("El Principito", "28123456")); // LIBRO INEXISTENTE
        Console.WriteLine(b.PrestarLibro("Ficciones", "99999999"));     // LECTOR INEXISTENTE

        // Llevar a Ana al tope
        Console.WriteLine(b.PrestarLibro("Cien años de soledad", "30111222")); // OK // PRESTAMO EXITOSO
        Console.WriteLine(b.PrestarLibro("Rayuela", "30111222")); // OK (3er préstamo) // // PRESTAMO EXITOSO
        Console.WriteLine(b.PrestarLibro("Pedro Páramo", "30111222")); // TOPE DE PRESTAMO ALCAZADO
    
}
}