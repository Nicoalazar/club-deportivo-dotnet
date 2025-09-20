using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class SuperHeroe
    {
        private string nombre;
        private int fuerza;
        private int resistencia;
        private int superpoderes;

        public SuperHeroe(string nombre, int fuerza, int resistencia, int superpoderes)
        {
            this.nombre = nombre;
            SetFuerza(fuerza);
            SetResistencia(resistencia);
            SetSuperpoderes(superpoderes);
        }
        // Getters
        public string GetNombre() { return nombre; }
        public int GetFuerza() { return fuerza; }
        public int GetResistencia() { return resistencia; }
        public int GetSuperpoderes() { return superpoderes; }

        // Setters
        private void SetFuerza(int valor) { fuerza = AjustarRango(valor); }
        private void SetResistencia(int valor) { resistencia = AjustarRango(valor); }
        private void SetSuperpoderes(int valor) { superpoderes = AjustarRango(valor); }

        //Funcion auxiliar para ajustar los valores al rango 1-100
        private int AjustarRango(int valor)
        {
            if (valor < 0) return 0;
            if (valor > 100) return 100;
            return valor;
        }
        // Metodo de competencia
        public string Competir(SuperHeroe otro)
        {
            int gano = 0;
            int perdio = 0;
            int empato = 0;

            if (this.fuerza > otro.fuerza) gano++;
            else if (this.fuerza < otro.fuerza) perdio++;
            else empato++;

            if (this.resistencia > otro.resistencia) gano++;
            else if (this.resistencia < otro.resistencia) perdio++;
            else empato++;

            if (this.superpoderes > otro.superpoderes) gano++;
            else if (this.superpoderes < otro.superpoderes) perdio++;
            else empato++;

            if (gano > perdio && gano > empato) return "TRIUNFO";
            if (perdio > gano && perdio > empato) return "DERROTA";
            return "EMPATE";
        }
        // Metodo ToString
        public override string ToString()
        {
            return "Nombre: " + nombre
                 + ", Fuerza: " + fuerza
                 + ", Resistencia: " + resistencia
                 + ", Superpoderes: " + superpoderes;
        }
    }
}
