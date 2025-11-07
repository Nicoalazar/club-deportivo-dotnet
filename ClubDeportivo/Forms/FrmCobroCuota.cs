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
    public partial class FrmCobroCuota : Form
    {
        public string periodo = "";
        public string medio = "";
        private readonly int idSocio;
        Cobros servicio = new Cobros();

        public FrmCobroCuota(int idSocio)
        {
            InitializeComponent();
            this.idSocio = idSocio;
            CargarVencimientos();
            CargarMediosPago();
        }

        private void CargarVencimientos()
        {
            try
            {
                DataTable vencimientos = servicio.ListarCuotasPorPagar();

                DataView dv = vencimientos.DefaultView;
                dv.RowFilter = $"id = {idSocio}";
                DataTable vencimientosFiltrados = dv.ToTable();

                cmbBoxPeriodo.DataSource = vencimientos;
                cmbBoxPeriodo.DisplayMember = "periodo";
                cmbBoxPeriodo.ValueMember = "periodo";
                cmbBoxPeriodo.SelectedIndex = -1; // Iniciar sin selección
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar vencimientos: " + ex.Message,
                               "Error",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
        }
        private void CargarMediosPago()
        {
            try
            {
                DataTable medios = servicio.ListarMediosPago();

                cmbBoxMedio.DataSource = medios;
                cmbBoxMedio.DisplayMember = "medio";
                cmbBoxMedio.ValueMember = "medio";
                cmbBoxMedio.SelectedIndex = -1; // Iniciar sin selección
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar medios de pago: " + ex.Message,
                               "Error",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            if (cmbBoxMedio.SelectedIndex == -1 || cmbBoxPeriodo.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar el periodo y un medio de pago",
                               "Validación",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);
                return;
            }

            servicio.RegistrarPagoCuota(idSocio, periodo, medio);
            this.Close();
        }

        private void cmbBoxPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBoxPeriodo.SelectedIndex != -1)
            {
                periodo = cmbBoxPeriodo.Text;
            }
        }

        private void cmbBoxMedio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBoxMedio.SelectedIndex != -1)
            {
                medio = cmbBoxMedio.Text;
            }
        }

        private void FrmCobroCuota_Load(object sender, EventArgs e)
        {
            if (cmbBoxPeriodo.Items.Count > 0)
                cmbBoxPeriodo.SelectedIndex = 0;
        }
    }
}
