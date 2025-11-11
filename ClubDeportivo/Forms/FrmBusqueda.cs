using ClubDeportivo.Config;
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
        private ContextMenuStrip menu;
        Cobros servicio = new Cobros();

        public FrmBusqueda()
        {
            InitializeComponent();
            ValidacionEnTiempoReal();

            dataGridBusqueda.AutoGenerateColumns = true;

            menu = new ContextMenuStrip();
            menu.Items.Add("Editar Persona", null, MenuEditar_Click);
            menu.Items.Add("Actualizar Apto Físico", null, MenuApto_Click);
            menu.Items.Add("Cobrar", null, MenuCobrar_Click);
            menu.Items.Add("Generar Carnet", null, MenuCarnet_Click);
            menu.Items.Add("Inhabilitar", null, MenuInhabilitar_Click);
            menu.Items.Add(new ToolStripSeparator());
            menu.Items.Add("Cancelar", null, MenuCancelar_Click);

            dataGridBusqueda.ContextMenuStrip = menu;
            dataGridBusqueda.CellMouseDown += DataGridBusqueda_CellMouseDown;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dataGridBusqueda.DataSource = null;

            string nombre = txtNombre.Text.Trim();
            string apellido = txtApellido.Text.Trim();
            string documento = TextHelper.ToUpperCase(txtDni.Text);
            string tipoDoc = cmbBoxTipo.SelectedItem!.ToString()!;

            // *** VALIDACIONES ***
            // Valida según tipo de documento
            if (!string.IsNullOrEmpty(documento))
            {
                if (tipoDoc == "DNI")
                {
                    // DNI: solo números, 7 u 8 dígitos
                    if (!Regex.IsMatch(documento, @"^\d{7,8}$"))
                    {
                        MessageBox.Show("El DNI debe contener solo números y tener 7 u 8 dígitos.",
                                      "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtDni.Focus();
                        return;
                    }
                }
                else if (tipoDoc == "Pasaporte")
                {

                    // Pasaporte: letras y números, 6 a 10 caracteres
                    if (!Regex.IsMatch(documento, @"^[A-Z0-9]{6,10}$"))
                    {
                        MessageBox.Show("El Pasaporte debe contener solo letras y números, entre 6 y 10 caracteres.",
                                      "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtDni.Focus();
                        return;
                    }
                }
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

                using var cn = Conexion.getInstancia().CrearConexion();
                cn.Open();

                using var cmd = new MySqlCommand("sp_persona_search", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_nombres", paramNombre);
                cmd.Parameters.AddWithValue("p_apellidos", paramApellido);
                cmd.Parameters.AddWithValue("p_nro_documento", paramDocumento);

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
            cmbBoxTipo.SelectedItem = "DNI";

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

        private void MenuApto_Click(object? sender, EventArgs e)
        {
            var row = dataGridBusqueda.CurrentRow;
            if (row != null)
            {
                string categoria = row.Cells["Categoría"].Value.ToString()!;

                if (categoria == "Socio")
                {
                    int idSocio = Convert.ToInt32(row.Cells["Id"].Value);

                    if (!servicio.RenovarAptoFisico(idSocio, true)) return;
                }
                else
                {

                    int idNoSocio = Convert.ToInt32(row.Cells["Id"].Value);

                    if (!servicio.RenovarAptoFisico(idNoSocio, false)) return;
                }
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
                int idSocio = Convert.ToInt32(row.Cells["Id"].Value);

                var socio = new Socio(
                    persona,
                    idSocio,
                    Convert.ToDateTime(row.Cells["VtoAptoFisico"].Value).Date,
                    Convert.ToDateTime(row.Cells["FechaAlta"].Value).Date,
                    DateTime.Now,
                    row.Cells["estado"].Value.ToString()!
                    );

                if (socio.VtoAptoFisico < DateTime.Now.Date)
                {
                    DialogResult resultado = MessageBox.Show(
                       "No se puede generar Carnet si tiene apto Fisico Vencido \n\n ¿Renovar?",
                       "Aviso",
                       MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question,
                       MessageBoxDefaultButton.Button1 // Botón "Sí" seleccionado por defecto
                       );

                    if (resultado == DialogResult.Yes)
                    {
                        if (servicio.RenovarAptoFisico(idSocio, true)) {
                            socio = new Socio(
                                persona,
                                idSocio,
                                DateTime.Now.AddYears(1),
                                Convert.ToDateTime(row.Cells["FechaAlta"].Value).Date,
                                DateTime.Now,
                                row.Cells["estado"].Value.ToString()!
                            );
                        }
                        else return;
                    }
                }

                DataTable cuotasVencidas = servicio.ListarCuotasVencidas();
                DataView dv = cuotasVencidas.DefaultView;
                dv.RowFilter = $"id = {idSocio}";

                if (dv.Count > 0)
                {
                    DialogResult resultado = MessageBox.Show(
                       "No se puede generar Carnet si tiene cuotas vencidas \n\n ¿Cobrar ahora?",
                       "Aviso",
                       MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question,
                       MessageBoxDefaultButton.Button1 // Botón "Sí" seleccionado por defecto
                       );

                    if (resultado == DialogResult.Yes)
                    {
                        FrmCobroCuota frmCobros = new FrmCobroCuota(idSocio);
                        frmCobros.ShowDialog();

                        cuotasVencidas = servicio.ListarCuotasVencidas();
                        dv = cuotasVencidas.DefaultView;
                        dv.RowFilter = $"id = {idSocio}";

                        // Verificar nuevamente si ya no tiene cuotas vencidas
                        if (dv.Count == 0)
                        {
                            // Ahora sí puede imprimir el carnet
                            new SocioCarnetPrinter(socio).Imprimir();
                        }
                        else
                        {
                            DialogResult retry = MessageBox.Show(
                                "Aún quedan cuotas vencidas pendientes.\n\n¿Desea realizar otro pago?",
                                "Aviso",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);

                            if (retry == DialogResult.Yes)
                            {
                                // Llamar recursivamente o reabrir el formulario
                                MenuCarnet_Click(sender, e);
                            }
                        }
                    }
                }
                else
                {
                    new SocioCarnetPrinter(socio).Imprimir();
                }

            }
            else
            {
                int idNoSocio = Convert.ToInt32(row.Cells["Id"].Value);

                var noSocio = new NoSocio(
                   persona,
                   Convert.ToDateTime(row.Cells["VtoAptoFisico"].Value).Date,
                   row.Cells["estado"].Value.ToString()!,
                   "",
                   Convert.ToDateTime(row.Cells["FechaAlta"].Value).Date
                   );

                if (noSocio.VtoAptoFisico < DateTime.Now.Date)
                {
                    DialogResult resultado = MessageBox.Show(
                       "No se puede generar Carnet si tiene apto Fisico Vencido \n\n ¿Renovar?",
                       "Aviso",
                       MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question,
                       MessageBoxDefaultButton.Button1 // Botón "Sí" seleccionado por defecto
                       );

                    if (resultado == DialogResult.Yes)
                    {
                        if(servicio.RenovarAptoFisico(idNoSocio, false))
                        {
                            noSocio = new NoSocio(
                               persona,
                               DateTime.Now.AddYears(1),
                               row.Cells["estado"].Value.ToString()!,
                               "",
                               Convert.ToDateTime(row.Cells["FechaAlta"].Value).Date
                               );
                            new NoSocioCarnetPrinter(noSocio).Imprimir();
                        }
                        else return ; 
                    }
                }
            }
        }

        private void MenuCancelar_Click(object? sender, EventArgs e)
        {
            dataGridBusqueda.ClearSelection();
        }

        private void FrmBusqueda_Load(object sender, EventArgs e)
        {
            if (cmbBoxTipo.Items.Count == 0)
            {
                cmbBoxTipo.Items.AddRange(new object[] { "DNI", "Pasaporte" });
            }

            if (cmbBoxTipo.Items.Count > 0 && cmbBoxTipo.SelectedIndex < 0)
            {
                cmbBoxTipo.SelectedIndex = 0;
            }
        }

        private void ValidacionEnTiempoReal()
        {
            //Solo admite numeros para documento y letras para pasaporte
            txtDni.KeyPress += (s, e) =>
            {
                bool esPasaporte = cmbBoxTipo.SelectedItem?.ToString() == "Pasaporte";

                if (esPasaporte)
                {
                    // Pasaporte: acepta letras, números y algunos caracteres especiales
                    if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                }
                else
                {
                    // DNI: solo números
                    if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                }
            };

            cmbBoxTipo.SelectedIndexChanged += (s, e) =>
            {
                // Limpiar el campo cuando cambia el tipo de documento
                txtDni.Clear();
                txtDni.Focus();
            };

            //Solo admite letras para el campo nombre
            txtNombre.KeyPress += (s, e) =>
            {
                if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
                {
                    e.Handled = true;
                }
            };

            //Solo admite letras para el campo apellido
            txtApellido.KeyPress += (s, e) =>
            {
                if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
                {
                    e.Handled = true;
                }
            };
        }
    }
}