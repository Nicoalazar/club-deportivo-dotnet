using System;
using System.Windows.Forms;
using ClubDeportivo.Config;

namespace ClubDeportivo
{
    internal static class Program
    {
        [STAThread]
        // En Program.cs o donde inicialices la aplicación
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                // Intentar obtener la conexión
                Conexion.getInstancia();

                // Si llegamos aquí, la configuración fue exitosa
                Application.Run(new FrmLogin());
            }
            catch (Conexion.ConfiguracionCanceladaException)
            {
                // El usuario canceló la configuración, salimos limpiamente
                MessageBox.Show("Aplicación cancelada por el usuario.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
                return;
            }
        }
    }
}
