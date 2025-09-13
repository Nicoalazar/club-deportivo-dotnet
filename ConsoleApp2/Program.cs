using ConsoleApp2;

public class Test
{
    public static void Main()
    {
        // Ejemplo del enunciado
        SuperHeroe superHeroe1 = new SuperHeroe("Batman", 90, 70, 0);
        SuperHeroe superHeroe2 = new SuperHeroe("Superman", 95, 60, 70);

        Console.WriteLine("Batman vs Superman: " + superHeroe1.Competir(superHeroe2)); // debería ser DERROTA
        Console.WriteLine("Superman vs Batman: " + superHeroe2.Competir(superHeroe1)); // debería ser TRIUNFO

        // Más ejemplos para jugar
        SuperHeroe superHeroe3 = new SuperHeroe("Mujer Maravilla", 85, 85, 60);
        SuperHeroe superHeroe4 = new SuperHeroe("Flash", 70, 60, 80);
        Console.WriteLine(superHeroe3.GetNombre() + " vs " + superHeroe4.GetNombre() + ": " + superHeroe3.Competir(superHeroe4));

        // Probar límites (clamping a 0 y 100)
        SuperHeroe prueba = new SuperHeroe("Prueba", -10, 150, 50);
        Console.WriteLine(prueba.ToString());
    }
}