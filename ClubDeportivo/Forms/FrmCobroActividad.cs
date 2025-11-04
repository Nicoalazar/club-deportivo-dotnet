using ClubDeportivo.Services;
using MySql.Data.MySqlClient;
using System.Data;

namespace ClubDeportivo.Forms
{
    public partial class FrmCobroActividad : Form
    {
        private string periodo = "";
        private string medio = "";
        private int idActividad;
        private string nombreCliente = "";
        private string dniCliente = "";

        public FrmCobroActividad(int idActividad)
        {
            InitializeComponent();
            this.idActividad = idActividad;
            CargarActividad();
        }

        private void CargarActividad()
        {
            // Cargar información de la actividad para mostrar en el form
            // (nombre, precio, etc.)
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos())
                return;

            try
            {
                using var cn = Conexion.getInstancia().CrearConcexion();
                cn.Open();
                using var cmd = new MySqlCommand("sp_pago_actividad_no_socio", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("p_id_actividad", MySqlDbType.Int32).Value = idActividad;
                cmd.Parameters.Add("p_nombre_cliente", MySqlDbType.VarChar).Value = nombreCliente;
                cmd.Parameters.Add("p_dni_cliente", MySqlDbType.VarChar).Value = dniCliente;
                cmd.Parameters.Add("p_periodo", MySqlDbType.VarChar).Value = periodo;
                cmd.Parameters.Add("p_medio", MySqlDbType.VarChar).Value = medio;
                cmd.Parameters.Add("p_usuario", MySqlDbType.VarChar).Value = "Sistema";

                cmd.ExecuteNonQuery();
                MessageBox.Show("Pago de actividad registrado correctamente");

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private bool ValidarDatos()
        {
            if (string.IsNullOrEmpty(nombreCliente) || string.IsNullOrEmpty(dniCliente))
            {
                MessageBox.Show("Debe ingresar los datos del cliente");
                return false;
            }

            if (string.IsNullOrEmpty(periodo) || string.IsNullOrEmpty(medio))
            {
                MessageBox.Show("Debe seleccionar un período y un medio de pago");
                return false;
            }

            return true;
        }

        private void cmbBoxPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //periodo = cmbBoxPeriodo.Text;
        }

        private void cmbBoxMedio_SelectedIndexChanged(object sender, EventArgs e)
        {
           // medio = cmbBoxMedio.Text;
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
           // nombreCliente = txtNombre.Text;
        }

        private void txtDni_TextChanged(object sender, EventArgs e)
        {
           // dniCliente = txtDni.Text;
        }
    }
}
