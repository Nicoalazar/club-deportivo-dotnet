using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S6_Repaso.Tren
{
    internal class Ferroviaria
    {
        private const int LARGO_MAXIMO = 30;

        private int ultimoNro;
        private List<Tren> trenes;

        public Ferroviaria()
        {
            ultimoNro = 0;
            trenes = new List<Tren>();
        }

        private Tren buscarTren(int nroTren)
        {
            Tren buscado = null;
            int index = 0;
            while (index < trenes.Count && buscado == null)
            {
                if (trenes[index].getNroTren() == nroTren)
                {
                    buscado = trenes[index];
                }
                index++;
            }
            return buscado;
        }

        public int crearFormacion()
        {
            int nroTren = ++ultimoNro;
            trenes.Add(new Tren(nroTren));
            return nroTren;
        }

        public string agregarVagones(int nroTren, int cantNuevosVagones, string resultado)
        {
            resultado = "CANT_VAGONES_INVALIDA";
            if (cantNuevosVagones > 0 && cantNuevosVagones <= LARGO_MAXIMO)
            {
                Tren tren = buscarTren(nroTren);
                if (tren == null)
                {
                    resultado = "NO_EXISTE_TREN";
                }
                else if (tren.cantidadVagones() + cantNuevosVagones <= LARGO_MAXIMO)
                {
                    tren.agregarVagones(cantNuevosVagones, resultado);
                    resultado = "AGREGADO_OK";
                }
            }
            return resultado;
        }

        public bool cargarTren(int nroTren, double cantidadCarga)
        {
            bool pudoCargar = false;
            if (cantidadCarga > 0)
            {
                Tren tren = buscarTren(nroTren);
                if (tren != null && tren.capacidadLibre() >= cantidadCarga)
                {
                    tren.cargarVagones(cantidadCarga);
                    pudoCargar = true;
                }
            }
            return pudoCargar;
        }

        public int sacarVagonesVacios(int nroTren)
        {
            int vagonesEliminados = -1;
            Tren tren = buscarTren(nroTren);
            if (tren != null)
            {
                vagonesEliminados = tren.eliminarVagonesVacios();
            }
            return vagonesEliminados;
        }

        public void listarCapacidadDisponible()
        {
            if (trenes.Count > 0)
            {
                Console.WriteLine("Capacidad Disponible en Cada Tren:");
                foreach (Tren tren in trenes)
                {
                    double porcentaje = 100.0 * tren.capacidadLibre() / tren.capacidadTotal();
                    Console.WriteLine("Tren: " + tren.getNroTren()
                            + "  Espacio Libre: " + String.Format("%.2f", porcentaje) + "%");
                }
            }
            else
            {
                Console.WriteLine("No hay trenes cargados.");
            }
        }
    }
}
