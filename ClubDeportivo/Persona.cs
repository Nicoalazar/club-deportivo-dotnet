namespace ClubDeportivo
{
    public class Persona
    {
        // 1. PROPIEDADES (ATRIBUTOS)
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string tipoDocumento { get; set; }
        public string dni { get; set; }





        public Persona(string nombre, string apellido, string tipoDocumento, string dni)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.tipoDocumento = tipoDocumento;
            this.dni = dni;

        }

    }

}
       