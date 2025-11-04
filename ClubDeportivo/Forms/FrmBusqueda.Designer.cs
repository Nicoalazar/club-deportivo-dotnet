namespace ClubDeportivo
{
    partial class FrmBusqueda
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
            btnSearch = new Button();
            txtDni = new TextBox();
            dataGridBusqueda = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridBusqueda).BeginInit();
            SuspendLayout();
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(430, 48);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 0;
            btnSearch.Text = "Buscar";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtDni
            // 
            txtDni.Location = new Point(189, 57);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(100, 23);
            txtDni.TabIndex = 1;
            // 
            // dataGridBusqueda
            // 
            dataGridBusqueda.AllowUserToAddRows = false;
            dataGridBusqueda.AllowUserToDeleteRows = false;
            dataGridBusqueda.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridBusqueda.Location = new Point(24, 277);
            dataGridBusqueda.Name = "dataGridBusqueda";
            dataGridBusqueda.ReadOnly = true;
            dataGridBusqueda.Size = new Size(595, 150);
            dataGridBusqueda.TabIndex = 2;
            // 
            // FrmBusqueda
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridBusqueda);
            Controls.Add(txtDni);
            Controls.Add(btnSearch);
            Name = "FrmBusqueda";
            Text = "Busqueda";
            ((System.ComponentModel.ISupportInitialize)dataGridBusqueda).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSearch;
        private TextBox txtDni;
        private DataGridView dataGridBusqueda;
    }
}