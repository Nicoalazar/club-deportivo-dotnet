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
            toolStripUser.Text = "Usuario: " + TextHelper.ToUpperCase(SesionUsuario.Usuario!);
            toolStripRol.Text = "Rol: " + TextHelper.ToUpperCase(SesionUsuario.Rol!); 
            toolStripDateTime.Text = "Fecha y Hora de Inicio: " + SesionUsuario.FechaLogin;

            // Control de permisos
            if (!SesionUsuario.Rol!.Equals("Administrador", StringComparison.OrdinalIgnoreCase))
            {
                btnGenerarCuotas.Enabled = false;
                btnGenerarCuotas.AutoSize = true;
                btnGenerarCuotas.Text = "Generar Cuotas\n(Solo Administradores)";

            }
        }

        private void btnRegistrarPersona_Click(object sender, EventArgs e)
        {
            FrmRegistro frmAltas = new FrmRegistro();
            frmAltas.ShowDialog();
        }

        private void btnListarVencimientos_Click(object sender, EventArgs e)
        {

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
