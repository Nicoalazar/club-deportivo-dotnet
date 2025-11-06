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
        public FrmPrincipal(string user, string role)
        {
            InitializeComponent();
            toolStripUser.Text = "Usuario: " + user;
            toolStripRol.Text = "Rol: " + role; 
            toolStripDateTime.Text = "Fecha y Hora de Inicio: " + DateTime.Now.ToString("G");
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

            FrmVencimientos frmVencimientos = new FrmVencimientos();
            frmVencimientos.ShowDialog();
        }

        private void btnRevisarAsistencia_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcionalidad 'Revisar Asistencia' - ¡PRÓXIMAMENTE!",
                "En Desarrollo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FrmBusqueda frmBusqueda = new FrmBusqueda();
            frmBusqueda.ShowDialog();
        }
    }
}
