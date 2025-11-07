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
            menuSocio.Items.Add("Editar Persona", null, MenuEditar_Click);
            menuSocio.Items.Add("Cobrar", null, MenuCobrar_Click);
            menuSocio.Items.Add("Generar Carnet", null, MenuCarnet_Click);
            menuSocio.Items.Add("Inhabilitar", null, MenuInhabilitar_Click);
            menuSocio.Items.Add(new ToolStripSeparator());
            menuSocio.Items.Add("Cancelar", null, MenuCancelar_Click);

            dataGridBusqueda.ContextMenuStrip = menuSocio;
            dataGridBusqueda.CellMouseDown += DataGridBusqueda_CellMouseDown;
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

            // *** VALIDACIONES ***
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

            if (string.IsNullOrEmpty(nombre) && string.IsNullOrEmpty(apellido) && string.IsNullOrEmpty(documento))
            {
                MessageBox.Show("Debe ingresar los parametros de búsqueda", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDni.Focus();
                return;
            }
            // *** FIN VALIDACIONES ***

            try
            {
                // Configuración de Parámetros de Búsqueda Flexible
                // Esto envía la cadena en minúsculas y usa DBNull.Value si está vacío.
                object paramNombre = string.IsNullOrEmpty(nombre)
                                     ? (object)DBNull.Value
                                     : nombre.ToLower();

                object paramApellido = string.IsNullOrEmpty(apellido)
                                       ? (object)DBNull.Value
                                       : apellido.ToLower();

                object paramDocumento = string.IsNullOrEmpty(documento)
                                        ? (object)DBNull.Value
                                        : documento;

                using var cn = Conexion.getInstancia().CrearConcexion();
                cn.Open();

                using var cmd = new MySqlCommand("sp_persona_search", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_nombres", paramNombre);
                cmd.Parameters.AddWithValue("p_apellidos", paramApellido);
                cmd.Parameters.AddWithValue("p_nro_documento", paramDocumento);

                using var adapter = new MySqlDataAdapter(cmd);
                DataTable tabla = new DataTable();

                // *** LÍNEA 79: La falla ocurre AQUÍ cuando el SQL está mal. ***
                adapter.Fill(tabla);
                // ************************************************************

                if (tabla.Rows.Count > 0)
                {
                    dataGridBusqueda.DataSource = tabla;
                    MessageBox.Show($"Se encontraron {tabla.Rows.Count} resultados.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dataGridBusqueda.DataSource = null;
                    MessageBox.Show("No se encontró ninguna persona con los datos proporcionados.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (MySqlException ex)
            {
                // Este catch es el que captura el error de columna desconocida del servidor.
                MessageBox.Show($"Error de Base de Datos: {ex.Message}", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error inesperado: {ex.Message}", "Error General", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        // --- MANEJADORES DE EVENTOS DEL DATAGRID Y MENÚ CONTEXTUAL ---

        private void DataGridBusqueda_CellMouseDown(object? sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dataGridBusqueda.ClearSelection();
                dataGridBusqueda.Rows[e.RowIndex].Selected = true;
                dataGridBusqueda.CurrentCell = dataGridBusqueda.Rows[e.RowIndex].Cells[0];
            }
        }

        // Métodos de click del menú contextual
        private void MenuEditar_Click(object? sender, EventArgs e)
        {
            var row = dataGridBusqueda.CurrentRow;
            if (row != null)
            {
                MessageBox.Show("Funcionalidad 'Editar Persona' - ¡PRÓXIMAMENTE!",
                                    "En Desarrollo",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
            }
        }

        private void MenuCobrar_Click(object? sender, EventArgs e)
        {
            var row = dataGridBusqueda.CurrentRow;
            if (row != null)
            {
                string categoria = row.Cells["Categoría"].Value.ToString()!;
                if (categoria == "Socio")
                {
                    int idSocio = Convert.ToInt32(row.Cells["id"].Value);

                    Cobros servicio = new Cobros();
                    DataTable vencimientos = servicio.ListarCuotasPorPagar();

                    DataView dv = vencimientos.DefaultView;
                    dv.RowFilter = $"id = {idSocio}";

                    if (dv.Count > 0)
                    {
                        FrmCobroCuota frmCobros = new FrmCobroCuota(idSocio);
                        frmCobros.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Este socio no tiene cuotas pendientes", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    int idNoSocio = Convert.ToInt32(row.Cells["id"].Value);
                    FrmCobroActividad frmCobros = new FrmCobroActividad(idNoSocio);
                    frmCobros.ShowDialog();
                }
            }
        }

        private void MenuInhabilitar_Click(object? sender, EventArgs e)
        {
            var row = dataGridBusqueda.CurrentRow;
            if (row != null)
            {
                MessageBox.Show("Funcionalidad 'Inhabilitar' - ¡PRÓXIMAMENTE!",
                                    "En Desarrollo",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
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