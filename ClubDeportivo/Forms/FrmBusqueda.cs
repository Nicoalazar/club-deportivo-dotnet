using ClubDeportivo.Models;
using ClubDeportivo.Services;
using MySql.Data.MySqlClient;
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
            //limpia tabla anterior
            dataGridBusqueda.DataSource = null;

            //captura de datos del formulario
            //TODO: AGREGAR nombres y apellidos
            string nroDocumento = txtDni.Text.Trim();

            using var cn = Conexion.getInstancia().CrearConcexion();
            cn.Open();

            using var cmd = new MySqlCommand("sp_persona_search", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            //TODO: CAMBIAR por nombres y apellidos
            cmd.Parameters.Add("p_nombres", MySqlDbType.VarChar).Value = "";
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
                MessageBox.Show("No se encontró ninguna persona con los datos proporcionados.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Warning);

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
            var row = dataGridBusqueda.CurrentRow;
            if (row != null)
            {
                string nombre = row.Cells["nombres"].Value?.ToString() ?? "";
                string apellido = row.Cells["apellidos"].Value?.ToString() ?? "";
                MessageBox.Show($"Editar socio: {nombre} {apellido}");
            }
        }

        private void MenuCobrar_Click(object? sender, EventArgs e)
        {
            var row = dataGridBusqueda.CurrentRow;
            if (row != null)
            {
                string nombre = row.Cells["nombres"].Value?.ToString() ?? "";
                MessageBox.Show($"Cobrar cuota a: {nombre}");
            }
        }

        private void MenuInhabilitar_Click(object? sender, EventArgs e)
        {
            var row = dataGridBusqueda.CurrentRow;
            if (row != null)
            {
                string nombre = row.Cells["nombres"].Value?.ToString() ?? "";
                MessageBox.Show($"Inhabilitar socio: {nombre}");
            }
        }

        private void MenuCarnet_Click(object? sender, EventArgs e)
        {
            var row = dataGridBusqueda.CurrentRow;
            
            if (row == null) return;
            
            var persona = new Persona(
                    
                row.Cells["Nombres"].Value.ToString()!,
                row.Cells["Apellidos"].Value.ToString()!,
                row.Cells["Sexo"].Value.ToString()!,
                row.Cells["Tipo"].Value.ToString()!,
                row.Cells["NroDocumento"].Value.ToString()!,
                Convert.ToDateTime(row.Cells["Nacimiento"].Value).Date,
                "",
                "",
                ""
                );
            string categoria = row.Cells["Categoría"].Value.ToString()!;

            if (categoria == "Socio")
            {
                var socio = new Socio(
                    persona,
                    Convert.ToInt32(row.Cells["Id"].Value),
                    Convert.ToDateTime(row.Cells["VtoAptoFisico"].Value).Date,
                    Convert.ToDateTime(row.Cells["FechaAlta"].Value).Date,
                    DateTime.Now,
                    row.Cells["estado"].Value.ToString()!);
                new SocioCarnetPrinter(socio).Imprimir();
            }
            else
            {
                var noSocio = new NoSocio(
                   persona,
                   Convert.ToDateTime(row.Cells["VtoAptoFisico"].Value).Date,
                   row.Cells["estado"].Value.ToString()!,
                   "",
                   Convert.ToDateTime(row.Cells["FechaAlta"].Value).Date);
                new NoSocioCarnetPrinter(noSocio).Imprimir();
            }               
        }

        private void MenuCancelar_Click(object? sender, EventArgs e)
        {
            dataGridBusqueda.ClearSelection();
        }

    }
}
