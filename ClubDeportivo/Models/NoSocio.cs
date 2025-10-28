using System;

namespace ClubDeportivo.Models
{
    public class NoSocio : Persona
    {
        public string Estado { get; set; }
        public string Motivo { get; set; }
        public string FechaRegistro { get; set; }

        public NoSocio(
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
            string estado,
            string motivo,
            string fechaRegistro)
            : base(nombre, apellido, sexo, tipo, documento, fechaNacimiento, telefono, email, domicilio, activo)
        {
            Estado = estado;
            Motivo = motivo;
            FechaRegistro = fechaRegistro;
        }

        public override string MostrarDatos()
        {
            //string apto = AptoFisico == 1 ? "Apto físico OK" : "Apto físico Rechazado";
            return base.MostrarDatos() + $" | No Socio: {Estado} | {Motivo}";
        }
    }
}
