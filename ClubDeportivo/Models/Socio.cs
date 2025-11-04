namespace ClubDeportivo.Models
{
    public class Socio
    {
        public Persona Persona { get; set; }
        public int NumeroSocio { get; set; }
        public DateTime VtoAptoFisico { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }
        public string? Observaciones { get; set; }

        public Socio()
        {
            Persona = new Persona("", "", "", "", "", DateTime.Now, "", "", "");
        }

        public Socio(Persona persona, int numeroSocio, DateTime vtoAptoFisico, DateTime fechaAlta, DateTime fechaBaja, string obs)
        {
            Persona = persona;
            NumeroSocio = numeroSocio;
            FechaAlta = fechaAlta;
            FechaBaja = fechaBaja;
            VtoAptoFisico = vtoAptoFisico;
            Observaciones = obs;
        }

        public string MostrarDatos()
        {
            return $"{Persona.MostrarDatos()} | Carnet Socio: {NumeroSocio} | Venc. apto físico: {VtoAptoFisico:dd/MM/yyyy}";
        }
    }
}
