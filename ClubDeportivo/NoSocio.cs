using System;

namespace ClubDeportivo
{
    public class NoSocio : Persona
    {
        public int Id_Persona { get; set; }
        public bool Apto_Fisico { get; set; }
        public string Carnet_NoSocio { get; set; }

        public NoSocio() { }

        public NoSocio(string nombre, string apellido, string sexo, string tipo, string documento, int telefono, string email, int relacion,
                       int id_persona, bool apto_fisico, string carnet_noSocio)
            : base(nombre, apellido, sexo, tipo, documento, telefono, email, relacion)
        {
            Id_Persona = id_persona;
            Apto_Fisico = apto_fisico;
            Carnet_NoSocio = carnet_noSocio;
        }

        public override string MostrarDatos()
        {
            string apto = Apto_Fisico ? "Apto físico OK" : "Apto físico Rechazado";
            return base.MostrarDatos() + $" | Carnet No Socio: {Carnet_NoSocio} | {apto}";
        }
    }
}
