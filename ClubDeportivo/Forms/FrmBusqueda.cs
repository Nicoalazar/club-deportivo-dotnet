using ClubDeportivo.Forms;
using ClubDeportivo.Models;
using ClubDeportivo.Services;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text.RegularExpressions;

namespace ClubDeportivo
{
    public partial class FrmBusqueda : Form
    {
        private ContextMenuStrip menuSocio;

        public FrmBusqueda()
        {
            InitializeComponent();

            dataGridBusqueda.AutoGenerateColumns = true;

            menuSocio = new ContextMenuStrip();
            menuSocio.Items.Add("Editar Socio", null, MenuEditar_Click);
            menuSocio.Items.Add("Cobrar", null, MenuCobrar_Click);
            menuSocio.Items.Add("Generar Carnet", null, MenuCarnet_Click);
            menuSocio.Items.Add("Inhabilitar", null, MenuInhabilitar_Click);
            menuSocio.Items.Add(new ToolStripSeparator());
            menuSocio.Items.Add("Cancelar", null, MenuCancelar_Click);

            dataGridBusqueda.ContextMenuStrip = menuSocio;
            dataGridBusqueda.CellMouseDown += DataGridBusqueda_CellMouseDown;
            dataGridBusqueda.CellDoubleClick += DataGridBusqueda_CellDoubleClick;
        }

        private bool ContieneCaracteresInvalidos(string texto)
        {
            return !Regex.IsMatch(texto, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]*$");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dataGridBusqueda.DataSource = null;

            string nombre = txtNombre.Text.Trim();
            string apellido = txtApellido.Text.Trim();
            string documento = txtDni.Text.Trim();

            if (ContieneCaracteresInvalidos(nombre))
            {
                MessageBox.Show("El campo 'Nombre' contiene caracteres no válidos.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            if (ContieneCaracteresInvalidos(apellido))
            {
                MessageBox.Show("El campo 'Apellido' contiene caracteres no válidos.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApellido.Focus();
                return;
            }

            if (!Regex.IsMatch(documento, @"^\d*$") && !string.IsNullOrEmpty(documento))
            {
                MessageBox.Show("El campo 'DNI' solo debe contener números.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDni.Focus();
                return;
            }

            using var cn = Conexion.getInstancia().CrearConcexion();
            cn.Open();

            using var cmd = new MySqlCommand("sp_persona_search", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_nombres", string.IsNullOrEmpty(nombre) ? DBNull.Value : nombre.ToLower());
            cmd.Parameters.AddWithValue("p_apellidos", string.IsNullOrEmpty(apellido) ? DBNull.Value : apellido.ToLower());
            cmd.Parameters.AddWithValue("p_nro_documento", string.IsNullOrEmpty(documento) ? DBNull.Value : documento);

            using var adapter = new MySqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            adapter.Fill(tabla);

            if (tabla.Rows.Count > 0)
            {
                dataGridBusqueda.DataSource = tabla;
                MessageBox.Show($"Se encontraron {tabla.Rows.Count} resultados.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se encontró ninguna persona con los datos proporcionados.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtDni.Clear();
            dataGridBusqueda.DataSource = null;
            txtNombre.Focus();
        }

        private void DataGridBusqueda_CellMouseDown(object? sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dataGridBusqueda.ClearSelection();
                dataGridBusqueda.Rows[e.RowIndex].Selected = true;
                dataGridBusqueda.CurrentCell = dataGridBusqueda.Rows[e.RowIndex].Cells[0];
            }
        }

        private void DataGridBusqueda_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridBusqueda.Rows[e.RowIndex];

                var persona = new Persona(
                    row.Cells["nombres"].Value?.ToString() ?? "",
                    row.Cells["apellidos"].Value?.ToString() ?? "",
                    row.Cells["sexo"].Value?.ToString() ?? "",
                    row.Cells["tipo_documento"].Value?.ToString() ?? "",
                    row.Cells["nro_documento"].Value?.ToString() ?? "",
                    Convert.ToDateTime(row.Cells["fecha_nacimiento"].Value),
                    row.Cells["email"].Value?.ToString() ?? "",
                    row.Cells["telefono"].Value?.ToString() ?? "",
                    row.Cells["domicilio"].Value?.ToString() ?? ""
                );

                MessageBox.Show($"Detalle:\n{persona.Nombres} {persona.Apellidos}\n{persona.TipoDocumento} {persona.NumeroDocumento}",
                                "Detalle de Persona", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void MenuEditar_Click(object? sender, EventArgs e) { /* ... */ }
        private void MenuCobrar_Click(object? sender, EventArgs e) { /* ... */ }
        private void MenuCarnet_Click(object? sender, EventArgs e) { /* ... */ }
        private void MenuInhabilitar_Click(object? sender, EventArgs e) { /* ... */ }
        private void MenuCancelar_Click(object? sender, EventArgs e)
        {
            dataGridBusqueda.ClearSelection();
        }
    }
}
