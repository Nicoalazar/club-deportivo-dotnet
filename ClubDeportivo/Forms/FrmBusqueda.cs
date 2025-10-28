using ClubDeportivo.Models;
using ClubDeportivo.Services;
using MySql.Data.MySqlClient;
using System.ComponentModel;
using System.Data;

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

            // Ítems del menú del listado
            menuSocio.Items.Add("Editar Socio", null, MenuEditar_Click);
            menuSocio.Items.Add("Cobrar Cuota", null, MenuCobrar_Click);
            menuSocio.Items.Add("Generar Carnet", null, MenuCarnet_Click);
            menuSocio.Items.Add("Inhabilitar", null, MenuInhabilitar_Click);
            menuSocio.Items.Add(new ToolStripSeparator());
            menuSocio.Items.Add("Cancelar", null, MenuCancelar_Click);
            // Asociar el menú al DataGridView
            dataGridBusqueda.ContextMenuStrip = menuSocio;
            // Detectar click derecho para seleccionar la fila antes de abrir el menú
            dataGridBusqueda.CellMouseDown += DataGridBusqueda_CellMouseDown;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //captura de datos del formulario
            //TODO: AGREGAR nombres y apellidos
            string nroDocumento = txtDni.Text.Trim();

            using var cn = Conexion.getInstancia().CrearConcexion();
            cn.Open();

            using var cmd = new MySqlCommand("sp_persona_search", cn); //TODO: TERMINAR VISTA
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("p_nombres", MySqlDbType.VarChar).Value = "";
            //TODO: CAMBIAR por nombres y apellidos
            cmd.Parameters.Add("p_apellidos", MySqlDbType.VarChar).Value = "";
            cmd.Parameters.Add("p_nro_documento", MySqlDbType.VarChar).Value = nroDocumento;

            using var adapter = new MySqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            adapter.Fill(tabla);

            if (tabla.Rows.Count > 0)
            {
                dataGridBusqueda.DataSource = tabla;

                MessageBox.Show("La persona existe en la base de datos.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se encontró ninguna persona con ese documento.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

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

        private void MenuEditar_Click(object? sender, EventArgs e)
        {
            var persona = dataGridBusqueda.CurrentRow?.DataBoundItem as Persona;
            if (persona != null)
                MessageBox.Show($"Editar socio: {persona.Nombres} {persona.Apellidos}");
        }

        private void MenuCobrar_Click(object? sender, EventArgs e)
        {
            var persona = dataGridBusqueda.CurrentRow?.DataBoundItem as Persona;
            if (persona != null)
                MessageBox.Show($"Cobrar cuota a: {persona.Nombres}");
        }

        private void MenuInhabilitar_Click(object? sender, EventArgs e)
        {
            var persona = dataGridBusqueda.CurrentRow?.DataBoundItem as Persona;
            if (persona != null)
                MessageBox.Show($"Inhabilitar socio: {persona.Nombres}");
        }

        private void MenuCarnet_Click(object? sender, EventArgs e)
        {
            var persona = dataGridBusqueda.CurrentRow?.DataBoundItem as Persona;
            if (persona != null)
            {
                var printer = new Services.CarnetPrinter(persona);
                printer.Imprimir();
            }
        }
        private void MenuCancelar_Click(object? sender, EventArgs e)
        {
            dataGridBusqueda.ClearSelection();
        }

    }
}
