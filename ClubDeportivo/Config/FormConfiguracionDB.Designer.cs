using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClubDeportivo.Config
{
    partial class FormConfiguracionDB
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
            panelPrincipal = new Panel();
            lblTitulo = new Label();
            lblSubtitulo = new Label();
            lblServidor = new Label();
            txtServidor = new TextBox();
            lblPuerto = new Label();
            txtPuerto = new TextBox();
            lblUsuario = new Label();
            txtUsuario = new TextBox();
            lblClave = new Label();
            txtClave = new TextBox();
            chkMostrarClave = new CheckBox();
            panelResultado = new Panel();
            lblResultado = new Label();
            progressBar = new ProgressBar();
            lblEstado = new Label();
            btnProbarConexion = new Button();
            btnGuardar = new Button();
            btnCancelar = new Button();
            panelPrincipal.SuspendLayout();
            panelResultado.SuspendLayout();
            SuspendLayout();
            // 
            // panelPrincipal
            // 
            panelPrincipal.Controls.Add(lblTitulo);
            panelPrincipal.Controls.Add(lblSubtitulo);
            panelPrincipal.Controls.Add(lblServidor);
            panelPrincipal.Controls.Add(txtServidor);
            panelPrincipal.Controls.Add(lblPuerto);
            panelPrincipal.Controls.Add(txtPuerto);
            panelPrincipal.Controls.Add(lblUsuario);
            panelPrincipal.Controls.Add(txtUsuario);
            panelPrincipal.Controls.Add(lblClave);
            panelPrincipal.Controls.Add(txtClave);
            panelPrincipal.Controls.Add(chkMostrarClave);
            panelPrincipal.Controls.Add(panelResultado);
            panelPrincipal.Controls.Add(progressBar);
            panelPrincipal.Controls.Add(lblEstado);
            panelPrincipal.Controls.Add(btnProbarConexion);
            panelPrincipal.Controls.Add(btnGuardar);
            panelPrincipal.Controls.Add(btnCancelar);
            panelPrincipal.Dock = DockStyle.Fill;
            panelPrincipal.Location = new Point(0, 0);
            panelPrincipal.Name = "panelPrincipal";
            panelPrincipal.Padding = new Padding(20);
            panelPrincipal.Size = new Size(500, 480);
            panelPrincipal.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.Location = new Point(20, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(326, 25);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Configuración de Conexión MySQL";
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Segoe UI", 9F);
            lblSubtitulo.ForeColor = Color.Gray;
            lblSubtitulo.Location = new Point(20, 45);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(258, 15);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Ingrese los datos de conexión a la base de datos";
            // 
            // lblServidor
            // 
            lblServidor.AutoSize = true;
            lblServidor.Location = new Point(20, 80);
            lblServidor.Name = "lblServidor";
            lblServidor.Size = new Size(53, 15);
            lblServidor.TabIndex = 2;
            lblServidor.Text = "Servidor:";
            // 
            // txtServidor
            // 
            txtServidor.Font = new Font("Segoe UI", 10F);
            txtServidor.Location = new Point(20, 100);
            txtServidor.Name = "txtServidor";
            txtServidor.Size = new Size(440, 25);
            txtServidor.TabIndex = 3;
            txtServidor.Text = "localhost";
            txtServidor.TextChanged += ValidarCampos;
            // 
            // lblPuerto
            // 
            lblPuerto.AutoSize = true;
            lblPuerto.Location = new Point(20, 135);
            lblPuerto.Name = "lblPuerto";
            lblPuerto.Size = new Size(45, 15);
            lblPuerto.TabIndex = 4;
            lblPuerto.Text = "Puerto:";
            // 
            // txtPuerto
            // 
            txtPuerto.Font = new Font("Segoe UI", 10F);
            txtPuerto.Location = new Point(20, 155);
            txtPuerto.Name = "txtPuerto";
            txtPuerto.Size = new Size(440, 25);
            txtPuerto.TabIndex = 5;
            txtPuerto.Text = "3306";
            txtPuerto.TextChanged += ValidarCampos;
            txtPuerto.KeyPress += TxtPuerto_KeyPress;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(20, 190);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(50, 15);
            lblUsuario.TabIndex = 6;
            lblUsuario.Text = "Usuario:";
            // 
            // txtUsuario
            // 
            txtUsuario.Font = new Font("Segoe UI", 10F);
            txtUsuario.Location = new Point(20, 210);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(440, 25);
            txtUsuario.TabIndex = 7;
            txtUsuario.Text = "root";
            txtUsuario.TextChanged += ValidarCampos;
            // 
            // lblClave
            // 
            lblClave.AutoSize = true;
            lblClave.Location = new Point(20, 245);
            lblClave.Name = "lblClave";
            lblClave.Size = new Size(70, 15);
            lblClave.TabIndex = 8;
            lblClave.Text = "Contraseña:";
            // 
            // txtClave
            // 
            txtClave.Font = new Font("Segoe UI", 10F);
            txtClave.Location = new Point(20, 265);
            txtClave.Name = "txtClave";
            txtClave.Size = new Size(440, 25);
            txtClave.TabIndex = 9;
            txtClave.UseSystemPasswordChar = true;
            // 
            // chkMostrarClave
            // 
            chkMostrarClave.AutoSize = true;
            chkMostrarClave.Location = new Point(20, 295);
            chkMostrarClave.Name = "chkMostrarClave";
            chkMostrarClave.Size = new Size(128, 19);
            chkMostrarClave.TabIndex = 10;
            chkMostrarClave.Text = "Mostrar contraseña";
            chkMostrarClave.UseVisualStyleBackColor = true;
            chkMostrarClave.CheckedChanged += ChkMostrarClave_CheckedChanged;
            // 
            // panelResultado
            // 
            panelResultado.BorderStyle = BorderStyle.FixedSingle;
            panelResultado.Controls.Add(lblResultado);
            panelResultado.Location = new Point(20, 325);
            panelResultado.Name = "panelResultado";
            panelResultado.Size = new Size(440, 40);
            panelResultado.TabIndex = 11;
            panelResultado.Visible = false;
            // 
            // lblResultado
            // 
            lblResultado.Dock = DockStyle.Fill;
            lblResultado.Font = new Font("Segoe UI", 9F);
            lblResultado.Location = new Point(0, 0);
            lblResultado.Name = "lblResultado";
            lblResultado.Padding = new Padding(10, 0, 0, 0);
            lblResultado.Size = new Size(438, 38);
            lblResultado.TabIndex = 0;
            lblResultado.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(20, 330);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(440, 23);
            progressBar.Style = ProgressBarStyle.Marquee;
            progressBar.TabIndex = 12;
            progressBar.Visible = false;
            // 
            // lblEstado
            // 
            lblEstado.Font = new Font("Segoe UI", 9F);
            lblEstado.ForeColor = Color.Gray;
            lblEstado.Location = new Point(20, 358);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(440, 20);
            lblEstado.TabIndex = 13;
            lblEstado.Visible = false;
            // 
            // btnProbarConexion
            // 
            btnProbarConexion.Font = new Font("Segoe UI", 9F);
            btnProbarConexion.Location = new Point(20, 390);
            btnProbarConexion.Name = "btnProbarConexion";
            btnProbarConexion.Size = new Size(140, 35);
            btnProbarConexion.TabIndex = 14;
            btnProbarConexion.Text = "Probar Conexión";
            btnProbarConexion.UseVisualStyleBackColor = true;
            btnProbarConexion.Click += BtnProbarConexion_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Enabled = false;
            btnGuardar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnGuardar.Location = new Point(170, 390);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(150, 35);
            btnGuardar.TabIndex = 15;
            btnGuardar.Text = "Guardar y Continuar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += BtnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Yes;
            btnCancelar.Font = new Font("Segoe UI", 9F);
            btnCancelar.Location = new Point(330, 390);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(130, 35);
            btnCancelar.TabIndex = 16;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += BtnCancelar_Click;
            // 
            // FormConfiguracionDB
            // 
            AcceptButton = btnProbarConexion;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancelar;
            ClientSize = new Size(500, 480);
            Controls.Add(panelPrincipal);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormConfiguracionDB";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Configuración de Base de Datos MySQL";
            panelPrincipal.ResumeLayout(false);
            panelPrincipal.PerformLayout();
            panelResultado.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelPrincipal;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblServidor;
        private System.Windows.Forms.TextBox txtServidor;
        private System.Windows.Forms.Label lblPuerto;
        private System.Windows.Forms.TextBox txtPuerto;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblClave;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.CheckBox chkMostrarClave;
        private System.Windows.Forms.Panel panelResultado;
        private System.Windows.Forms.Label lblResultado;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Button btnProbarConexion;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
    }
}