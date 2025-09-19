using System;
using System.Windows.Forms;

namespace S4_Interface_De_Usuario
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            // Opcional: cargar una imagen local o de recursos
            // picInstituto.Image = Image.FromFile(@"C:\Imagenes\ifts.jpg");
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            // Validación simple (no modal al mostrar el principal)
            if (txtUsuario.Text == "Administrador" && txtClave.Text == "Admin1234")
            {
                var frm = new FrmPrimerProyecto();
                frm.Show();     // NO modal
                this.Hide();    // Opcional: ocultar login
                // Si preferís cerrarlo cuando se cierre el principal:
                frm.FormClosed += (s, args) => this.Close();
            }
            else
            {
                MessageBox.Show("Usuario inexistente.", "Acceso denegado",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
