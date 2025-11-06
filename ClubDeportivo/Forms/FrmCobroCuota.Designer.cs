namespace ClubDeportivo.Forms
{
    partial class FrmCobroCuota
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
            btnCobrar = new Button();
            label1 = new Label();
            cmbBoxPeriodo = new ComboBox();
            label2 = new Label();
            cmbBoxMedio = new ComboBox();
            SuspendLayout();
            // 
            // btnCobrar
            // 
            btnCobrar.Location = new Point(363, 83);
            btnCobrar.Name = "btnCobrar";
            btnCobrar.Size = new Size(75, 23);
            btnCobrar.TabIndex = 0;
            btnCobrar.Text = "Cobrar";
            btnCobrar.UseVisualStyleBackColor = true;
            btnCobrar.Click += btnCobrar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(58, 26);
            label1.Name = "label1";
            label1.Size = new Size(48, 15);
            label1.TabIndex = 1;
            label1.Text = "Periodo";
            // 
            // cmbBoxPeriodo
            // 
            cmbBoxPeriodo.FormattingEnabled = true;
            cmbBoxPeriodo.Location = new Point(59, 62);
            cmbBoxPeriodo.Name = "cmbBoxPeriodo";
            cmbBoxPeriodo.Size = new Size(121, 23);
            cmbBoxPeriodo.TabIndex = 2;
            cmbBoxPeriodo.SelectedIndexChanged += cmbBoxPeriodo_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(59, 103);
            label2.Name = "label2";
            label2.Size = new Size(87, 15);
            label2.TabIndex = 3;
            label2.Text = "Medio de Pago";
            // 
            // cmbBoxMedio
            // 
            cmbBoxMedio.FormattingEnabled = true;
            cmbBoxMedio.Location = new Point(61, 138);
            cmbBoxMedio.Name = "cmbBoxMedio";
            cmbBoxMedio.Size = new Size(121, 23);
            cmbBoxMedio.TabIndex = 4;
            cmbBoxMedio.SelectedIndexChanged += cmbBoxMedio_SelectedIndexChanged;
            // 
            // FrmCobroCuota
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cmbBoxMedio);
            Controls.Add(label2);
            Controls.Add(cmbBoxPeriodo);
            Controls.Add(label1);
            Controls.Add(btnCobrar);
            Name = "FrmCobroCuota";
            Text = "FrmCobroCuota";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCobrar;
        private Label label1;
        private ComboBox cmbBoxPeriodo;
        private Label label2;
        private ComboBox cmbBoxMedio;
    }
}