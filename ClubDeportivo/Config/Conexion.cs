using MySql.Data.MySqlClient;

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
            bool datosValidos = false;
            string T_servidor, T_puerto, T_usuario, T_clave;

            // Ciclo hasta que los datos sean correctos o el usuario cancele
            while (!datosValidos)
            {
                // Solicitar Servidor
                T_servidor = Microsoft.VisualBasic.Interaction.InputBox(
                    "Ingrese el servidor:",
                    "Configuración MySQL - Servidor",
                    "localhost");

                if (string.IsNullOrWhiteSpace(T_servidor))
                {
                    if (ConfirmarSalida())
                        throw new ConfiguracionCanceladaException();
                    continue;
                }

                // Solicitar Puerto
                T_puerto = Microsoft.VisualBasic.Interaction.InputBox(
                    "Ingrese el puerto:",
                    "Configuración MySQL - Puerto",
                    "3306");

                if (string.IsNullOrWhiteSpace(T_puerto))
                {
                    if (ConfirmarSalida())
                        throw new ConfiguracionCanceladaException();
                    continue;
                }

                // Validar que el puerto sea un número válido
                if (!int.TryParse(T_puerto, out int puertoNum) || puertoNum < 1 || puertoNum > 65535)
                {
                    MessageBox.Show("El puerto debe ser un número entre 1 y 65535.",
                        "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }

                // Solicitar Usuario
                T_usuario = Microsoft.VisualBasic.Interaction.InputBox(
                    "Ingrese el usuario:",
                    "Configuración MySQL - Usuario",
                    "root");

                if (string.IsNullOrWhiteSpace(T_usuario))
                {
                    if (ConfirmarSalida())
                        throw new ConfiguracionCanceladaException();
                    continue;
                }

                // Solicitar Contraseña
                T_clave = Microsoft.VisualBasic.Interaction.InputBox(
                    "Ingrese la contraseña:",
                    "Configuración MySQL - Contraseña",
                    "");

                // La contraseña puede estar vacía, validamos solo si es null (canceló)
                if (T_clave == null)
                {
                    if (ConfirmarSalida())
                        throw new ConfiguracionCanceladaException();
                    continue;
                }

                // Confirmar datos ingresados (SIN mostrar la contraseña)
                DialogResult confirmacion = MessageBox.Show(
                    $"SERVIDOR: {T_servidor}\n" +
                    $"PUERTO: {T_puerto}\n" +
                    $"USUARIO: {T_usuario}\n" +
                    $"CONTRASEÑA: {(T_clave == "" ? "Sin Contraseña" : T_clave)}\n\n" +
                    "¿Los datos son correctos?",
                    "Confirmar configuración MySQL",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmacion == DialogResult.Yes)
                {
                    // Intentar probar la conexión antes de guardar
                    if (ProbarConexion(T_servidor, T_puerto, T_usuario, T_clave))
                    {
                        // Guardar configuración
                        this.baseDatos = "grupo20_clubdeportivo";
                        this.servidor = T_servidor;
                        this.puerto = T_puerto;
                        this.usuario = T_usuario;
                        this.clave = T_clave;
                        datosValidos = true;

                        MessageBox.Show("Conexión configurada correctamente.",
                            "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        DialogResult reintentar = MessageBox.Show(
                            "No se pudo conectar con los datos ingresados.\n\n¿Desea reintentar?",
                            "Error de conexión",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Error);

                        if (reintentar == DialogResult.No)
                        {
                            throw new ConfiguracionCanceladaException();
                        }
                    }
                }
                // Si dijo "No", el ciclo se repite automáticamente
            }
        }

        // Método para confirmar si el usuario quiere salir
        private bool ConfirmarSalida()
        {
            DialogResult resultado = MessageBox.Show(
                "Operación cancelada.\n\n¿Desea salir de la aplicación?",
                "Configuración MySQL",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            return resultado == DialogResult.Yes;
        }

        // Excepción personalizada para cancelación de configuración
        public class ConfiguracionCanceladaException : Exception
        {
            public ConfiguracionCanceladaException() : base("El usuario canceló la configuración") { }
        }

        // Método para probar la conexión antes de guardarla
        private bool ProbarConexion(string servidor, string puerto, string usuario, string clave)
        {
            try
            {
                string cadenaConexion = $"datasource={servidor};" +
                                      $"port={puerto};" +
                                      $"username={usuario};" +
                                      $"password={clave};" +
                                      $"Database=grupo20_clubdeportivo";

                using (MySqlConnection conexionPrueba = new MySqlConnection(cadenaConexion))
                {
                    conexionPrueba.Open();
                    conexionPrueba.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar:\n{ex.Message}",
                    "Error de conexión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
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