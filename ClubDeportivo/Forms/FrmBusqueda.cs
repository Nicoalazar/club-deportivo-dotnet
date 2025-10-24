using ClubDeportivo.Models;
using ClubDeportivo.Services;
using MySql.Data.MySqlClient;
using System.ComponentModel;

namespace ClubDeportivo
{
    public partial class FrmBusqueda : Form
    {
        private readonly BindingList<Persona> _persona = new();
        private ContextMenuStrip menuSocio;
        public FrmBusqueda()
        {
            InitializeComponent();

            dataGridBusqueda.AutoGenerateColumns = true;
            dataGridBusqueda.DataSource = _persona;

            menuSocio = new ContextMenuStrip();

            // Ítems del menú
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
            string documento = txtDni.Text.Trim();

            using var cn = Conexion.getInstancia().CrearConcexion();
            cn.Open();

            using var cmd = new MySqlCommand(
                "SELECT * FROM personas WHERE documento = @d;", cn); //TODO: mejorar consulta
            cmd.Parameters.Add("@d", MySqlDbType.VarChar).Value = documento;

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                Persona persona = new Persona
                {
                    Nombre = reader.GetString("nombre"),
                    Apellido = reader.GetString("apellido"),
                    Tipo = reader.GetString("tipo"),
                    Documento = reader.GetString("documento"),
                    Relacion = reader.GetInt32("socio"),
                };

                _persona.Clear();  // limpia resultados anteriores
                _persona.Add(persona);

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
                MessageBox.Show($"Editar socio: {persona.Nombre} {persona.Apellido}");
        }

        private void MenuCobrar_Click(object? sender, EventArgs e)
        {
            var persona = dataGridBusqueda.CurrentRow?.DataBoundItem as Persona;
            if (persona != null)
                MessageBox.Show($"Cobrar cuota a: {persona.Nombre}");
        }

        private void MenuInhabilitar_Click(object? sender, EventArgs e)
        {
            var persona = dataGridBusqueda.CurrentRow?.DataBoundItem as Persona;
            if (persona != null)
                MessageBox.Show($"Inhabilitar socio: {persona.Nombre}");
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
