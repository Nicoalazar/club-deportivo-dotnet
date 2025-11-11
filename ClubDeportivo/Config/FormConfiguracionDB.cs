using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ClubDeportivo.Config
{
    public partial class FormConfiguracionDB : Form
    {
        public bool ConexionConfigurada { get; private set; }
        public string? Servidor { get; private set; }
        public string? Puerto { get; private set; }
        public string? Usuario { get; private set; }
        public string? Clave { get; private set; }

        public FormConfiguracionDB()
        {
            InitializeComponent();
            ConexionConfigurada = false;
        }

        private void TxtPuerto_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo permite números y teclas de control
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ChkMostrarClave_CheckedChanged(object sender, EventArgs e)
        {
            txtClave.UseSystemPasswordChar = !chkMostrarClave.Checked;
        }

        private void ValidarCampos(object sender, EventArgs e)
        {
            // Ocultar resultado previo si el usuario modifica los campos
            if (panelResultado.Visible)
            {
                panelResultado.Visible = false;
                btnGuardar.Enabled = false;
            }
        }

        private async void BtnProbarConexion_Click(object sender, EventArgs e)
        {
            // Validaciones básicas
            if (string.IsNullOrWhiteSpace(txtServidor.Text))
            {
                MessageBox.Show("Por favor ingrese el servidor.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtServidor.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPuerto.Text))
            {
                MessageBox.Show("Por favor ingrese el puerto.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPuerto.Focus();
                return;
            }

            if (!int.TryParse(txtPuerto.Text, out int puerto) || puerto < 1 || puerto > 65535)
            {
                MessageBox.Show("El puerto debe ser un número entre 1 y 65535.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPuerto.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                MessageBox.Show("Por favor ingrese el usuario.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsuario.Focus();
                return;
            }

            // Deshabilitar controles durante la prueba
            DeshabilitarControles(true);

            // Mostrar barra de progreso
            progressBar.Visible = true;
            lblEstado.Visible = true;
            lblEstado.Text = "Probando conexión...";
            panelResultado.Visible = false;

            // Simular un pequeño delay para mejor UX
            await System.Threading.Tasks.Task.Delay(500);

            bool exito = await ProbarConexionAsync();

            // Ocultar barra de progreso
            progressBar.Visible = false;
            lblEstado.Visible = false;

            // Mostrar resultado
            MostrarResultado(exito);

            // Habilitar controles
            DeshabilitarControles(false);
        }

        private async System.Threading.Tasks.Task<bool> ProbarConexionAsync()
        {
            return await System.Threading.Tasks.Task.Run(() =>
            {
                try
                {
                    string cadenaConexion = $"datasource={txtServidor.Text};" +
                                          $"port={txtPuerto.Text};" +
                                          $"username={txtUsuario.Text};" +
                                          $"password={txtClave.Text};" +
                                          $"Database=grupo20_clubdeportivo";

                    using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
                    {
                        conexion.Open();
                        conexion.Close();
                        return true;
                    }
                }
                catch
                {
                    return false;
                }
            });
        }

        private void MostrarResultado(bool exito)
        {
            panelResultado.Visible = true;

            if (exito)
            {
                panelResultado.BackColor = Color.FromArgb(212, 237, 218);
                lblResultado.ForeColor = Color.FromArgb(21, 87, 36);
                lblResultado.Text = "✓ Conexión exitosa. Los datos son correctos.";
                btnGuardar.Enabled = true;
            }
            else
            {
                panelResultado.BackColor = Color.FromArgb(248, 215, 218);
                lblResultado.ForeColor = Color.FromArgb(114, 28, 36);
                lblResultado.Text = "✗ Error al conectar. Verifique los datos ingresados.";
                btnGuardar.Enabled = false;
            }
        }

        private void DeshabilitarControles(bool deshabilitar)
        {
            txtServidor.Enabled = !deshabilitar;
            txtPuerto.Enabled = !deshabilitar;
            txtUsuario.Enabled = !deshabilitar;
            txtClave.Enabled = !deshabilitar;
            btnProbarConexion.Enabled = !deshabilitar;
            btnGuardar.Enabled = !deshabilitar && panelResultado.BackColor == Color.FromArgb(212, 237, 218);
            btnCancelar.Enabled = !deshabilitar;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            Servidor = txtServidor.Text.Trim();
            Puerto = txtPuerto.Text.Trim();
            Usuario = txtUsuario.Text.Trim();
            Clave = txtClave.Text;
            ConexionConfigurada = true;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "¿Está seguro que desea cancelar la configuración?\n\nLa aplicación no podrá continuar sin una conexión válida.",
                "Confirmar cancelación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            else
            {
                this.DialogResult = DialogResult.None;
            }
        }
    }
}