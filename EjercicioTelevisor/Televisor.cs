using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A2PracticaFormativa
{
    internal class Televisor
    {
        private const int CANALMIN = 1;
        private const int CANALMAX = 150;
        public string Marca { get; }
        public string Modelo { get; }
        public int cantPulgadas { get; }
        public bool estado; //prendido o apagado
        public int canalActual;
        private readonly List<Persona> propietarios;

        public Televisor(
            string marca,
            string modelo,
            int cantPulgadas,
            IEnumerable<Persona> propietarios,
            bool estado = false,
            int canalInicial = CANALMIN)
        {
            this.Marca = marca;
            this.Modelo = modelo;
            this.cantPulgadas = cantPulgadas;
            this.estado = estado;
            this.canalActual = canalInicial;
            this.propietarios = new List<Persona>(propietarios);
        }
        //Lista propietarios
        public IReadOnlyList<Persona> Propietarios => propietarios.AsReadOnly();

        //Comprueba propietarios
        public bool CheckUser()
        {
            foreach(Persona p in Propietarios)
            {
                if(!p.Nombre.Equals("facundo", StringComparison.OrdinalIgnoreCase) &&
                    !p.Nombre.Equals("camila", StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
            }
                return true;
        }

        //Devuelve un valor entero con el número de canal que esta visualizándose en ese momento.
        public int ObtenerCanalActual()
        {
            if (!CheckUser()) return -1;
            return canalActual;

        }

        //Cambia el canal al número de canal que reciba por parámetro
        public bool CambiarCanal(int nuevoCanal)
        {
            if (!CheckUser()) return false;
            if (!estado) return false;
            if (nuevoCanal < CANALMIN || nuevoCanal > CANALMAX) return false;
            this.canalActual = nuevoCanal;
            return true;
        }
        //Cambia el canal incrementando en uno al que se está reproduciendo actualmente.Si llega al tope de 150, debe comenzar por el primero.
        public bool CambiarCanal()
        {
            if (!CheckUser()) return false;
            if (!estado) return false;
            canalActual = (canalActual == CANALMAX) ? CANALMIN : canalActual +=1;            
            return true;
        }
        //Informa con un verdadero si el televisor está encendido o falso en caso contrario
        public bool VerPrendido()
        {
            if (!CheckUser()) return false;
            return estado;
        }

        //Si el televisor se encontraba encendido entonces se debe apagar, y viceversa.
        public void CambiarEstado()
        {
            if (!CheckUser()) return;
            this.estado = !this.estado;
        }
        //To String
        public override string ToString() => $"{Marca} - {Modelo} - {cantPulgadas}' - Encendio: {estado} - Canal Actual: {canalActual}";
    }
}