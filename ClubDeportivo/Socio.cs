
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
        public Socio(string nombre, string apellido, string dni, string email, string telefono,
                     string apto, string carnet, string estado)
            : base(nombre, apellido, dni, email, telefono)
        {
            this.AptoFisico = apto;
            this.CarnetSocio = carnet;
            this.Estado = estado;
        }

        // Sobrescribimos el método Inscribir() de Persona para incluir la lógica de Socio
        public override void Inscribir()
        {
            // 1. Llamar al método de la clase base (insertar en tabla Persona)
            base.Inscribir();

            // 2. Lógica específica del socio (insertar en tabla Socio, generar carnet, etc.)
            Console.WriteLine($"Registrando carnet {CarnetSocio} y estado {Estado} en tabla SOCIO.");

            // Aquí iría el INSERT INTO Socio (...)
        }
    }
}

