namespace ClubDeportivo
{
    partial class FrmBusqueda
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            btnSearch = new Button();
            btnLimpiar = new Button();
            txtDni = new TextBox();
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            lblNombre = new Label();
            lblApellido = new Label();
            lblDni = new Label();
            dataGridBusqueda = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridBusqueda).BeginInit();
            SuspendLayout();
            // 
            // lblNombre
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(180, 20);
            lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            txtNombre.Location = new Point(240, 17);
            txtNombre.Size = new Size(150, 23);
            // 
            // lblApellido
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(410, 20);
            lblApellido.Text = "Apellido:";
            // 
            // txtApellido
            txtApellido.Location = new Point(470, 17);
            txtApellido.Size = new Size(150, 23);
            // 
            // lblDni
            lblDni.AutoSize = true;
            lblDni.Location = new Point(180, 60);
            lblDni.Text = "DNI:";
            // 
            // txtDni
            txtDni.Location = new Point(240, 57);
            txtDni.Size = new Size(150, 23);
            // 
            // btnSearch
            btnSearch.Location = new Point(410, 57);
            btnSearch.Size = new Size(75, 23);
            btnSearch.Text = "Buscar";
            btnSearch.Click += btnSearch_Click;
            // 
            // btnLimpiar
            btnLimpiar.Location = new Point(490, 57);
            btnLimpiar.Size = new Size(75, 23);
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // dataGridBusqueda
            dataGridBusqueda.Location = new Point(180, 100);
            dataGridBusqueda.Size = new Size(600, 300);
            dataGridBusqueda.ReadOnly = true;
            dataGridBusqueda.AllowUserToAddRows = false;
            dataGridBusqueda.AllowUserToDeleteRows = false;
            // 
            // FrmBusqueda
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblNombre);
            Controls.Add(txtNombre);
            Controls.Add(lblApellido);
            Controls.Add(txtApellido);
            Controls.Add(lblDni);
            Controls.Add(txtDni);
            Controls.Add(btnSearch);
            Controls.Add(btnLimpiar);
            Controls.Add(dataGridBusqueda);
            Name = "FrmBusqueda";
            Text = "Búsqueda de Personas";
            ((System.ComponentModel.ISupportInitialize)dataGridBusqueda).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSearch;
        private Button btnLimpiar;
        private TextBox txtDni;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private Label lblNombre;
        private Label lblApellido;
        private Label lblDni;
        private DataGridView dataGridBusqueda;
    }
}

