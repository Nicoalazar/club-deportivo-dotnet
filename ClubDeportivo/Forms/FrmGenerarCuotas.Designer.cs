namespace ClubDeportivo.Forms
{
    partial class FrmGenerarCuotas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnGenerar = new Button();
            lblPeriodo = new Label();
            cmbBoxPeriodo = new ComboBox();
            lblMonto = new Label();
            txtBoxMonto = new TextBox();
            SuspendLayout();
            // 
            // btnGenerar
            // 
            btnGenerar.Location = new Point(345, 62);
            btnGenerar.Name = "btnGenerar";
            btnGenerar.Size = new Size(75, 23);
            btnGenerar.TabIndex = 0;
            btnGenerar.Text = "Generar";
            btnGenerar.UseVisualStyleBackColor = true;
            btnGenerar.Click += btnGenerar_Click;
            // 
            // lblPeriodo
            // 
            lblPeriodo.AutoSize = true;
            lblPeriodo.Location = new Point(35, 29);
            lblPeriodo.Name = "lblPeriodo";
            lblPeriodo.Size = new Size(48, 15);
            lblPeriodo.TabIndex = 1;
            lblPeriodo.Text = "Periodo";
            // 
            // cmbBoxPeriodo
            // 
            cmbBoxPeriodo.FormattingEnabled = true;
            cmbBoxPeriodo.Location = new Point(32, 62);
            cmbBoxPeriodo.Name = "cmbBoxPeriodo";
            cmbBoxPeriodo.Size = new Size(121, 23);
            cmbBoxPeriodo.TabIndex = 2;
            cmbBoxPeriodo.SelectedIndexChanged += cmbBoxPeriodo_SelectedIndexChanged;
            // 
            // lblMonto
            // 
            lblMonto.AutoSize = true;
            lblMonto.Location = new Point(196, 29);
            lblMonto.Name = "lblMonto";
            lblMonto.Size = new Size(94, 15);
            lblMonto.TabIndex = 3;
            lblMonto.Text = "Monto de Cuota";
            // 
            // txtBoxMonto
            // 
            txtBoxMonto.Location = new Point(196, 62);
            txtBoxMonto.Name = "txtBoxMonto";
            txtBoxMonto.Size = new Size(100, 23);
            txtBoxMonto.TabIndex = 4;
            txtBoxMonto.Text = "\r\n";
            // 
            // FrmGenerarCuotas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(449, 133);
            Controls.Add(txtBoxMonto);
            Controls.Add(lblMonto);
            Controls.Add(cmbBoxPeriodo);
            Controls.Add(lblPeriodo);
            Controls.Add(btnGenerar);
            Name = "FrmGenerarCuotas";
            Text = "FrmGenerarCuotas";
            Load += FrmGenerarCuotas_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnGenerar;
        private Label lblPeriodo;
        private ComboBox cmbBoxPeriodo;
        private Label lblMonto;
        private TextBox txtBoxMonto;
    }
}