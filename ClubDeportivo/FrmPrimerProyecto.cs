using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace ClubDeportivo
{
    public partial class FrmPrimerProyecto : Form
    {
        private readonly BindingList<Persona> _Persona = new();

        public FrmPrimerProyecto()
        {
            InitializeComponent();
            dgvPostulantes.AutoGenerateColumns = false;
            dgvPostulantes.DataSource = _Persona;
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

            var Persona = new Persona(
                txtNombre.Text.Trim(),
                txtApellido.Text.Trim(),
                cmbTipo.SelectedItem.ToString()!,
                txtDocumento.Text.Trim());

            _Persona.Add(Persona);

            LimpiarEntradas();
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
    }
}
