using System;

namespace ClubDeportivo.Models
{
    public class NoSocio
    {
        public Persona Persona { get; set; }

        public string Estado { get; set; }
        public string Motivo { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime VtoAptoFisico { get; set; }

        public NoSocio()
        {
            Persona = new Persona("", "", "", "", "", DateTime.Now, "", "", "");
        }

        public NoSocio(Persona persona, DateTime vtoAptoFisico, string estado, string motivo, DateTime fechaRegistro )
        {
            Persona = persona;
            VtoAptoFisico = vtoAptoFisico;
            Estado = estado;
            Motivo = motivo;
            FechaRegistro = fechaRegistro;
        }

        public string MostrarDatos()
        {
            return $"{Persona.MostrarDatos()} | No Socio: {Estado} | {Motivo}";
        }
    }
}
