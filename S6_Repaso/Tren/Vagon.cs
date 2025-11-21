using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S6_Repaso.Tren
{
    internal class Vagon
    {
        private string tipo;
        private double carga;

        public Vagon(string tipo)
        {
            this.tipo = tipo;
            this.carga = 0;
        }

        public double capacidadVagon()
        {
            double capacidad = 0;
            switch (tipo)
            {
                case "SMALL":
                    capacidad = 30;
                    break;
                case "MEDIUM":
                    capacidad = 40;
                    break;
                case "LARGE":
                    capacidad = 50;
                    break;
            }
            return capacidad;
        }

        public double capacidadLibre()
        {
            return capacidadVagon() - carga;
        }

        public double cargarVagon(double cantidad)
        {
            double espacioLibre = capacidadVagon() - carga;
            double aCargar = Math.Min(cantidad, espacioLibre);
            carga += aCargar;
            return cantidad - aCargar;
        }

        public bool estaVacio()
        {
            return carga == 0;
        }

        public bool estaLleno()
        {
            return carga == capacidadVagon();
        }
    }
}
