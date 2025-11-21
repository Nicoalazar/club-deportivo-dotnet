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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            btnSearch = new Button();
            btnLimpiar = new Button();
            txtDni = new TextBox();
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            lblNombre = new Label();
            lblApellido = new Label();
            lblDni = new Label();
            dataGridBusqueda = new DataGridView();
            lblTipo = new Label();
            cmbBoxTipo = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridBusqueda).BeginInit();
            SuspendLayout();
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(464, 52);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 6;
            btnSearch.Text = "Buscar";
            btnSearch.Click += btnSearch_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(545, 52);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(75, 23);
            btnLimpiar.TabIndex = 7;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // txtDni
            // 
            txtDni.Location = new Point(335, 53);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(94, 23);
            txtDni.TabIndex = 5;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(220, 17);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(150, 23);
            txtNombre.TabIndex = 1;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(470, 17);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(150, 23);
            txtApellido.TabIndex = 3;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(148, 20);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(54, 15);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre:";
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(396, 20);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(54, 15);
            lblApellido.TabIndex = 2;
            lblApellido.Text = "Apellido:";
            // 
            // lblDni
            // 
            lblDni.AutoSize = true;
            lblDni.Location = new Point(299, 56);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(30, 15);
            lblDni.TabIndex = 4;
            lblDni.Text = "Nro:";
            // 
            // dataGridBusqueda
            // 
            dataGridBusqueda.AllowUserToAddRows = false;
            dataGridBusqueda.AllowUserToDeleteRows = false;
            dataGridBusqueda.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridBusqueda.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridBusqueda.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridBusqueda.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridBusqueda.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridBusqueda.Location = new Point(10, 100);
            dataGridBusqueda.Name = "dataGridBusqueda";
            dataGridBusqueda.ReadOnly = true;
            dataGridBusqueda.Size = new Size(780, 300);
            dataGridBusqueda.TabIndex = 8;
            // 
            // lblTipo
            // 
            lblTipo.AutoSize = true;
            lblTipo.Location = new Point(148, 56);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(31, 15);
            lblTipo.TabIndex = 9;
            lblTipo.Text = "Tipo";
            // 
            // cmbBoxTipo
            // 
            cmbBoxTipo.FormattingEnabled = true;
            cmbBoxTipo.Location = new Point(185, 53);
            cmbBoxTipo.Name = "cmbBoxTipo";
            cmbBoxTipo.Size = new Size(98, 23);
            cmbBoxTipo.TabIndex = 10;
            // 
            // FrmBusqueda
            // 
            AcceptButton = btnSearch;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cmbBoxTipo);
            Controls.Add(lblTipo);
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
            Load += FrmBusqueda_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridBusqueda).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        // *** DECLARACIÓN DE VARIABLES ***
        private Button btnSearch;
        private Button btnLimpiar;
        private TextBox txtDni;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private Label lblNombre;
        private Label lblApellido;
        private Label lblDni;
        private DataGridView dataGridBusqueda;
        private Label lblTipo;
        private ComboBox cmbBoxTipo;
        // ******************************************************
    }
}