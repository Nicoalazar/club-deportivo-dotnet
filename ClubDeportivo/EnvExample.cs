namespace ClubDeportivo
{
    public class EnvExample
    {
        public string BaseDatos { get; }
        public string Servidor { get; }
        public string Puerto { get; }
        public string Usuario { get; }
        public string Clave { get; }

        public EnvExample()
        {
            BaseDatos = "Schema"; // cambiar
            Servidor = "localhost";
            Puerto = "3306";
            Usuario = "root";
            Clave = "clave"; // cambiar
        }
    }
}
