using MySql.Data.MySqlClient;
using System.ComponentModel;

namespace ClubDeportivo
{
    public partial class FrmBusqueda : Form
    {
        private readonly BindingList<Persona> _persona = new();
        public FrmBusqueda()
        {
            InitializeComponent();
            dataGridBusqueda.AutoGenerateColumns = true;
            dataGridBusqueda.DataSource = _persona;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string documento = txtDni.Text.Trim();

            using var cn = Conexion.getInstancia().CrearConcexion();
            cn.Open();

            using var cmd = new MySqlCommand(
                "SELECT * FROM personas WHERE documento = @d;", cn); //TODO: mejorar consulta
            cmd.Parameters.Add("@d", MySqlDbType.VarChar).Value = documento;

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                Persona persona = new Persona
                {
                    Nombre = reader.GetString("nombre"),
                    Apellido = reader.GetString("apellido"),
                    Tipo = reader.GetString("tipo"),
                    Documento = reader.GetString("documento")
                };

                _persona.Clear();  // limpia resultados anteriores
                _persona.Add(persona);

                MessageBox.Show("La persona existe en la base de datos.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se encontró ninguna persona con ese documento.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}
