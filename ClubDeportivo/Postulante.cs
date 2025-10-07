namespace ClubDeportivo
{
    public class Postulante
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Tipo { get; set; }       // DNI / Pasaporte / Extranjero
        public string Documento { get; set; }

        public Postulante() { }

        public Postulante(string nombre, string apellido, string tipo, string documento)
        {
            Nombre = nombre;
            Apellido = apellido;
            Tipo = tipo;
            Documento = documento;
        }
    }
}
