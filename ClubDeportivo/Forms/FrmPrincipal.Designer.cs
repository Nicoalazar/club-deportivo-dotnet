namespace ClubDeportivo
{
    partial class FrmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            tituloVentanaPrincipal = new Label();
            btnRegistrarPersona = new Button();
            btnListarVencimientos = new Button();
            btnRevisarAsistencia = new Button();
            btnBuscar = new Button();
            statusStrip1 = new StatusStrip();
            toolStripUser = new ToolStripStatusLabel();
            toolStripRol = new ToolStripStatusLabel();
            toolStripDateTime = new ToolStripStatusLabel();
            pictureBox1 = new PictureBox();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // tituloVentanaPrincipal
            // 
            tituloVentanaPrincipal.AutoSize = true;
            tituloVentanaPrincipal.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            tituloVentanaPrincipal.Location = new Point(246, 38);
            tituloVentanaPrincipal.Name = "tituloVentanaPrincipal";
            tituloVentanaPrincipal.Size = new Size(171, 30);
            tituloVentanaPrincipal.TabIndex = 0;
            tituloVentanaPrincipal.Text = "Club Deportivo";
            // 
            // btnRegistrarPersona
            // 
            btnRegistrarPersona.Location = new Point(124, 107);
            btnRegistrarPersona.Margin = new Padding(3, 2, 3, 2);
            btnRegistrarPersona.Name = "btnRegistrarPersona";
            btnRegistrarPersona.Size = new Size(138, 31);
            btnRegistrarPersona.TabIndex = 1;
            btnRegistrarPersona.Text = "Registrar Persona";
            btnRegistrarPersona.UseVisualStyleBackColor = true;
            btnRegistrarPersona.Click += btnRegistrarPersona_Click;
            // 
            // btnListarVencimientos
            // 
            btnListarVencimientos.Location = new Point(410, 107);
            btnListarVencimientos.Margin = new Padding(3, 2, 3, 2);
            btnListarVencimientos.Name = "btnListarVencimientos";
            btnListarVencimientos.Size = new Size(138, 31);
            btnListarVencimientos.TabIndex = 2;
            btnListarVencimientos.Text = "Listar Vencimientos";
            btnListarVencimientos.UseVisualStyleBackColor = true;
            btnListarVencimientos.Click += btnListarVencimientos_Click;
            // 
            // btnRevisarAsistencia
            // 
            btnRevisarAsistencia.Location = new Point(410, 199);
            btnRevisarAsistencia.Margin = new Padding(3, 2, 3, 2);
            btnRevisarAsistencia.Name = "btnRevisarAsistencia";
            btnRevisarAsistencia.Size = new Size(138, 31);
            btnRevisarAsistencia.TabIndex = 4;
            btnRevisarAsistencia.Text = "Revisar Asistencia";
            btnRevisarAsistencia.UseVisualStyleBackColor = true;
            btnRevisarAsistencia.Click += btnRevisarAsistencia_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(124, 199);
            btnBuscar.Margin = new Padding(3, 2, 3, 2);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(138, 31);
            btnBuscar.TabIndex = 3;
            btnBuscar.Text = "Buscar Persona";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripUser, toolStripRol, toolStripDateTime });
            statusStrip1.Location = new Point(0, 316);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(700, 22);
            statusStrip1.TabIndex = 5;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripUser
            // 
            toolStripUser.Name = "toolStripUser";
            toolStripUser.Size = new Size(118, 17);
            toolStripUser.Text = "toolStripStatusLabel1";
            // 
            // toolStripRol
            // 
            toolStripRol.Name = "toolStripRol";
            toolStripRol.Size = new Size(118, 17);
            toolStripRol.Text = "toolStripStatusLabel2";
            // 
            // toolStripDateTime
            // 
            toolStripDateTime.Name = "toolStripDateTime";
            toolStripDateTime.Size = new Size(118, 17);
            toolStripDateTime.Text = "toolStripStatusLabel3";
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(700, 338);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(statusStrip1);
            Controls.Add(btnBuscar);
            Controls.Add(btnRevisarAsistencia);
            Controls.Add(btnListarVencimientos);
            Controls.Add(btnRegistrarPersona);
            Controls.Add(tituloVentanaPrincipal);
            Controls.Add(pictureBox1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FrmPrincipal";
            Text = "Pantalla Principal";
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label tituloVentanaPrincipal;
        private Button btnRegistrarPersona;
        private Button btnListarVencimientos;
        private Button btnRevisarAsistencia;
        private Button btnBuscar;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripUser;
        private ToolStripStatusLabel toolStripRol;
        private ToolStripStatusLabel toolStripDateTime;
        private PictureBox pictureBox1;
    }
}