namespace ClubDeportivo
{
    public class Persona
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Sexo { get; set; }
        public string Tipo { get; set; }       // DNI / Pasaporte / Extranjero
        public string Documento { get; set; }
        public string Email { get; set; }
        public int Telefono { get; set; }
        public int Relacion {  get; set; }




        public Persona() { }

        public Persona(string nombre, string apellido, string sexo, string tipo, string documento, int telefono, string email, int relacion )
        {
            Nombre = nombre;
            Apellido = apellido;
            Sexo = sexo;
            Tipo = tipo;
            Documento = documento;
            Email = email;
            Telefono = telefono;
            Relacion = relacion;
        }
        
        public virtual string MostrarDatos()
{
    return $"{Nombre} {Apellido} | {Tipo}: {Documento} | Tel: {Telefono} | Email: {Email}";
}

    }
}
