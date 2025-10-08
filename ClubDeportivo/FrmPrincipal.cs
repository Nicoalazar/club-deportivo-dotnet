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
        }

        private void btnRegistrarPersona_Click(object sender, EventArgs e)
        {
            FrmPrimerProyecto frmAltas = new FrmPrimerProyecto();
            frmAltas.ShowDialog();
        }

        // dejo los botones q todavia no pidieron sin funcionalidad. 
        private void btnListarVencimientos_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcionalidad 'Listar Vencimientos' - ¡PRÓXIMAMENTE!",
                    "En Desarrollo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }

        private void btnRevisarAsistencia_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcionalidad 'Revisar Asistencia' - ¡PRÓXIMAMENTE!",
                "En Desarrollo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnPrueba_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcionalidad 'Prueba' - ¡PRÓXIMAMENTE!",
                "En Desarrollo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}
