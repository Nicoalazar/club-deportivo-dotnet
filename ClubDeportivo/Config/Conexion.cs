using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ClubDeportivo.Config
{
    public class Conexion
    {
        // declaramos las variables 
        private readonly string baseDatos;
        private readonly string servidor;
        private readonly string puerto;
        private readonly string usuario;
        private readonly string clave;

        private static Conexion? con = null;
        private readonly Env env;

        private Conexion()
        {
            env = new Env();
            baseDatos = env.BaseDatos;
            servidor = env.Servidor;
            puerto = env.Puerto;
            usuario = env.Usuario;
            clave = env.Clave;
        }
        // proceso de interacción
        public MySqlConnection CrearConcexion()
        {
            // instanciamos una conexion
            MySqlConnection? cadena = new MySqlConnection();
            // el bloque try permite controlar errores
            try
            {
                cadena.ConnectionString = "datasource=" + servidor +
                ";port=" + puerto +
                ";username=" + usuario +
                ";password=" + clave +
                ";Database=" + baseDatos;
            }
            catch (Exception)
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
