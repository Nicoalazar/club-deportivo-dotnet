
namespace S8_Herencia_Y_UML;

internal class Test
{
    static void Main(string[] args)
    {
        List<Producto> productos = new List<Producto>
            {
                new Perecedero("Leche", 200, 1),
                new Perecedero("Yogurt", 150, 3),
                new Perecedero("Pan", 100, 2),
                new NoPerecedero("Arroz", 300, "Alimentos secos"),
                new NoPerecedero("Detergente", 500, "Limpieza"),
                new Producto("Revista", 250, "General")
            };

        Console.WriteLine("=== Lista de productos ===");
        foreach (var p in productos)
        {
            p.MostrarDatos();
        }

        Console.WriteLine("=== Precio total por vender 5 unidades de cada producto ===");
        foreach (var p in productos)
        {
            double total = p.CalcularPrecioTotal(5);
            Console.WriteLine($"{p.Nombre,-15} | Total: ${total:F2}");
        }
    }
}
