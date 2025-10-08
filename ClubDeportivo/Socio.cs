using System;

namespace ClubDeportivo
{
    public class Socio : Persona
    {
        public int Id_Persona { get; set; }
        public bool Apto_Fisico { get; set; }
        public string Carnet_Socio { get; set; }
        public string Estado { get; set; } //este era el estado del pago
        public Socio() { }

        public Socio(string nombre, string apellido, string tipo, string documento, int telefono, string email,
                     int id_persona, bool apto_fisico, string carnet_socio, string estado)
            : base(nombre, apellido, tipo, documento, telefono, email)
        {
            Id_Persona = id_persona;
            Apto_Fisico = apto_fisico;
            Carnet_Socio = carnet_socio;
            Estado = estado;
        }

        public override string MostrarDatos()
        {
            string apto = Apto_Fisico ? "Apto físico OK" : "Apto físico NO";
            return base.MostrarDatos() + $" | Carnet Socio: {Carnet_Socio} | {apto} | Estado de cobro: {Estado}";
        }
    }
}
