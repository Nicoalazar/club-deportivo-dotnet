using ClubDeportivo.Models;
using ClubDeportivo.Services;
using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Windows.Forms;


namespace ClubDeportivo
{
    public partial class FrmRegistro : Form
    {
        private readonly BindingList<Persona> _persona = new();

        public FrmRegistro()
        {
            InitializeComponent();
            dgvPersona.AutoGenerateColumns = true;
            dgvPersona.DataSource = _persona;
        }

        private void FrmPrimerProyecto_Load(object sender, EventArgs e)
        {
            if (cmbTipo.Items.Count == 0)
            {
                cmbTipo.Items.AddRange(new object[] { "DNI", "Pasaporte" });
            }

            if (cmbTipo.Items.Count > 0 && cmbTipo.SelectedIndex < 0)
            {
                cmbTipo.SelectedIndex = 0;
            }

            if (cmbSexo.Items.Count == 0)
            {
                cmbSexo.Items.AddRange(new object[] { "Masculino", "Femenino", "Otros" });
            }

            if (cmbSexo.Items.Count > 0 && cmbSexo.SelectedIndex < 0)
            {
                cmbSexo.Text = "Seleccione";
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            VerificarCampos();

            var socioFlag = checkSocio.Checked;
            var aptoFlag = checkApto.Checked;

            var persona = new Persona(
                txtNombre.Text.Trim(),
                txtApellido.Text.Trim(),
                cmbSexo.SelectedItem!.ToString()!,
                cmbTipo.SelectedItem!.ToString()!,
                txtDocumento.Text.Trim(),
                dateTimePickerNacim.Value,
                txtEmail.Text.Trim(),
                txtTelefono.Text.Trim(),
                txtDomicilio.Text,
                1
            );

            using var cn = Conexion.getInstancia().CrearConcexion();
            cn.Open();
            using var transaction = cn.BeginTransaction();

            try
            {
                if (PersonaExiste(persona.Nombres, persona.Apellidos, persona.NumeroDocumento))
                {
                    MessageBox.Show("La persona ya está registrada. Revise los datos.",
                                    "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int personaId = GuardarPersonaEnDb(persona,cn,transaction);
                if (personaId <= 0) throw new Exception("No se pudo guardar persona.");

                //Guardo Relación como socio o no socio;
                int relacionId = GuardarRelacionSocio(personaId, socioFlag, aptoFlag,cn,transaction);
                if(relacionId <= 0) throw new Exception("No se pudo guardar la relación.");

                transaction.Commit();

                _persona.Add(persona);

                var detalleRelacion = socioFlag
                    ? "Socio regisreado con ID: "
                    : "La persona fue registrada";

                var detalleAptoFisico = aptoFlag
                    ? "\n\nEntregó apto fisico y vence dentro de un año"
                    : "\n\nNo entregó apto fisico";

                MessageBox.Show(
                    socioFlag ? 
                    detalleRelacion + relacionId + detalleAptoFisico
                    : detalleRelacion + detalleAptoFisico,
                    "Información",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                LimpiarEntradas();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
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
            cmbSexo.SelectedItem = null;
            cmbTipo.SelectedItem = null;
            txtDocumento.Clear();
            dateTimePickerNacim.Value = DateTime.Now;
            txtEmail.Clear();
            txtTelefono.Clear();
            txtDomicilio.Clear();

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
        private int GuardarPersonaEnDb(Persona p, MySqlConnection cn, MySqlTransaction tx)
        {
            // 1) Llamar al SP de UNA SOLA SENTENCIA (sin DELIMITER)
            using var cmd = new MySqlCommand("sp_persona_insert", cn, tx);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("p_nombres", MySqlDbType.VarChar).Value = p.Nombres;
            cmd.Parameters.Add("p_apellidos", MySqlDbType.VarChar).Value = p.Apellidos;
            cmd.Parameters.Add("p_sexo", MySqlDbType.VarString).Value = p.Sexo;
            cmd.Parameters.Add("p_tipo_documento", MySqlDbType.VarChar).Value = p.TipoDocumento;        // 'DNI' | 'Pasaporte' | 'Extranjero'
            cmd.Parameters.Add("p_nro_documento", MySqlDbType.VarChar).Value = p.NumeroDocumento;
            cmd.Parameters.Add("p_fecha_nacimiento", MySqlDbType.Date).Value = p.FechaNacimiento;
            cmd.Parameters.Add("p_email", MySqlDbType.VarChar).Value = p.Email;
            cmd.Parameters.Add("p_telefono", MySqlDbType.VarChar).Value = p.Telefono;
            cmd.Parameters.Add("p_domicilio", MySqlDbType.VarChar).Value = p.Domicilio;
            cmd.Parameters.Add("p_estado", MySqlDbType.Binary).Value = p.Activo;


            // 2) Retorna el id nuevo

            return Convert.ToInt32(cmd.ExecuteScalar());
        }
        private bool PersonaExiste(string nombres,string apellidos, string documento)
        {
            using var cn = Conexion.getInstancia().CrearConcexion();
            cn.Open();

            using var cmd = new MySqlCommand("sp_persona_search", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("p_nombres", MySqlDbType.VarChar).Value = nombres;
            cmd.Parameters.Add("p_apellidos", MySqlDbType.VarChar).Value = apellidos;
            cmd.Parameters.Add("p_nro_documento", MySqlDbType.VarChar).Value =documento;

            var result = cmd.ExecuteScalar();
            var count = Convert.ToInt32(result);
            return count > 0;
        }

        private void VerificarCampos()
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

            if (cmbSexo.SelectedItem is null)
            {
                MessageBox.Show("Seleccione el Sexo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbSexo.DroppedDown = true;
                return;
            }

            if (dateTimePickerNacim.Value.Date == DateTime.Now.Date)
            {
                MessageBox.Show("Ingrese Fecha de Nacimiento Valida", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dateTimePickerNacim.Focus();
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

            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MessageBox.Show("Ingrese el Teléfono", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Ingrese el Email", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDomicilio.Text))
            {
                MessageBox.Show("Ingrese el Domicilio", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDomicilio.Focus();
                return;
            }
        }

        private int GuardarRelacionSocio(int personaId, bool socioFlag, bool aptoFlag, MySqlConnection cn, MySqlTransaction tx)
        {
            var vencimientoApto = aptoFlag ? DateTime.Now.AddYears(1) : DateTime.Now;

            if (socioFlag)
            {
                // Guardo Socio
                using var cmd = new MySqlCommand("sp_socio_insert", cn, tx);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("p_id_persona", MySqlDbType.Int32).Value = personaId;
                cmd.Parameters.Add("p_apto_vencimiento", MySqlDbType.DateTime).Value = vencimientoApto;

                // Retorno el id nuevo
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
            else
            {
                //Guardo No Socio
                using var cmd = new MySqlCommand("sp_no_socio_insert", cn, tx);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("p_id_persona", MySqlDbType.Int32).Value = personaId;
                cmd.Parameters.Add("p_estado", MySqlDbType.VarChar).Value = "Eleccion";
                cmd.Parameters.Add("p_apto_vencimiento", MySqlDbType.DateTime).Value = vencimientoApto;
                cmd.Parameters.Add("p_motivo", MySqlDbType.VarChar).Value = "Inscripción";

                // Retorno el id nuevo
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

    }
}
