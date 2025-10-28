namespace ClubDeportivo.Models
{
    public class Persona
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Sexo { get; set; }
        public string TipoDocumento { get; set; }       // DNI / Pasaporte / Extranjero
        public string NumeroDocumento { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Domicilio { get; set; }
        public int Activo {  get; set; }

        public Persona(
            string nombre, 
            string apellido, 
            string sexo, 
            string tipoDocumento, 
            string numeroDocumento, 
            DateTime fechaNacimiento,
            string email,
            string telefono,
            string domicilio ,
            int activo 
            )
        {
            Nombres = nombre;
            Apellidos = apellido;
            Sexo = sexo;
            TipoDocumento = tipoDocumento;
            NumeroDocumento = numeroDocumento;
            FechaNacimiento = fechaNacimiento;
            Email = email;
            Telefono = telefono;
            Activo = activo;
            Domicilio = domicilio;
        }
        
        public virtual string MostrarDatos()
        {
            return $"{Nombres} {Apellidos} | {TipoDocumento}: {NumeroDocumento} | Tel: {Telefono} | Email: {Email}";
        }

    }
}
