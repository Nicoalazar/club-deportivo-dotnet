using System;
using System.Windows.Forms;
using ClubDeportivo.Config;

namespace ClubDeportivo
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                // Intentar obtener la conexión (esto mostrará el formulario de configuración)
                Conexion.getInstancia();

                // Si llegamos aquí, la configuración fue exitosa
                Application.Run(new FrmLogin());
            }
            catch (Conexion.ConfiguracionCanceladaException)
            {
                // El usuario canceló la configuración, salimos limpiamente
                MessageBox.Show(
                    "La aplicación no puede continuar sin una conexión configurada.",
                    "Configuración cancelada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Capturar cualquier otro error inesperado
                MessageBox.Show(
                    $"Error al iniciar la aplicación:\n\n{ex.Message}",
                    "Error crítico",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                // Asegurarnos de que la aplicación se cierre correctamente
                Application.Exit();
            }
        }
    }
}