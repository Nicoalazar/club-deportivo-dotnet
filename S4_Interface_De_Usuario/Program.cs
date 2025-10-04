using S4_Interface_De_Usuario;
using System;
using System.Windows.Forms;

namespace S4_Interface_De_Usuario
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmLogin()); // <- Inicia por el Login
        }
    }
}
