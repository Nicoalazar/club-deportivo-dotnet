using MySql.Data.MySqlClient;

namespace ClubDeportivo.Services
{
    public class Conexion
    {
        // Datos de conexión directos
        private readonly string baseDatos = "ClubDeportivo"; // Cambiá si tu BD tiene otro nombre
        private readonly string servidor = "localhost";
        private readonly string puerto = "3306";
        private readonly string usuario = "root";
        private readonly string clave = ""; // Poné tu contraseña si tu MySQL tiene una

        private static Conexion? con = null;

        private Conexion() { }

        public MySqlConnection CrearConcexion()
        {
            MySqlConnection? cadena = new MySqlConnection();

            try
            {
                cadena.ConnectionString =
                    "datasource=" + servidor +
                    ";port=" + puerto +
                    ";username=" + usuario +
                    ";password=" + clave +
                    ";database=" + baseDatos;
            }
            catch (Exception)
            {
                cadena = null;
                throw;
            }

            return cadena;
        }

        public static Conexion getInstancia()
        {
            if (con == null)
            {
                con = new Conexion();
            }
            return con;
        }
    }
}
