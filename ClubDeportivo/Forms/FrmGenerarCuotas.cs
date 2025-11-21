using ClubDeportivo.Config;
using ClubDeportivo.Models;
using ClubDeportivo.Services;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ClubDeportivo.Forms
{
    public partial class FrmGenerarCuotas : Form
    {
        public string periodo = "";
        public double monto = 0;
        Cobros servicio = new Cobros();

        public FrmGenerarCuotas()
        {
            InitializeComponent();

            cmbBoxPeriodo.Items.Clear();

            int añoActual = DateTime.Now.Year;
            int mesActual = DateTime.Now.Month;
            int añoFinal = añoActual + 1; // hasta diciembre del próximo año

            for (int año = añoActual; año <= añoFinal; año++)
            {
                int mesInicio = (año == añoActual) ? mesActual : 1; // si es el año actual, empezar desde el mes actual
                int mesFin = 12;

                for (int mes = mesInicio; mes <= mesFin; mes++)
                {
                    string periodo = $"{año}{mes:D2}"; // ejemplo: 202511
                    cmbBoxPeriodo.Items.Add(periodo);
                }
            }

        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos()) return;
            try
            {
                monto = Convert.ToDouble(txtBoxMonto.Text);
                int cuotasGeneradas = servicio.GenerarCuotas(periodo, monto);

                if (cuotasGeneradas > 0)
                {
                    MessageBox.Show("Cuotas Generadas Correctamente",
                                   "Éxito",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Information);
                    this.Close();
                }
                if (cuotasGeneradas == 0)
                {
                    MessageBox.Show("La cuota ya fue generada anteriormente",
                                   "Validación",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Warning);
                }

            }
            catch (FormatException)
            {
                MessageBox.Show("El monto ingresado no es válido",
                               "Error",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }

        }

        private void cmbBoxPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBoxPeriodo.SelectedIndex != -1)
            {
                periodo = cmbBoxPeriodo.Text;
            }
        }

        private bool ValidarDatos()
        {
            // Validar monto
            if (string.IsNullOrWhiteSpace(txtBoxMonto.Text))
            {
                MessageBox.Show("Debe ingresar el monto de la cuota",
                               "Validación",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);
                txtBoxMonto.Focus();
                return false;
            }

            // Validar que el monto sea numérico
            if (!double.TryParse(txtBoxMonto.Text, out double montoValidado) || montoValidado <= 0)
            {
                MessageBox.Show("El monto debe ser un número mayor a cero",
                               "Validación",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);
                txtBoxMonto.Focus();
                return false;
            }

            if (cmbBoxPeriodo.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un periodo",
                               "Validación",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void FrmGenerarCuotas_Load(object sender, EventArgs e)
        {
            txtBoxMonto.Text = ValoresCuotas.MontoCuota.ToString("N2");

            if (cmbBoxPeriodo.Items.Count > 0)
                cmbBoxPeriodo.SelectedIndex = 0;
        }
    }
}

