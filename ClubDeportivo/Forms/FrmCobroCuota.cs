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
                Cobros servicio = new Cobros();
                DataTable vencimientos = servicio.ListarVencimientos();

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
                MessageBox.Show("Error al cargar vencimientos: " + ex.Message);
            }
        }
        private void CargarMediosPago()
        {
            try
            {
            Cobros servicio = new Cobros();
            DataTable medios = servicio.ListarMediosPago();

            cmbBoxMedio.DataSource = medios;
            cmbBoxMedio.DisplayMember = "medio";
            cmbBoxMedio.ValueMember = "medio";
            cmbBoxMedio.SelectedIndex = -1; // Iniciar sin selección
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar medios de pago: " + ex.Message);
            }
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(periodo) || string.IsNullOrEmpty(medio))
            {
                MessageBox.Show("Debe seleccionar un período y un medio de pago");
                return;
            }
            try {
                using var cn = Conexion.getInstancia().CrearConcexion();
                cn.Open();

                using var cmd = new MySqlCommand("sp_pago_cuota", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_id_socio", MySqlDbType.Int32).Value = idSocio;
                cmd.Parameters.Add("p_periodo", MySqlDbType.VarChar).Value = periodo;
                cmd.Parameters.Add("p_medio", MySqlDbType.VarChar).Value = medio;
                cmd.Parameters.Add("p_usuario", MySqlDbType.VarChar).Value = SesionUsuario.Usuario;
                cmd.ExecuteNonQuery();

                MessageBox.Show("Pago registrado correctamente");
                this.Close();
            }
            catch (Exception ex) { 
                MessageBox.Show("Error"+ ex);
            }
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
            medio = cmbBoxMedio.Text;
        }
    }
}
