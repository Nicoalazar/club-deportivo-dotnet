using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace S4_Interface_De_Usuario
{
    public class Conexion
    {
        // declaramos las variables 
        private string baseDatos;
        private string servidor;
        private string puerto;
        private string usuario;
        private string clave;
        private static Conexion? con = null;
        private Conexion()  // asignamos valores a las variables de la conexion
        {
            this.baseDatos = "appdb";
            this.servidor = "127.0.0.1";
            this.puerto = "13306";
            this.usuario = "appuser";
            this.clave = "AppP4ss!";
        }
        // proceso de interacción
        public MySqlConnection CrearConcexion()
        {
            // instanciamos una conexion
            MySqlConnection? cadena = new MySqlConnection();
            // el bloque try permite controlar errores
            try
            {
                cadena.ConnectionString = "datasource=" + this.servidor +
                ";port=" + this.puerto +
                ";username=" + this.usuario +
                ";password=" + this.clave +
                ";Database=" + this.baseDatos;
            }
            catch (Exception ex)
            {
                cadena = null;
                throw;
            }
            return cadena;
        }
        // para evaluar la instancia de la conectividad
        public static Conexion getInstancia()
        {
            if (con == null) // quiere decir que la conexion esta cerrada
            {
                con = new Conexion(); // se crea una nueva
            }
            return con;


        }
    }
    }
