using System;
using System.Windows.Forms;

namespace S4_Interface_De_Usuario
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "Administrador" && txtClave.Text == "Admin1234")
            {
                var frm = new FrmPrimerProyecto();
                frm.Show();
                this.Hide();
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
