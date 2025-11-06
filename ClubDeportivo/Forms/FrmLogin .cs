using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using ClubDeportivo.Services;

namespace ClubDeportivo
{
    public partial class FrmLogin : Form
    {
        Usuario Usuario = new Usuario();
        public FrmLogin()
        {
            InitializeComponent();
        }
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            DataTable tablaLogin = new DataTable(); // es la que recibe los  datos desde el formulario
            Usuario dato = new Usuario(); // variable que contiene todas las caracteristicas de la clase
            tablaLogin = dato.Log_Usu(txtUsuario.Text, txtClave.Text);
            if (tablaLogin.Rows.Count > 0)
            {
                string user = tablaLogin.Rows[0]["NombreUsu"].ToString()!;
                string role = tablaLogin.Rows[0]["NomRol"].ToString()!;

                SesionUsuario.IniciarSesion(user, role);
                var frmPrincipal = new FrmPrincipal(); 
                frmPrincipal.Show();
                this.Hide();
                frmPrincipal.FormClosed += (s, args) => this.Close();
            }
            else
            {
                MessageBox.Show("Usuario y/o password incorrecto");
            }
        }
    }
}
