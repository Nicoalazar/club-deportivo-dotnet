namespace ClubDeportivo
{
    partial class FrmRegistro
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            lblTelefono = new Label();
            txtTelefono = new TextBox();
            txtEmail = new TextBox();
            lblEmail = new Label();
            checkSocio = new CheckBox();
            cmbSexo = new ComboBox();
            Sexo = new Label();
            checkApto = new CheckBox();
            dateTimePickerNacim = new DateTimePicker();
            lblFechaNac = new Label();
            lblDomicilio = new Label();
            txtDomicilio = new TextBox();
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
            lblApellido.Location = new Point(21, 50);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(51, 15);
            lblApellido.TabIndex = 0;
            lblApellido.Text = "Apellido";
            // 
            // lblTipo
            // 
            lblTipo.AutoSize = true;
            lblTipo.Location = new Point(365, 18);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(95, 15);
            lblTipo.TabIndex = 0;
            lblTipo.Text = "Tipo documento";
            // 
            // lblDocumento
            // 
            lblDocumento.AutoSize = true;
            lblDocumento.Location = new Point(365, 50);
            lblDocumento.Name = "lblDocumento";
            lblDocumento.Size = new Size(70, 15);
            lblDocumento.TabIndex = 0;
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
            txtApellido.Location = new Point(140, 47);
            txtApellido.Margin = new Padding(3, 2, 3, 2);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(219, 23);
            txtApellido.TabIndex = 2;
            // 
            // cmbTipo
            // 
            cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipo.FormattingEnabled = true;
            cmbTipo.Location = new Point(465, 15);
            cmbTipo.Margin = new Padding(3, 2, 3, 2);
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Size = new Size(219, 23);
            cmbTipo.TabIndex = 5;
            // 
            // txtDocumento
            // 
            txtDocumento.Location = new Point(465, 47);
            txtDocumento.Margin = new Padding(3, 2, 3, 2);
            txtDocumento.Name = "txtDocumento";
            txtDocumento.Size = new Size(219, 23);
            txtDocumento.TabIndex = 6;
            // 
            // btnIngresar
            // 
            btnIngresar.Location = new Point(254, 175);
            btnIngresar.Margin = new Padding(3, 2, 3, 2);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(98, 30);
            btnIngresar.TabIndex = 12;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = true;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(365, 175);
            btnLimpiar.Margin = new Padding(3, 2, 3, 2);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(98, 30);
            btnLimpiar.TabIndex = 13;
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
            dgvPersona.Location = new Point(21, 221);
            dgvPersona.Margin = new Padding(3, 2, 3, 2);
            dgvPersona.MultiSelect = false;
            dgvPersona.Name = "dgvPersona";
            dgvPersona.ReadOnly = true;
            dgvPersona.RowHeadersVisible = false;
            dgvPersona.RowTemplate.Height = 29;
            dgvPersona.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPersona.Size = new Size(663, 88);
            dgvPersona.TabIndex = 14;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(365, 82);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(52, 15);
            lblTelefono.TabIndex = 0;
            lblTelefono.Text = "Teléfono";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(465, 79);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(219, 23);
            txtTelefono.TabIndex = 7;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(465, 111);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(219, 23);
            txtEmail.TabIndex = 8;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(365, 114);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(41, 15);
            lblEmail.TabIndex = 0;
            lblEmail.Text = "E-mail";
            // 
            // checkSocio
            // 
            checkSocio.AutoSize = true;
            checkSocio.Location = new Point(160, 146);
            checkSocio.Name = "checkSocio";
            checkSocio.Size = new Size(55, 19);
            checkSocio.TabIndex = 10;
            checkSocio.Text = "Socio";
            checkSocio.UseVisualStyleBackColor = true;
            // 
            // cmbSexo
            // 
            cmbSexo.FormattingEnabled = true;
            cmbSexo.Location = new Point(140, 79);
            cmbSexo.Name = "cmbSexo";
            cmbSexo.Size = new Size(219, 23);
            cmbSexo.TabIndex = 3;
            // 
            // Sexo
            // 
            Sexo.AutoSize = true;
            Sexo.Location = new Point(21, 82);
            Sexo.Name = "Sexo";
            Sexo.Size = new Size(32, 15);
            Sexo.TabIndex = 0;
            Sexo.Text = "Sexo";
            // 
            // checkApto
            // 
            checkApto.AutoSize = true;
            checkApto.Location = new Point(254, 146);
            checkApto.Name = "checkApto";
            checkApto.Size = new Size(85, 19);
            checkApto.TabIndex = 11;
            checkApto.Text = "Apto Fisico";
            checkApto.UseVisualStyleBackColor = true;
            // 
            // dateTimePickerNacim
            // 
            dateTimePickerNacim.Format = DateTimePickerFormat.Short;
            dateTimePickerNacim.Location = new Point(140, 111);
            dateTimePickerNacim.Name = "dateTimePickerNacim";
            dateTimePickerNacim.Size = new Size(219, 23);
            dateTimePickerNacim.TabIndex = 4;
            dateTimePickerNacim.Value = new DateTime(2025, 10, 28, 10, 10, 56, 0);
            // 
            // lblFechaNac
            // 
            lblFechaNac.AutoSize = true;
            lblFechaNac.Location = new Point(21, 111);
            lblFechaNac.Name = "lblFechaNac";
            lblFechaNac.Size = new Size(103, 15);
            lblFechaNac.TabIndex = 15;
            lblFechaNac.Text = "Fecha Nacimiento";
            // 
            // lblDomicilio
            // 
            lblDomicilio.AutoSize = true;
            lblDomicilio.Location = new Point(365, 146);
            lblDomicilio.Name = "lblDomicilio";
            lblDomicilio.Size = new Size(58, 15);
            lblDomicilio.TabIndex = 16;
            lblDomicilio.Text = "Domicilio";
            // 
            // txtDomicilio
            // 
            txtDomicilio.Location = new Point(465, 143);
            txtDomicilio.Name = "txtDomicilio";
            txtDomicilio.Size = new Size(219, 23);
            txtDomicilio.TabIndex = 9;
            // 
            // FrmRegistro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(705, 330);
            Controls.Add(lblDomicilio);
            Controls.Add(txtDomicilio);
            Controls.Add(lblFechaNac);
            Controls.Add(dateTimePickerNacim);
            Controls.Add(checkApto);
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
            Name = "FrmRegistro";
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
        private CheckBox checkSocio;
        private ComboBox cmbSexo;
        private Label Sexo;
        private CheckBox checkApto;
        private DateTimePicker dateTimePickerNacim;
        private Label lblFechaNac;
        private Label lblDomicilio;
        private TextBox txtDomicilio;
    }
}
