using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace ClubDeportivo.Config
{
    public class Conexion
    {
        private string? baseDatos;
        private string? servidor;
        private string? puerto;
        private string? usuario;
        private string? clave;
        private static Conexion? con = null;

        private Conexion()
        {
            // Mostrar el formulario de configuración
            using (FormConfiguracionDB formConfig = new FormConfiguracionDB())
            {
                DialogResult resultado = formConfig.ShowDialog();

                if (resultado == DialogResult.OK && formConfig.ConexionConfigurada)
                {
                    // Guardar los datos de conexión
                    this.baseDatos = "grupo20_clubdeportivo";
                    this.servidor = formConfig.Servidor;
                    this.puerto = formConfig.Puerto;
                    this.usuario = formConfig.Usuario;
                    this.clave = formConfig.Clave;

                }
                else
                {
                    // El usuario canceló la configuración
                    throw new ConfiguracionCanceladaException();
                }
            }
        }

        // Excepción personalizada para cancelación de configuración
        public class ConfiguracionCanceladaException : Exception
        {
            public ConfiguracionCanceladaException() : base("El usuario canceló la configuración") { }
        }

        // Creación de la conexión
        public MySqlConnection CrearConexion()
        {
            MySqlConnection cadena = new MySqlConnection();
            try
            {
                cadena.ConnectionString = $"datasource={this.servidor};" +
                                        $"port={this.puerto};" +
                                        $"username={this.usuario};" +
                                        $"password={this.clave};" +
                                        $"Database={this.baseDatos}";
            }
            catch (Exception)
            {
                cadena = null;
                throw;
            }
            return cadena;
        }

        // Evalúa la instancia de la conectividad (Patrón Singleton)
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