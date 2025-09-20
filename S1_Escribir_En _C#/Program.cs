using System;
using System.Drawing;
using System.Reflection.Emit;

namespace ConsoleApp1
{
    internal class Program
    {
        const double INCREMENTO_GANANCIA = 0.15;
        const int NUMERO_JURADOS = 3;
        const double PUNTAJE_MINIMO_ULTIMA_ETAPA = 80;
        const int NUMERO_DIGITOS = 4;
        static void Main(string[] args)
        {
            string opcion = "";

            while (opcion != "0")
            {
                Console.WriteLine("====================================");
                Console.WriteLine(" PRÁCTICA C# - Estructuras de control");
                Console.WriteLine("====================================");
                Console.WriteLine("1) Precio con 15% de ganancia");
                Console.WriteLine("2) Campeonato: total por participante - 3) Campeonato: clasifica (>80?)");
                Console.WriteLine("4) Suma de dígitos (exacto 4 dígitos)");
                Console.WriteLine("5) Suma de dígitos (cantidad variable)");
                Console.WriteLine("6) Sociedad: porcentajes por socio");
                Console.WriteLine("0) Salir");
                Console.Write("Elegí una opción: ");
                opcion = Console.ReadLine();

                switch(opcion)
                {
                    case "1": Ejercicio1();
                        break;
                    case "2": Ejercicio2y3();
                        break;
                    case "3": Ejercicio2y3();
                        break;
                    case "4": Ejercicio4();
                        break;
                    case "5": Ejercicio5();
                        break;
                    case "6": Ejercicio6();
                        break;
                    case "0":
                        break;
                    default:
                        Console.WriteLine("Opción inválida.");
                        continue;
                }
            }
        }
        //A2: Escribir en C# para comprender distintas estructuras de control.
        static void Ejercicio1()
        {
            /*El precio de los productos no tiene incluido el incremento del 15% que representa la ganancia del negocio, por lo tanto, 
             * el algoritmo debe calcular el precio final a abonar por un cliente. Se ingresa el precio del producto 
             * y como resultado muestra el precio de venta.*/
            Console.WriteLine("Ingrese el precio del producto: ");
            double precioProducto = double.Parse(Console.ReadLine());
            double precioFinal = precioProducto * (1 + INCREMENTO_GANANCIA);
            Console.WriteLine("El precio final del producto es: " + precioFinal);
        }
        static void Ejercicio2y3()
        {
            /*En el campeonato estudiantil llegan a la última etapa los participantes que superen los 80 puntos. 
             * El algoritmo pide el nombre de cada participante y la puntuación de los 3 jurados. 
             * Debe mostrar el nombre y el puntaje total de cada participante.        
             * Nota: cuando se ingrese "FIN" en el nombre del participante finaliza nuestro programa.*/
            string nombreParticipante;
            double puntajeTotal;
            Console.WriteLine("Ingrese el nombre del participante o 'FIN' para terminar: ");
            nombreParticipante = Console.ReadLine().ToUpper();
            while (nombreParticipante != "FIN")
            {
                puntajeTotal = 0;

                for (int i = 1; i <= NUMERO_JURADOS; i++)
                {
                    Console.Write("Ingrese el puntaje del jurado " + i + " para " + nombreParticipante + ": ");
                    puntajeTotal += double.Parse(Console.ReadLine());
                }
                Console.WriteLine("Puntaje total de " + nombreParticipante + ": " + puntajeTotal);

                /*Modifica la salida de la resolución del punto 2. Se pide mostrar un mensaje que indique si cada participante llegó a la última etapa o no.*/
                if (puntajeTotal > PUNTAJE_MINIMO_ULTIMA_ETAPA)
                {
                    Console.WriteLine("Alcanza instacia final con " + puntajeTotal + " puntos");
                }
                else
                {
                    Console.WriteLine("No alcanza instacia final");
                }

                Console.WriteLine("Ingrese el nombre del participante o 'FIN' para terminar: ");
                nombreParticipante = Console.ReadLine().ToUpper();
            }
            Console.WriteLine("Fin del programa.");
        }
        static void Ejercicio4()
        {
            /*Se trata de implementar un programa que sume los dígitos de un número entero no negativo de 4 dígitos. 
             * Por ejemplo, la suma de los dígitos del 3433 es 13.  Para darle un poco más de emoción, 
             * el programa no se limitará a escribir el resultado de la suma, 
             * sino que también escribirá todos los sumandos utilizados: 3 + 4 + 3 + 3 = 13.*/

            string numero;

            Console.WriteLine("Ingrese un número entero no negativo de " + NUMERO_DIGITOS + " dígitos: ");
            numero = Console.ReadLine();
            if (numero.Length == NUMERO_DIGITOS)
            {
                int digito1 = int.Parse(numero[0].ToString());
                int digito2 = int.Parse(numero[1].ToString());
                int digito3 = int.Parse(numero[2].ToString());
                int digito4 = int.Parse(numero[3].ToString());

                int suma = digito1 + digito2 + digito3 + digito4;
                Console.WriteLine(digito1 + "+" + digito2 + "+" + digito3 + "+" + digito4 + "=" + suma);
            }
            else
            {
                Console.WriteLine("El numero " + numero + " no es valido");
            }
        }
        static void Ejercicio5()
        {
            /*Resolver la consiga del punto 4 con la particularidad que el número puede tener cualquier cantidad de dígitos, es decir, 
             * puede ser un número de dos dígitos como un número de 6 dígitos. 
             * Tomá la codificación anterior e introducí los cambios que sean necesarios.*/
            int numero;
            
            Console.Write("Ingrese un número entero: ");
            numero = int.Parse(Console.ReadLine());
            
            int suma = 0;
            if (numero < 0)
            {
                Console.WriteLine("Numero no valido");

            }
            else
            {

                int numeroTemp = numero;
                int digitos = 0;
                while (numeroTemp > 0)
                {
                    numeroTemp /= 10;
                    digitos++;
                }

                int divisor = 1;
                for (int i = 1; i < digitos; i++)
                    divisor = divisor * 10;


                Console.Write("Sumando: ");
                for (int i = 0; i < digitos; i++)
                {
                    int digito = numero / divisor;
                    Console.Write(digito);

                    suma = suma + digito;
                    numero = numero % divisor;
                    divisor = divisor / 10;

                    if (divisor >= 1)
                        Console.Write(" + ");
                }
                Console.WriteLine(" = " + suma);
            }
        }
        static void Ejercicio6()
        {
            /*Tres personas aportan diferente capital a una sociedad y desean saber el valor total aportado 
             * y qué porcentaje aportó cada una(indicando nombre y porcentaje).
             * Para ello, solicitar la carga por teclado del nombre de cada socio, su capital aportado y a partir de esto 
             * calcular e informar lo requerido previamente.*/

            string nombreSocio1, nombreSocio2, nombreSocio3;
            float aporteSocio1, aporteSocio2, aporteSocio3;

            Console.WriteLine("Introduzca el nombre del primer socio: ");
            nombreSocio1 = Console.ReadLine();
            Console.WriteLine("Introduzca el capital aportado:");
            aporteSocio1 = float.Parse(Console.ReadLine());
            Console.WriteLine("Introduzca el nombre del segundo socio: ");
            nombreSocio2 = Console.ReadLine();
            Console.WriteLine("Introduzca el capital aportado:");
            aporteSocio2 = float.Parse(Console.ReadLine());
            Console.WriteLine("Introduzca el nombre del tercer socio: ");
            nombreSocio3 = Console.ReadLine();
            Console.WriteLine("Introduzca el capital aportado:");
            aporteSocio3 = float.Parse(Console.ReadLine());

            float capital = aporteSocio1 + aporteSocio2 + aporteSocio3;
            float porcentajeSocio1 = aporteSocio1 / capital * 100;
            float porcentajeSocio2 = aporteSocio2 / capital * 100;
            float porcentajeSocio3 = aporteSocio3 / capital * 100;
            Console.WriteLine("El capital total aportado es: " + capital);
            Console.WriteLine("El porcentaje aportado por " + nombreSocio1 + " es: " + porcentajeSocio1.ToString("F2") + "%");
            Console.WriteLine("El porcentaje aportado por " + nombreSocio2 + " es: " + porcentajeSocio2.ToString("F2") + "%");
            Console.WriteLine("El porcentaje aportado por " + nombreSocio3 + " es: " + porcentajeSocio3.ToString("F2") + "%");
        }
    }
}