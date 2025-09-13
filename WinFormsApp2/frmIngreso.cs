using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class frmIngreso : Form
    {
        public frmIngreso()
        {
            InitializeComponent();
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("El DATO 1 es: -->> " + textBox1.Text + " y el DATO 2 es: -->> " + textBox2.Text, "DATOS DESDE TextBox", MessageBoxButtons.OK, MessageBoxIcon.Information);

            string dato1, dato2;

            dato1 = Convert.ToString(Microsoft.VisualBasic.Interaction.InputBox("Ingresar el valor del DATO 1", "PRIMER DATO", "ingrese aqui"));

            dato2 = Convert.ToString(Microsoft.VisualBasic.Interaction.InputBox("Ingresar el valor del DATO 2", "SEGUNDO DATO", "ingrese aqui"));

            MessageBox.Show("El DATO 1 es:-->> " + dato1 + " y el DATO 2 es: -->> " + dato2, "DATOS DESDE CUADRO DE DIALOGO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnCalculo_Click(object sender, EventArgs e)
        {
            int Numero1;
            int Numero2;
            Numero1 = Convert.ToInt32(Microsoft.VisualBasic.Interaction.InputBox("Ingresar el Primer numero",
            "PRIMER NUMERO", "ingrese aqui"));

            Numero2 = Convert.ToInt32(Microsoft.VisualBasic.Interaction.InputBox("Ingresar el Segundo numero",
            "SEGUNDO NUMERO", "ingrese aqui"));

            if (Numero1 > Numero2)
            {
                MessageBox.Show("El PRIMER numero es MAYOR al SEGUNDO numero",
                "NUMERO MAYOR", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("El SEGUNDO numero es MAYOR al PRIMER numero",
                "NUMERO MAYOR", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            btnAceptar = new Button();
            btnCalculo = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 48);
            label1.Name = "label1";
            label1.Size = new Size(46, 15);
            label1.TabIndex = 0;
            label1.Text = "DATO 1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 93);
            label2.Name = "label2";
            label2.Size = new Size(46, 15);
            label2.TabIndex = 1;
            label2.Text = "DATO 2";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(112, 45);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(112, 90);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 3;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(112, 155);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(100, 30);
            btnAceptar.TabIndex = 4;
            btnAceptar.Text = "ACEPTAR";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCalculo
            // 
            btnCalculo.Location = new Point(112, 204);
            btnCalculo.Name = "btnCalculo";
            btnCalculo.Size = new Size(100, 30);
            btnCalculo.TabIndex = 5;
            btnCalculo.Text = "CALCULO";
            btnCalculo.UseVisualStyleBackColor = true;
            btnCalculo.Click += btnCalculo_Click;
            // 
            // frmIngreso
            // 
            ClientSize = new Size(315, 261);
            Controls.Add(btnCalculo);
            Controls.Add(btnAceptar);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmIngreso";
            Text = "INGRESO Y MUESTRA DE DATOS";
            ResumeLayout(false);
            PerformLayout();

        }
        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button btnAceptar;
        private Button btnCalculo;


    }
}
