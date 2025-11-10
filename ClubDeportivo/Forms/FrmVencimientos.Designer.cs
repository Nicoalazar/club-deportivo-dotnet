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
            lblContador = new Label();
            btnImprimir = new Button();
            chkPorVencer = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)dgvVencimientos).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(70, 16);
            label1.Name = "label1";
            label1.Size = new Size(121, 15);
            label1.TabIndex = 0;
            label1.Text = "Seleccione una fecha:";
            // 
            // dtpFecha
            // 
            dtpFecha.Location = new Point(221, 11);
            dtpFecha.Margin = new Padding(3, 2, 3, 2);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(255, 23);
            dtpFecha.TabIndex = 1;
            dtpFecha.ValueChanged += dtpFecha_ValueChanged;
            // 
            // dgvVencimientos
            // 
            dgvVencimientos.AllowUserToAddRows = false;
            dgvVencimientos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVencimientos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVencimientos.Location = new Point(9, 65);
            dgvVencimientos.Margin = new Padding(3, 2, 3, 2);
            dgvVencimientos.Name = "dgvVencimientos";
            dgvVencimientos.ReadOnly = true;
            dgvVencimientos.RowHeadersWidth = 51;
            dgvVencimientos.Size = new Size(724, 216);
            dgvVencimientos.TabIndex = 2;
            // 
            // lblContador
            // 
            lblContador.AutoSize = true;
            lblContador.Location = new Point(9, 303);
            lblContador.Name = "lblContador";
            lblContador.Size = new Size(111, 15);
            lblContador.TabIndex = 3;
            lblContador.Text = "Cantidad de Cuotas";
            // 
            // btnImprimir
            // 
            btnImprimir.Location = new Point(658, 303);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(75, 23);
            btnImprimir.TabIndex = 5;
            btnImprimir.Text = "Imprimir";
            btnImprimir.UseVisualStyleBackColor = true;
            btnImprimir.Click += btnImprimir_Click;
            // 
            // chkPorVencer
            // 
            chkPorVencer.AutoSize = true;
            chkPorVencer.Location = new Point(504, 15);
            chkPorVencer.Name = "chkPorVencer";
            chkPorVencer.Size = new Size(156, 19);
            chkPorVencer.TabIndex = 4;
            chkPorVencer.Text = "Incluir cuotas por vencer";
            chkPorVencer.UseVisualStyleBackColor = true;
            chkPorVencer.CheckedChanged += chkPorVencer_CheckedChanged;
            // 
            // FrmVencimientos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(745, 338);
            Controls.Add(btnImprimir);
            Controls.Add(chkPorVencer);
            Controls.Add(lblContador);
            Controls.Add(dgvVencimientos);
            Controls.Add(dtpFecha);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
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
        private Label lblContador;
        private Button btnImprimir;
        private CheckBox chkPorVencer;
    }
}