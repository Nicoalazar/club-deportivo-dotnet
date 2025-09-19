using S4_Interface_De_Usuario;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace S4_Interface_De_Usuario
{
    public partial class FrmPrimerProyecto : Form
    {
        // Lista enlazable para el grid
        private readonly BindingList<Postulante> _postulantes = new BindingList<Postulante>();

        public FrmPrimerProyecto()
        {
            InitializeComponent();
        }

        private void FrmPrimerProyecto_Load(object sender, EventArgs e)
        {
            // Poblar combo (por si no lo dejaste en el diseñador)
            if (cmbTipo.Items.Count == 0)
                cmbTipo.Items.AddRange(new object[] { "DNI", "Pasaporte", "Extranjero" });

            cmbTipo.SelectedIndex = 0;

            // Configurar grid
            dgvPostulantes.AutoGenerateColumns = false;
            dgvPostulantes.DataSource = _postulantes;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            // Validaciones mínimas
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Ingrese el Nombre.");
                txtNombre.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("Ingrese el Apellido.");
                txtApellido.Focus();
                return;
            }
            if (cmbTipo.SelectedItem == null)
            {
                MessageBox.Show("Seleccione el Tipo de documento.");
                cmbTipo.DroppedDown = true;
                return;
            }
            if (string.IsNullOrWhiteSpace(txtDocumento.Text))
            {
                MessageBox.Show("Ingrese el Documento.");
                txtDocumento.Focus();
                return;
            }

            // Crear Postulante usando la clase
            var p = new Postulante(
                txtNombre.Text.Trim(),
                txtApellido.Text.Trim(),
                cmbTipo.SelectedItem.ToString(),
                txtDocumento.Text.Trim()
            );

            // Agregar a la lista (aparece automáticamente en el grid)
            _postulantes.Add(p);

            // (Opcional) limpiar entradas luego de agregar
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
            cmbTipo.SelectedIndex = 0;
            txtNombre.Focus();
        }
    }
}
