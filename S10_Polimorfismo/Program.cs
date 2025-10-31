using S10_Polimorfismo;

public static class Program
{
    public static void Main()
    {
        List<Paquete> paquetes = new List<Paquete>
            {
                new Regulares(5, 0.5, "Buenos Aires"),
                new Fragiles(2.5, 0.3, "Córdoba"),
                new Refrigerados(10, 1.2, "San Juan", 8),
                new Refrigerados(8, 1.0, "Salta", 15)
            };

        Console.WriteLine("=== Información detallada de cada paquete ===\n");
        foreach (var p in paquetes)
        {
            p.MostrarInformacionDetallada();
        }

        Console.WriteLine("=== Resumen de costos totales ===");
        double total = 0;
        foreach (var p in paquetes)
            total += p.CalcularCostoDeEnvio();

        Console.WriteLine($"\nCosto total de todos los envíos: ${total:F2}");
    }
}
