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
            label1 = new Label();
            dtpFecha = new DateTimePicker();
            dgvVencimientos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvVencimientos).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(83, 86);
            label1.Name = "label1";
            label1.Size = new Size(151, 20);
            label1.TabIndex = 0;
            label1.Text = "Seleccione una fecha:";
            // 
            // dtpFecha
            // 
            dtpFecha.Location = new Point(256, 79);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(291, 27);
            dtpFecha.TabIndex = 1;
            dtpFecha.ValueChanged += dtpFecha_ValueChanged;
            // 
            // dgvVencimientos
            // 
            dgvVencimientos.AllowUserToAddRows = false;
            dgvVencimientos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVencimientos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVencimientos.Location = new Point(12, 213);
            dgvVencimientos.Name = "dgvVencimientos";
            dgvVencimientos.ReadOnly = true;
            dgvVencimientos.RowHeadersWidth = 51;
            dgvVencimientos.Size = new Size(776, 188);
            dgvVencimientos.TabIndex = 2;
            // 
            // FrmVencimientos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvVencimientos);
            Controls.Add(dtpFecha);
            Controls.Add(label1);
            Name = "FrmVencimientos";
            Text = "Vencimientos";
            Load += FrmVencimientos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvVencimientos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DateTimePicker dtpFecha;
        private DataGridView dgvVencimientos;
    }
}