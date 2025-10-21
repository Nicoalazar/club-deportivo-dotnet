using System;

namespace ClubDeportivo.Models
{
    public class Socio : Persona
    {
        public string CarnetSocio { get; set; }
        public string Estado { get; set; } //este era el estado del pago
        public Socio() { }

        public Socio(string nombre, string apellido, string sexo, string tipo, string documento, string telefono, string email, int relacion, 
            int aptoFisico, string carnetSocio, string estado)
            : base(nombre, apellido, sexo, tipo, documento, telefono, email, relacion, aptoFisico)
        {
            CarnetSocio = carnetSocio;
            Estado = estado;
        }

        public override string MostrarDatos()
        {
            string apto = AptoFisico == 1 ? "Apto físico OK" : "Apto físico NO";
            return base.MostrarDatos() + $" | Carnet Socio: {CarnetSocio} | {apto} | Estado de cobro: {Estado}";
        }
    }
}
