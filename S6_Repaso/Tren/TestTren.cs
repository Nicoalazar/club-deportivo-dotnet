using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S6_Repaso.Tren
{
    internal class TestTren
    {
        static Ferroviaria emp;
        public static void Ejecutar()
        {

            emp = new Ferroviaria();

            int tren1 = crearFormacion();
            int tren2 = crearFormacion();

            Console.WriteLine();
            agregarVagones(tren1, 5, "MEDIUM");
            agregarVagones(tren1, 7, "LARGE");
            agregarVagones(tren2, 20, "SMALL");
            agregarVagones(tren2, 20, "MEDIUM");
            agregarVagones(999, 20, "LARGE");

            Console.WriteLine();
            cargarTren(tren1, 165);
            cargarTren(tren1, 200);
            cargarTren(tren2, 240);
            cargarTren(tren2, 1000);
            cargarTren(999, 10);

            Console.WriteLine();
            emp.listarCapacidadDisponible();

            Console.WriteLine();
            sacarVagones(tren1);
            sacarVagones(tren1);
            sacarVagones(999);

        }

        private static int crearFormacion()
        {
            String metodo = "crearFormacion()";
            int tren = emp.crearFormacion();
            Console.WriteLine(metodo + " -> " + tren);
            return tren;
        }

        private static void agregarVagones(int tren, int cantidad, string tipo)
        {
            String metodo = "agregarVagones(" + tren + ", " + cantidad + ", " + tipo + ")";
            Console.WriteLine(metodo + " -> " + emp.agregarVagones(tren, cantidad, tipo));
        }

        private static void cargarTren(int tren, double carga)
        {
            String metodo = "cargarTren(" + tren + ", " + carga + ")";
            Console.WriteLine(metodo + " -> " + emp.cargarTren(tren, carga));
        }

        private static void sacarVagones(int tren)
        {
            String metodo = "sacarVagonesVacios(" + tren + ")";
            Console.WriteLine(metodo + " -> " + emp.sacarVagonesVacios(tren));
        }
    }
}
