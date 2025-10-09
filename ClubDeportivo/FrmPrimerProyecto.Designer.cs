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
            dgvPersona = new DataGridView();
            colNombre = new DataGridViewTextBoxColumn();
            colApellido = new DataGridViewTextBoxColumn();
            colTipo = new DataGridViewTextBoxColumn();
            colDocumento = new DataGridViewTextBoxColumn();
            colTelefono = new DataGridViewTextBoxColumn();
            colEmail = new DataGridViewTextBoxColumn();
            lblTelefono = new Label();
            txtTelefono = new TextBox();
            txtEmail = new TextBox();
            lblEmail = new Label();
            checkSocio = new CheckBox();
            cmbSexo = new ComboBox();
            Sexo = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvPersona).BeginInit();
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
            lblTipo.Location = new Point(21, 109);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(96, 15);
            lblTipo.TabIndex = 4;
            lblTipo.Text = "Tipo documento";
            // 
            // lblDocumento
            // 
            lblDocumento.AutoSize = true;
            lblDocumento.Location = new Point(21, 136);
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
            cmbTipo.Location = new Point(140, 101);
            cmbTipo.Margin = new Padding(3, 2, 3, 2);
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Size = new Size(219, 23);
            cmbTipo.TabIndex = 5;
            // 
            // txtDocumento
            // 
            txtDocumento.Location = new Point(140, 128);
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
            btnLimpiar.Location = new Point(385, 63);
            btnLimpiar.Margin = new Padding(3, 2, 3, 2);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(98, 30);
            btnLimpiar.TabIndex = 9;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // dgvPersona
            // 
            dgvPersona.AllowUserToAddRows = false;
            dgvPersona.AllowUserToDeleteRows = false;
            dgvPersona.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPersona.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPersona.Columns.AddRange(new DataGridViewColumn[] { colNombre, colApellido, colTipo, colDocumento, colTelefono, colEmail });
            dgvPersona.Location = new Point(21, 207);
            dgvPersona.Margin = new Padding(3, 2, 3, 2);
            dgvPersona.MultiSelect = false;
            dgvPersona.Name = "dgvPersona";
            dgvPersona.ReadOnly = true;
            dgvPersona.RowHeadersVisible = false;
            dgvPersona.RowTemplate.Height = 29;
            dgvPersona.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPersona.Size = new Size(529, 102);
            dgvPersona.TabIndex = 10;
            // 
            // colNombre
            // 
            colNombre.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            colNombre.DataPropertyName = "Nombre";
            colNombre.HeaderText = "Nombre";
            colNombre.Name = "colNombre";
            colNombre.ReadOnly = true;
            colNombre.Width = 76;
            // 
            // colApellido
            // 
            colApellido.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            colApellido.DataPropertyName = "Apellido";
            colApellido.HeaderText = "Apellido";
            colApellido.Name = "colApellido";
            colApellido.ReadOnly = true;
            colApellido.Width = 76;
            // 
            // colTipo
            // 
            colTipo.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            colTipo.DataPropertyName = "Tipo";
            colTipo.HeaderText = "Tipo";
            colTipo.Name = "colTipo";
            colTipo.ReadOnly = true;
            colTipo.Width = 56;
            // 
            // colDocumento
            // 
            colDocumento.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            colDocumento.DataPropertyName = "Documento";
            colDocumento.HeaderText = "Documento";
            colDocumento.Name = "colDocumento";
            colDocumento.ReadOnly = true;
            colDocumento.Width = 95;
            // 
            // colTelefono
            // 
            colTelefono.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            colTelefono.DataPropertyName = "Telefono";
            colTelefono.HeaderText = "Teléfono";
            colTelefono.Name = "colTelefono";
            colTelefono.ReadOnly = true;
            colTelefono.Width = 78;
            // 
            // colEmail
            // 
            colEmail.DataPropertyName = "Email";
            colEmail.HeaderText = "E-mail";
            colEmail.Name = "colEmail";
            colEmail.ReadOnly = true;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(21, 164);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(53, 15);
            lblTelefono.TabIndex = 11;
            lblTelefono.Text = "Teléfono";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(80, 156);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(163, 23);
            txtTelefono.TabIndex = 12;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(293, 156);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(190, 23);
            txtEmail.TabIndex = 13;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(249, 164);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(41, 15);
            lblEmail.TabIndex = 14;
            lblEmail.Text = "E-mail";
            // 
            // checkSocio
            // 
            checkSocio.AutoSize = true;
            checkSocio.Location = new Point(400, 101);
            checkSocio.Name = "checkSocio";
            checkSocio.Size = new Size(55, 19);
            checkSocio.TabIndex = 15;
            checkSocio.Text = "Socio";
            checkSocio.UseVisualStyleBackColor = true;
            // 
            // cmbSexo
            // 
            cmbSexo.FormattingEnabled = true;
            cmbSexo.Location = new Point(140, 73);
            cmbSexo.Name = "cmbSexo";
            cmbSexo.Size = new Size(219, 23);
            cmbSexo.TabIndex = 16;
            // 
            // Sexo
            // 
            Sexo.AutoSize = true;
            Sexo.Location = new Point(21, 81);
            Sexo.Name = "Sexo";
            Sexo.Size = new Size(31, 15);
            Sexo.TabIndex = 17;
            Sexo.Text = "Sexo";
            // 
            // FrmPrimerProyecto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(571, 330);
            Controls.Add(Sexo);
            Controls.Add(cmbSexo);
            Controls.Add(checkSocio);
            Controls.Add(lblEmail);
            Controls.Add(txtEmail);
            Controls.Add(txtTelefono);
            Controls.Add(lblTelefono);
            Controls.Add(dgvPersona);
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
            Text = "Registro de persona";
            Load += FrmPrimerProyecto_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPersona).EndInit();
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
        private System.Windows.Forms.DataGridView dgvPersona;
        private Label lblTelefono;
        private TextBox txtTelefono;
        private TextBox txtEmail;
        private Label lblEmail;
        private DataGridViewTextBoxColumn colNombre;
        private DataGridViewTextBoxColumn colApellido;
        private DataGridViewTextBoxColumn colTipo;
        private DataGridViewTextBoxColumn colDocumento;
        private DataGridViewTextBoxColumn colTelefono;
        private DataGridViewTextBoxColumn colEmail;
        private CheckBox checkSocio;
        private ComboBox cmbSexo;
        private Label Sexo;
    }
}
