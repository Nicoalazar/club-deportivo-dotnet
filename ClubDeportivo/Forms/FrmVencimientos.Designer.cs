namespace ClubDeportivo.Forms
{
    partial class FrmVencimientos
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
            dtpFechaConsulta = new DateTimePicker();
            btnConsultar = new Button();
            dgvVencimientos = new DataGridView();
            labelVencimientos = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvVencimientos).BeginInit();
            SuspendLayout();
            // 
            // dtpFechaConsulta
            // 
            dtpFechaConsulta.Location = new Point(253, 95);
            dtpFechaConsulta.Name = "dtpFechaConsulta";
            dtpFechaConsulta.Size = new Size(287, 27);
            dtpFechaConsulta.TabIndex = 0;
            dtpFechaConsulta.ValueChanged += this.dtpFechaConsulta_ValueChanged;
            // 
            // btnConsultar
            // 
            btnConsultar.Location = new Point(270, 193);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new Size(250, 29);
            btnConsultar.TabIndex = 1;
            btnConsultar.Text = "Consultar Vencimientos";
            btnConsultar.UseVisualStyleBackColor = true;
            btnConsultar.Click += this.btnConsultar_Click;
            // 
            // dgvVencimientos
            // 
            dgvVencimientos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVencimientos.Location = new Point(12, 250);
            dgvVencimientos.Name = "dgvVencimientos";
            dgvVencimientos.RowHeadersWidth = 51;
            dgvVencimientos.Size = new Size(776, 188);
            dgvVencimientos.TabIndex = 2;
            // 
            // labelVencimientos
            // 
            labelVencimientos.AutoSize = true;
            labelVencimientos.Font = new Font("Segoe UI", 25F);
            labelVencimientos.Location = new Point(242, 9);
            labelVencimientos.Name = "labelVencimientos";
            labelVencimientos.Size = new Size(315, 57);
            labelVencimientos.TabIndex = 3;
            labelVencimientos.Text = "VENCIMIENTOS";
            labelVencimientos.Click += this.label1_Click;
            // 
            // FrmVencimientos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(labelVencimientos);
            Controls.Add(dgvVencimientos);
            Controls.Add(btnConsultar);
            Controls.Add(dtpFechaConsulta);
            Name = "FrmVencimientos";
            Text = "Vencimientos";
            ((System.ComponentModel.ISupportInitialize)dgvVencimientos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dtpFechaConsulta;
        private Button btnConsultar;
        private DataGridView dgvVencimientos;
        private Label labelVencimientos;
    }
}