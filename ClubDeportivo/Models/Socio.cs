using System;

namespace ClubDeportivo.Models
{
    public class Socio : Persona
    {
        public string IdSocio { get; set; }
        public string FechaAlta { get; set; }
        public string VtoAptoFisico { get; set; }
        public string Observaciones { get; set; } 

        public Socio(
            string nombre,
            string apellido,
            string sexo,
            string tipo,
            string documento,
            DateTime fechaNacimiento,
            string telefono,
            string email,
            string domicilio,
            int activo,
            string numeroSocio,
            string fechaAlta,
            string vtoAptoFisico,
            string obs
            )
            : base(
                  nombre, 
                  apellido, 
                  sexo, 
                  tipo, 
                  documento, 
                  fechaNacimiento, 
                  telefono, 
                  email, 
                  domicilio, 
                  activo
            )
        {
            IdSocio = numeroSocio;
            FechaAlta = fechaAlta;
            VtoAptoFisico = vtoAptoFisico;
            Observaciones = obs;
        }

        public override string MostrarDatos()
        {
            //string apto = AptoFisico == 1 ? "Apto físico OK" : "Apto físico NO";
            return base.MostrarDatos() + $" | Carnet Socio: {IdSocio} |  Vencimiento apto fisico: {VtoAptoFisico}";
        }
    }
}
