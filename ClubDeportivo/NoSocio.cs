using System;

namespace ClubDeportivo
{
    public class NoSocio : Persona
    {
        public string CarnetNoSocio { get; set; }

        public NoSocio() { }

        public NoSocio(string nombre, string apellido, string sexo, string tipo, string documento, string telefono, string email, int relacion,
                       int aptoFisico, string carnetNoSocio)
            : base(nombre, apellido, sexo, tipo, documento, telefono, email, relacion, aptoFisico)
        {
            CarnetNoSocio = carnetNoSocio;
        }

        public override string MostrarDatos()
        {
            string apto = AptoFisico == 1 ? "Apto físico OK" : "Apto físico Rechazado";
            return base.MostrarDatos() + $" | Carnet No Socio: {CarnetNoSocio} | {apto}";
        }
    }
}
