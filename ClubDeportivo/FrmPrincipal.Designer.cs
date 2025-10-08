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
            tituloVentanaPrincipal = new Label();
            btnRegistrarPersona = new Button();
            btnListarVencimientos = new Button();
            btnRevisarAsistencia = new Button();
            btnPrueba = new Button();
            SuspendLayout();
            // 
            // tituloVentanaPrincipal
            // 
            tituloVentanaPrincipal.AutoSize = true;
            tituloVentanaPrincipal.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            tituloVentanaPrincipal.Location = new Point(281, 50);
            tituloVentanaPrincipal.Name = "tituloVentanaPrincipal";
            tituloVentanaPrincipal.Size = new Size(214, 37);
            tituloVentanaPrincipal.TabIndex = 0;
            tituloVentanaPrincipal.Text = "Club Deportivo";
            // 
            // btnRegistrarPersona
            // 
            btnRegistrarPersona.Location = new Point(142, 143);
            btnRegistrarPersona.Name = "btnRegistrarPersona";
            btnRegistrarPersona.Size = new Size(158, 29);
            btnRegistrarPersona.TabIndex = 1;
            btnRegistrarPersona.Text = "Registrar Persona";
            btnRegistrarPersona.UseVisualStyleBackColor = true;
            btnRegistrarPersona.Click += btnRegistrarPersona_Click;
            // 
            // btnListarVencimientos
            // 
            btnListarVencimientos.Location = new Point(469, 143);
            btnListarVencimientos.Name = "btnListarVencimientos";
            btnListarVencimientos.Size = new Size(158, 29);
            btnListarVencimientos.TabIndex = 2;
            btnListarVencimientos.Text = "Listar Vencimientos";
            btnListarVencimientos.UseVisualStyleBackColor = true;
            btnListarVencimientos.Click += btnListarVencimientos_Click;
            // 
            // btnRevisarAsistencia
            // 
            btnRevisarAsistencia.Location = new Point(142, 280);
            btnRevisarAsistencia.Name = "btnRevisarAsistencia";
            btnRevisarAsistencia.Size = new Size(158, 29);
            btnRevisarAsistencia.TabIndex = 3;
            btnRevisarAsistencia.Text = "Revisar Asistencia";
            btnRevisarAsistencia.UseVisualStyleBackColor = true;
            btnRevisarAsistencia.Click += btnRevisarAsistencia_Click;
            // 
            // btnPrueba
            // 
            btnPrueba.Location = new Point(469, 280);
            btnPrueba.Name = "btnPrueba";
            btnPrueba.Size = new Size(158, 29);
            btnPrueba.TabIndex = 4;
            btnPrueba.Text = "Prueba";
            btnPrueba.UseVisualStyleBackColor = true;
            btnPrueba.Click += btnPrueba_Click;
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnPrueba);
            Controls.Add(btnRevisarAsistencia);
            Controls.Add(btnListarVencimientos);
            Controls.Add(btnRegistrarPersona);
            Controls.Add(tituloVentanaPrincipal);
            Name = "FrmPrincipal";
            Text = "Pantalla Principal";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label tituloVentanaPrincipal;
        private Button btnRegistrarPersona;
        private Button btnListarVencimientos;
        private Button btnRevisarAsistencia;
        private Button btnPrueba;
    }
}