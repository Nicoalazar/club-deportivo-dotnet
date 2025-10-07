namespace ClubDeportivo
{
    partial class FrmPrimerProyecto
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer? components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblNombre = new Label();
            lblApellido = new Label();
            lblTipo = new Label();
            lblDocumento = new Label();
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            cmbTipo = new ComboBox();
            txtDocumento = new TextBox();
            btnIngresar = new Button();
            btnLimpiar = new Button();
            dgvPostulantes = new DataGridView();
            colNombre = new DataGridViewTextBoxColumn();
            colApellido = new DataGridViewTextBoxColumn();
            colTipo = new DataGridViewTextBoxColumn();
            colDocumento = new DataGridViewTextBoxColumn();
            checkSocio = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)dgvPostulantes).BeginInit();
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(21, 18);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(51, 15);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre";
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(21, 48);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(51, 15);
            lblApellido.TabIndex = 2;
            lblApellido.Text = "Apellido";
            // 
            // lblTipo
            // 
            lblTipo.AutoSize = true;
            lblTipo.Location = new Point(21, 78);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(96, 15);
            lblTipo.TabIndex = 4;
            lblTipo.Text = "Tipo documento";
            // 
            // lblDocumento
            // 
            lblDocumento.AutoSize = true;
            lblDocumento.Location = new Point(21, 108);
            lblDocumento.Name = "lblDocumento";
            lblDocumento.Size = new Size(70, 15);
            lblDocumento.TabIndex = 6;
            lblDocumento.Text = "Documento";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(140, 15);
            txtNombre.Margin = new Padding(3, 2, 3, 2);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(219, 23);
            txtNombre.TabIndex = 1;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(140, 45);
            txtApellido.Margin = new Padding(3, 2, 3, 2);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(219, 23);
            txtApellido.TabIndex = 3;
            // 
            // cmbTipo
            // 
            cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipo.FormattingEnabled = true;
            cmbTipo.Location = new Point(140, 75);
            cmbTipo.Margin = new Padding(3, 2, 3, 2);
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Size = new Size(219, 23);
            cmbTipo.TabIndex = 5;
            // 
            // txtDocumento
            // 
            txtDocumento.Location = new Point(140, 105);
            txtDocumento.Margin = new Padding(3, 2, 3, 2);
            txtDocumento.Name = "txtDocumento";
            txtDocumento.Size = new Size(219, 23);
            txtDocumento.TabIndex = 7;
            // 
            // btnIngresar
            // 
            btnIngresar.Location = new Point(385, 15);
            btnIngresar.Margin = new Padding(3, 2, 3, 2);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(98, 30);
            btnIngresar.TabIndex = 8;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = true;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(385, 54);
            btnLimpiar.Margin = new Padding(3, 2, 3, 2);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(98, 30);
            btnLimpiar.TabIndex = 9;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // dgvPostulantes
            // 
            dgvPostulantes.AllowUserToAddRows = false;
            dgvPostulantes.AllowUserToDeleteRows = false;
            dgvPostulantes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPostulantes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPostulantes.Columns.AddRange(new DataGridViewColumn[] { colNombre, colApellido, colTipo, colDocumento });
            dgvPostulantes.Location = new Point(21, 147);
            dgvPostulantes.Margin = new Padding(3, 2, 3, 2);
            dgvPostulantes.MultiSelect = false;
            dgvPostulantes.Name = "dgvPostulantes";
            dgvPostulantes.ReadOnly = true;
            dgvPostulantes.RowHeadersVisible = false;
            dgvPostulantes.RowTemplate.Height = 29;
            dgvPostulantes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPostulantes.Size = new Size(462, 165);
            dgvPostulantes.TabIndex = 10;
            // 
            // colNombre
            // 
            colNombre.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colNombre.DataPropertyName = "Nombre";
            colNombre.HeaderText = "Nombre";
            colNombre.Name = "colNombre";
            colNombre.ReadOnly = true;
            // 
            // colApellido
            // 
            colApellido.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colApellido.DataPropertyName = "Apellido";
            colApellido.HeaderText = "Apellido";
            colApellido.Name = "colApellido";
            colApellido.ReadOnly = true;
            // 
            // colTipo
            // 
            colTipo.DataPropertyName = "Tipo";
            colTipo.HeaderText = "Tipo";
            colTipo.Name = "colTipo";
            colTipo.ReadOnly = true;
            colTipo.Width = 120;
            // 
            // colDocumento
            // 
            colDocumento.DataPropertyName = "Documento";
            colDocumento.HeaderText = "Documento";
            colDocumento.Name = "colDocumento";
            colDocumento.ReadOnly = true;
            colDocumento.Width = 150;
            // 
            // checkSocio
            // 
            checkSocio.AutoSize = true;
            checkSocio.Location = new Point(404, 109);
            checkSocio.Name = "checkSocio";
            checkSocio.Size = new Size(55, 19);
            checkSocio.TabIndex = 11;
            checkSocio.Text = "Socio";
            checkSocio.UseVisualStyleBackColor = true;
            checkSocio.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // FrmPrimerProyecto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(504, 330);
            Controls.Add(checkSocio);
            Controls.Add(dgvPostulantes);
            Controls.Add(btnLimpiar);
            Controls.Add(btnIngresar);
            Controls.Add(txtDocumento);
            Controls.Add(cmbTipo);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            Controls.Add(lblDocumento);
            Controls.Add(lblTipo);
            Controls.Add(lblApellido);
            Controls.Add(lblNombre);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FrmPrimerProyecto";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registro de postulantes";
            Load += FrmPrimerProyecto_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPostulantes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label lblDocumento;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.DataGridView dgvPostulantes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colApellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDocumento;
        private CheckBox checkSocio;
    }
}
