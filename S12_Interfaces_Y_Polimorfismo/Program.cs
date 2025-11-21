using S12_Interfaces_Y_Polimorfismo.Modelos;
using S12_Interfaces_Y_Polimorfismo.Interfaces;

class Program
{
    static void ImprimirInformacionFigura(IInformacionFigura figura)
    {
        figura.ObtenerInformacion();
    }

    static void Main()
    {
        // Ejercicio 5: Lista polimórfica
        List<IAreaCalculable> figuras = new List<IAreaCalculable>
            {
                new Cuadrado(2),
                new CuadradoInformacion(4),
                new Circulo(3)
            };

        Console.WriteLine("=== Áreas calculadas mediante polimorfismo ===");
        foreach (var f in figuras)
        {
            Console.WriteLine($"Área: {f.CalcularArea():F2} m²");
        }

        Console.WriteLine("\n=== Información detallada ===");
        // Ejercicio 7: Usando función genérica
        ImprimirInformacionFigura(new CuadradoInformacion(5));
        ImprimirInformacionFigura(new Circulo(2.5));

        Console.WriteLine("\nPráctica completada correctamente.");
    }
}