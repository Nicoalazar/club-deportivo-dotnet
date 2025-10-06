using S6_Repaso.Carrito;
using S6_Repaso.Tren;

namespace S6_Repaso
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string opcion = "";

            while (opcion != "0")
            {
                Console.WriteLine("====================================");
                Console.WriteLine(" Ejercitación de Repaso ");
                Console.WriteLine("====================================");
                Console.WriteLine("1) Carrito de Compras");
                Console.WriteLine("2) Tren");
                Console.WriteLine("0) Salir");
                Console.Write("Elegí una opción: ");
                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Ejercicio1();
                        break;
                    case "2":
                        Ejercicio2();
                        break;
                    default:
                        Console.WriteLine("Opción inválida.");
                        continue;
                }
            }
        }
        static void Ejercicio1()
        {
            TestCarrito.Ejecutar();
        }
        static void Ejercicio2()
        {
            TestTren.Ejecutar();
        }
    }
}