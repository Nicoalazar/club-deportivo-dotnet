using ClubDeportivo.Services; 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClubDeportivo.Forms
{
    public partial class FrmVencimientos : Form
    {
        // Instanciamos el servicio de Cobros
        private Cobros cobrosService;
        private DataTable? datosCompletos;

        public FrmVencimientos()
        {
            InitializeComponent();
            cobrosService = new Cobros(); // Lo inicializamos en el constructor
        }

        private void FrmVencimientos_Load(object sender, EventArgs e)
        {
            // Al cargar el formulario, buscamos los vencimientos para la fecha actual
            // (que es la que el dtpFecha tiene por defecto)
            CargarVencimientos();
            dgvVencimientos.RowHeadersVisible = false;

        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            // Cada vez que el usuario cambia la fecha, actualizamos la grilla
            CargarVencimientos();
        }
        private void chkPorVencer_CheckedChanged(object sender, EventArgs e)
        {
            CargarVencimientos();
        }
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            ImprimirListado();
        }

        private void CargarVencimientos()
        {
            try
            {
                // Obtenemos la fecha seleccionada en el DateTimePicker
                DateTime fechaSeleccionada = dtpFecha.Value;
                if (chkPorVencer.Checked)
                {
                    datosCompletos = cobrosService.ListarVencimientosPorFecha(fechaSeleccionada, true);
                }
                else
                {
                    datosCompletos = cobrosService.ListarVencimientosPorFecha(fechaSeleccionada, false);
                }

                dgvVencimientos.DataSource = datosCompletos;
                ActualizarContador();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los vencimientos: " + ex.Message,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
        private void ActualizarContador()
        {
            if (dgvVencimientos.DataSource != null)
            {
                int total = dgvVencimientos.Rows.Count;
                string tipo = chkPorVencer.Checked ? "por vencer/vencidas" : "vencidas";
                lblContador.Text = $"Total de cuotas {tipo}: {total}";
            }
        }

        private void ImprimirListado()
        {
            if (datosCompletos == null || datosCompletos.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para imprimir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ListadoPrinter printer = new ListadoPrinter(datosCompletos, dtpFecha.Value, chkPorVencer.Checked);
            printer.Imprimir();

        }
    }
}