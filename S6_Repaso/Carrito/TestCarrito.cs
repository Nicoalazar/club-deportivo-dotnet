using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S6_Repaso.Carrito
{
    internal class TestCarrito
    {


        private static Sistema sistema = new Sistema("Vendo todo S.A.");

        private static void mostrarResultadoPrueba(bool resultado)
        {
            if (resultado)
            {
                Console.WriteLine("Prueba exitosa!");
            }
            else
            {
                Console.WriteLine("XXX OJO Prueba fallida XXX");
            }
        }
        private static void evaluarResultadoEsperado(bool resultado, bool resultadoEsperado)
        {
            Console.WriteLine("Resultado obtenido: " + resultado + " resultado esperado: " + resultadoEsperado);
            mostrarResultadoPrueba(resultado == resultadoEsperado);
        }

        private static void evaluarResultadoEsperado(string resultado, string resultadoEsperado)
        {
            Console.WriteLine("Resultado obtenido: " + resultado + " resultado esperado: " + resultadoEsperado);
            mostrarResultadoPrueba(resultado == resultadoEsperado);
        }

        private static void probarRegistrarProducto(string nombre, double precioUnitario, int stockInicial, bool resultadoEsperado)
        {
            Console.WriteLine("Probando registrar nombre: " + nombre + " precioUnitario: " + precioUnitario + " stockInicial: " + stockInicial);
            evaluarResultadoEsperado(sistema.registrarProducto(nombre, precioUnitario, stockInicial), resultadoEsperado);
        }

        private static void probarIniciarCompra(string dni, bool resultadoEsperado)
        {
            Console.WriteLine("Probando iniciar compra con dni: " + dni);
            evaluarResultadoEsperado(sistema.iniciarCompra(dni), resultadoEsperado);
        }

        private static void probarAgregarProductoCarrito(string nombre, int cantidad, string resultadoEsperado)
        {
            Console.WriteLine("Probando agregar producto al carrito nombre: " + nombre + " cantidad: " + cantidad);
            evaluarResultadoEsperado(sistema.agregarProductoCarrito(nombre, cantidad), resultadoEsperado);
        }

        private static void probarFinalizarCompra(bool resultadoEsperado)
        {
            Console.WriteLine("Probando finalizar compra");
            evaluarResultadoEsperado(sistema.finalizarCompra(), resultadoEsperado);
        }

        private static void probarDescartarCompra(bool resultadoEsperado)
        {
            Console.WriteLine("Probando descartar compra");
            evaluarResultadoEsperado(sistema.descartarCompra(), resultadoEsperado);
        }

        public static void Ejecutar()
        {
            probarRegistrarProducto("TV", 10000, 2, true);
            probarRegistrarProducto("TV", 10000, 2, false);
            probarRegistrarProducto("Radio", 6000, -1, false);
            probarRegistrarProducto("Radio", 6000, 1, true);

            probarAgregarProductoCarrito("TV", 1, "COMPRA_NO_INICIADA");

            probarIniciarCompra("26666666", true);
            probarIniciarCompra("26666667", false);

            probarAgregarProductoCarrito("TV", 10, "NO_HAY_STOCK");
            probarAgregarProductoCarrito("Bicicleta", 1, "PRODUCTO_INVALIDO");

            probarAgregarProductoCarrito("TV", 1, "AGREGAR_OK");
            probarAgregarProductoCarrito("Radio", 1, "AGREGAR_OK");
            probarAgregarProductoCarrito("Radio", 1, "NO_HAY_STOCK");

            probarFinalizarCompra(true);
            probarFinalizarCompra(false);

            probarIniciarCompra("26666667", true);
            probarAgregarProductoCarrito("Radio", 1, "NO_HAY_STOCK");
            probarAgregarProductoCarrito("TV", 1, "AGREGAR_OK");

            probarDescartarCompra(true);
            probarDescartarCompra(false);

            probarIniciarCompra("26666667", true);
            probarAgregarProductoCarrito("TV", 1, "AGREGAR_OK");
            probarFinalizarCompra(true);
        }
    }
}
