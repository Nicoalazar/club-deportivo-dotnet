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
        private readonly BindingList<Persona> _persona = new();

        public FrmPrimerProyecto()
        {
            InitializeComponent();
            dgvPersona.AutoGenerateColumns = false;
            dgvPersona.DataSource = _persona;
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

            if(cmbSexo.Items.Count == 0)
            {
                cmbSexo.Items.AddRange(new object[] { "Masculino", "Femenino", "Otro" });
            }

            if (cmbSexo.Items.Count > 0 && cmbSexo.SelectedIndex < 0)
            {
                cmbSexo.Text = "Seleccione";
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

            if (cmbSexo.SelectedItem is null)
            {
                MessageBox.Show("Seleccione el Sexo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbSexo.DroppedDown = true;
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDocumento.Text))
            {
                MessageBox.Show("Ingrese el Documento.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDocumento.Focus();
                return;
            }

            var socioFlag = checkSocio.Checked ? 1 : 0;
            var aptoFlag = checkApto.Checked? 1 : 0;

            var persona = new Persona(
                txtNombre.Text.Trim(),
                txtApellido.Text.Trim(),
                cmbSexo.SelectedItem.ToString()!,
                cmbTipo.SelectedItem.ToString()!,
                txtDocumento.Text.Trim(),
                txtTelefono.Text.Trim(),
                txtEmail.Text.Trim(),
                socioFlag,
                aptoFlag);

            try
            {
                if (PersonaExiste(persona.Tipo, persona.Documento))
                {
                    MessageBox.Show("Ya existe una persona con ese Tipo y Documento.",
                                    "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int personaId = GuardarPersonaEnDb(persona);

                _persona.Add(persona);

                var detalleRelacion = persona.Relacion == 1
                    ? "La persona fue dada de alta como socio."
                    : "La persona fue registrada como no socio.";

                MessageBox.Show(
                    personaId > 0 ? $"{detalleRelacion} con ID: {personaId}" : "Guardado OK.",
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
            txtEmail.Clear();
            txtTelefono.Clear();
            checkSocio.Checked = false;
            checkApto.Checked = false;

            if (cmbSexo.Items.Count > 0)
            {
                cmbSexo.Text = "Seleccione";
            }

            if (cmbTipo.Items.Count > 0)
            {
                cmbTipo.SelectedIndex = 0;
            }

            txtNombre.Focus();
        }
        private int GuardarPersonaEnDb(Persona p)
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
                cmd.Parameters.Add("p_sexo", MySqlDbType.VarString).Value = p.Sexo;
                cmd.Parameters.Add("p_tipo", MySqlDbType.VarChar).Value = p.Tipo;        // 'DNI' | 'Pasaporte' | 'Extranjero'
                cmd.Parameters.Add("p_documento", MySqlDbType.VarChar).Value = p.Documento;
                cmd.Parameters.Add("p_email", MySqlDbType.VarChar).Value = p.Email;
                cmd.Parameters.Add("p_telefono", MySqlDbType.VarChar).Value = p.Telefono;
                cmd.Parameters.Add("p_socio", MySqlDbType.Binary).Value = p.Relacion;
                cmd.Parameters.Add("p_aptoFisico", MySqlDbType.Binary).Value = p.AptoFisico;
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
