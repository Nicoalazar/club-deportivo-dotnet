using ClubDeportivo.Services;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using ClubDeportivo.Models;

namespace ClubDeportivo.Forms
{
    public partial class FrmCobroCuota : Form
    {
        public string periodo = "";
        public string medio = "";
        private int idSocio;

        public FrmCobroCuota(int idSocio)
        {
            InitializeComponent();
            this.idSocio = idSocio;
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
            periodo = cmbBoxPeriodo.Text;
        }

        private void cmbBoxMedio_SelectedIndexChanged(object sender, EventArgs e)
        {
            medio = cmbBoxMedio.Text;
        }
    }
}
