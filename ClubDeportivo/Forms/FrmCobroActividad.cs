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

namespace ClubDeportivo.Forms
{
    public partial class FrmCobroActividad : Form
    {
        Cobros servicio = new Cobros();
        public string medio = "";
        public DateTime fecha = DateTime.Now;
        public double monto = 0;
        private readonly int idNoSocio;

        public FrmCobroActividad(int idNoSocio)
        {
            InitializeComponent();
            this.idNoSocio = idNoSocio;
            CargarMediosPago();
        }

        private void CargarMediosPago()
        {
            try
            {
                DataTable medios = servicio.ListarMediosPago();
                cmbBoxMedio.DataSource = medios;
                cmbBoxMedio.DisplayMember = "medio";
                cmbBoxMedio.ValueMember = "medio";
                cmbBoxMedio.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar medios de pago: " + ex.Message);
            }
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            // Validar ANTES de convertir
            if (!ValidarDatos()) return;

            try
            {
                // Obtener valores
                monto = Convert.ToDouble(txtBoxMonto.Text);
                fecha = dateTimePicker1.Value.Date;
                medio = cmbBoxMedio.Text;

                // Registrar pago
                if (servicio.RegistrarPagoActividad(idNoSocio, fecha, monto, medio))
                {
                    this.Close();
                }

            }
            catch (FormatException)
            {
                MessageBox.Show("El monto ingresado no es válido",
                               "Error",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar el pago: {ex.Message}",
                               "Error",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
        }

        private bool ValidarDatos()
        {
            // Validar monto
            if (string.IsNullOrWhiteSpace(txtBoxMonto.Text))
            {
                MessageBox.Show("Debe ingresar el monto de la actividad",
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

            // Validar medio de pago
            if (cmbBoxMedio.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un medio de pago",
                               "Validación",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);
                cmbBoxMedio.Focus();
                return false;
            }

            // Validar fecha
            if (dateTimePicker1.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("No se puede pagar una actividad del pasado",
                               "Validación",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);
                dateTimePicker1.Focus();
                return false;
            }

            return true;
        }

        private void cmbBoxMedio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBoxMedio.SelectedIndex != -1)
            {
                medio = cmbBoxMedio.Text;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            fecha = dateTimePicker1.Value.Date;
        }

        private void FrmCobroActividad_Load(object sender, EventArgs e)
        {
            txtBoxMonto.Text = ValoresCuotas.MontoActividad.ToString("N2");

        }
    }
}