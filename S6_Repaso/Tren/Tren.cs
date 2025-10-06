using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S6_Repaso.Tren
{
    internal class Tren
    {
        private int nroTren;
        private List<Vagon> vagones;

        public Tren(int nroTren)
        {
            this.nroTren = nroTren;
            vagones = new List<Vagon>();
        }

        public void agregarVagones(int cantidad, string tipo)
        {
            for (int i = 0; i < cantidad; i++)
            {
                vagones.Add(new Vagon(tipo));
            }
        }

        public int eliminarVagonesVacios()
        {
            int eliminados = 0;
            int index = 0;
            while (index < vagones.Count)
            {
                if (vagones[index].estaVacio())
                {
                    vagones.Remove(vagones[index]);
                    eliminados++;
                }
                else
                {
                    index++;
                }
            }
            return eliminados;
        }

        public int getNroTren()
        {
            return nroTren;
        }

        public int cantidadVagones()
        {
            return vagones.Count;
        }

        public double cargarVagones(double cantidadCarga)
        {
            int index = 0;
            while (index < vagones.Count && cantidadCarga > 0)
            {
                Vagon vagon = vagones[index];
                if (!vagon.estaLleno())
                {
                    cantidadCarga = vagon.cargarVagon(cantidadCarga);
                }
                index++;
            }
            return cantidadCarga;
        }

        public double capacidadTotal()
        {
            double capacidadTotal = 0;
            foreach (Vagon vagon in vagones)
            {
                capacidadTotal += vagon.capacidadVagon();
            }
            return capacidadTotal;
        }

        public double capacidadLibre()
        {
            double capacidadLibre = 0;
            foreach (Vagon vagon in vagones)
            {
                capacidadLibre += vagon.capacidadLibre();
            }
            return capacidadLibre;
        }

    }
}
