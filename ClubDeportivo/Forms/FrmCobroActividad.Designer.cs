namespace ClubDeportivo.Forms
{
    partial class FrmCobroActividad
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
            label1 = new Label();
            dateTimePicker1 = new DateTimePicker();
            label2 = new Label();
            btnCobrar = new Button();
            txtBoxMonto = new TextBox();
            cmbBoxMedio = new ComboBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(37, 46);
            label1.Name = "label1";
            label1.Size = new Size(109, 15);
            label1.TabIndex = 0;
            label1.Text = "Habilitar para el día";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(164, 40);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(213, 23);
            dateTimePicker1.TabIndex = 1;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(108, 86);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 2;
            label2.Text = "Costo";
            // 
            // btnCobrar
            // 
            btnCobrar.Location = new Point(164, 161);
            btnCobrar.Name = "btnCobrar";
            btnCobrar.Size = new Size(75, 23);
            btnCobrar.TabIndex = 3;
            btnCobrar.Text = "Cobrar";
            btnCobrar.UseVisualStyleBackColor = true;
            btnCobrar.Click += btnCobrar_Click;
            // 
            // txtBoxMonto
            // 
            txtBoxMonto.Location = new Point(164, 78);
            txtBoxMonto.Name = "txtBoxMonto";
            txtBoxMonto.Size = new Size(100, 23);
            txtBoxMonto.TabIndex = 4;
            // 
            // cmbBoxMedio
            // 
            cmbBoxMedio.FormattingEnabled = true;
            cmbBoxMedio.Location = new Point(164, 117);
            cmbBoxMedio.Name = "cmbBoxMedio";
            cmbBoxMedio.Size = new Size(121, 23);
            cmbBoxMedio.TabIndex = 5;
            cmbBoxMedio.SelectedIndexChanged += cmbBoxMedio_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(59, 125);
            label3.Name = "label3";
            label3.Size = new Size(87, 15);
            label3.TabIndex = 6;
            label3.Text = "Medio de Pago";
            // 
            // FrmCobroActividad
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(396, 207);
            Controls.Add(label3);
            Controls.Add(cmbBoxMedio);
            Controls.Add(txtBoxMonto);
            Controls.Add(btnCobrar);
            Controls.Add(label2);
            Controls.Add(dateTimePicker1);
            Controls.Add(label1);
            Name = "FrmCobroActividad";
            Text = "CobroActividad";
            Load += FrmCobroActividad_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DateTimePicker dateTimePicker1;
        private Label label2;
        private Button btnCobrar;
        private TextBox txtBoxMonto;
        private ComboBox cmbBoxMedio;
        private Label label3;
    }
}