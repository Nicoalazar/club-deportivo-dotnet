using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Windows.Forms;


namespace ClubDeportivo
{
    public partial class FrmPrimerProyecto : Form
    {
        private readonly BindingList<Postulante> _postulantes = new();
        private int socio = 0;

        public FrmPrimerProyecto()
        {
            InitializeComponent();
            dgvPostulantes.AutoGenerateColumns = false;
            dgvPostulantes.DataSource = _postulantes;
        }

        private void FrmPrimerProyecto_Load(object sender, EventArgs e)
        {
            if (cmbTipo.Items.Count == 0)
            {
                cmbTipo.Items.AddRange(new object[] { "DNI", "Pasaporte", "Extranjero" });
            }

            if (cmbTipo.Items.Count > 0 && cmbTipo.SelectedIndex < 0)
            {
                cmbTipo.SelectedIndex = 0;
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Ingrese el Nombre.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("Ingrese el Apellido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApellido.Focus();
                return;
            }

            if (cmbTipo.SelectedItem is null)
            {
                MessageBox.Show("Seleccione el Tipo de documento.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbTipo.DroppedDown = true;
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDocumento.Text))
            {
                MessageBox.Show("Ingrese el Documento.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDocumento.Focus();
                return;
            }

            var postulante = new Postulante(
                txtNombre.Text.Trim(),
                txtApellido.Text.Trim(),
                cmbTipo.SelectedItem.ToString()!,
                txtDocumento.Text.Trim()
            );

            try
            {
                if (PersonaExiste(postulante.Tipo, postulante.Documento))
                {
                    MessageBox.Show("Ya existe una persona con ese Tipo y Documento.",
                                    "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int personaId = GuardarPersonaEnDb(postulante);

                _postulantes.Add(postulante);

                MessageBox.Show(
                    personaId > 0 ? $"Guardado OK. ID: {personaId}" : "Guardado OK.",
                    "Información",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                LimpiarEntradas();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error de base de datos: " + ex.Message, "DB",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarEntradas();
        }

        private void LimpiarEntradas()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtDocumento.Clear();

            if (cmbTipo.Items.Count > 0)
            {
                cmbTipo.SelectedIndex = 0;
            }

            txtNombre.Focus();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkSocio.Checked)
            {
                socio = 1;
            }
        }
        private int GuardarPersonaEnDb(Postulante p)
        {
            // Reutilizamos tu misma conexión del login
            using var cn = Conexion.getInstancia().CrearConcexion();
            cn.Open();

            // 1) Llamar al SP de UNA SOLA SENTENCIA (sin DELIMITER)
            using (var cmd = new MySqlCommand("sp_persona_insert", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_nombre", MySqlDbType.VarChar).Value = p.Nombre;
                cmd.Parameters.Add("p_apellido", MySqlDbType.VarChar).Value = p.Apellido;
                cmd.Parameters.Add("p_tipo", MySqlDbType.VarChar).Value = p.Tipo;        // 'DNI' | 'Pasaporte' | 'Extranjero'
                cmd.Parameters.Add("p_documento", MySqlDbType.VarChar).Value = p.Documento;
                cmd.Parameters.Add("p_socio", MySqlDbType.TinyText).Value = socio;
                cmd.ExecuteNonQuery();
            }

            // 2) Recuperar el id (nuevo o existente) por la clave única (tipo, documento)
            using var cmdId = new MySqlCommand(
                "SELECT id FROM personas WHERE tipo = @tipo AND documento = @doc LIMIT 1;", cn);
            cmdId.Parameters.Add("@tipo", MySqlDbType.VarChar).Value = p.Tipo;
            cmdId.Parameters.Add("@doc", MySqlDbType.VarChar).Value = p.Documento;

            object? obj = cmdId.ExecuteScalar();
            return (obj != null && int.TryParse(obj.ToString(), out int id)) ? id : 0;
        }
        private bool PersonaExiste(string tipo, string documento)
        {
            using var cn = Conexion.getInstancia().CrearConcexion();
            cn.Open();

            using var cmd = new MySqlCommand(
                "SELECT COUNT(1) FROM personas WHERE tipo = @t AND documento = @d LIMIT 1;", cn);
            cmd.Parameters.Add("@t", MySqlDbType.VarChar).Value = tipo;
            cmd.Parameters.Add("@d", MySqlDbType.VarChar).Value = documento;

            var result = cmd.ExecuteScalar();
            var count = Convert.ToInt32(result);
            return count > 0;
        }
    }
}
