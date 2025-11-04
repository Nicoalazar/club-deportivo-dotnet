using S13_Atributos_Y_Metodos;
using System;

namespace CalculadoraGeometrica
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("=== Calculadora Geométrica ===");
            Console.WriteLine("Seleccione una figura:");
            Console.WriteLine("1. Círculo");
            Console.WriteLine("2. Rectángulo");
            Console.Write("Opción: ");
            int opcion = int.Parse(Console.ReadLine() ?? "0");

            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese el radio del círculo: ");
                    Circulo.Radio = double.Parse(Console.ReadLine() ?? "0");
                    Console.WriteLine($"\nÁrea del círculo: {Circulo.CalcularArea():F2}");
                    Console.WriteLine($"Perímetro del círculo: {Circulo.CalcularPerimetro():F2}");
                    break;

                case 2:
                    Console.Write("Ingrese la base del rectángulo: ");
                    Rectangulo.Base = double.Parse(Console.ReadLine() ?? "0");
                    Console.Write("Ingrese la altura del rectángulo: ");
                    Rectangulo.Altura = double.Parse(Console.ReadLine() ?? "0");
                    Console.WriteLine($"\nÁrea del rectángulo: {Rectangulo.CalcularArea():F2}");
                    Console.WriteLine($"Perímetro del rectángulo: {Rectangulo.CalcularPerimetro():F2}");
                    break;

                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

            Console.WriteLine("\n=== Fin del programa ===");
        }
    }
}
