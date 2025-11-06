using ClubDeportivo.Forms;
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

namespace ClubDeportivo
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
            toolStripUser.Text = "Usuario: " + SesionUsuario.Usuario;
            toolStripRol.Text = "Rol: " +SesionUsuario.Rol; 
            toolStripDateTime.Text = "Fecha y Hora de Inicio: " + SesionUsuario.FechaLogin;
        }

        private void btnRegistrarPersona_Click(object sender, EventArgs e)
        {
            FrmRegistro frmAltas = new FrmRegistro();
            frmAltas.ShowDialog();
        }

        // dejo los botones q todavia no pidieron sin funcionalidad. 
        private void btnListarVencimientos_Click(object sender, EventArgs e)
        {
            //el cartel de proximamente lo dejo comentado por las dudas, y lo reemplazo con la nueva funcionalidad

            //MessageBox.Show("Funcionalidad 'Listar Vencimientos' - ¡PRÓXIMAMENTE!",
            //"En Desarrollo",
            //MessageBoxButtons.OK,
            //MessageBoxIcon.Information);

            //

            FrmVencimientos frmVencimientos = new FrmVencimientos();
            frmVencimientos.ShowDialog();
        }

        private void btnGenerarCuotas_Click(object sender, EventArgs e)
        {
            FrmGenerarCuotas frmGenerarCuotas = new FrmGenerarCuotas();
            frmGenerarCuotas.ShowDialog();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FrmBusqueda frmBusqueda = new FrmBusqueda();
            frmBusqueda.ShowDialog();
        }
    }
}
