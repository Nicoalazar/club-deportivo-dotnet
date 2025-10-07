
using System;

namespace ClubDeportivo
{
    public class Socio : Persona
    {
        public int NumeroSocio { get; set; }
        public string AptoFisico { get; set; }
        public string CarnetSocio { get; set; }
        public string EstadoSocio { get; set; }

        // Constructor que llama al constructor de la clase base (Persona)
        public Socio(string nombre, string apellido,string tipoDocumento, string dni, string apto, string carnet, string EstadoSocio)
            : base(nombre, apellido,tipoDocumento,dni)
        {
            this.AptoFisico = apto;
            this.CarnetSocio = carnet;
            this.EstadoSocio = EstadoSocio;
        }

        
        
    }
}

