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
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            // Cada vez que el usuario cambia la fecha, actualizamos la grilla
            CargarVencimientos();
        }

        private void CargarVencimientos()
        {
            try
            {
                // Obtenemos la fecha seleccionada en el DateTimePicker
                DateTime fechaSeleccionada = dtpFecha.Value;

                
                DataTable dt = cobrosService.ListarVencimientosPorFecha(fechaSeleccionada);

                // Asignamos el resultado a la grilla
                dgvVencimientos.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los vencimientos: " + ex.Message,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
    }
}