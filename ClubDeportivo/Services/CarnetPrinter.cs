using System;
using System.Drawing;
using System.Drawing.Printing;

namespace ClubDeportivo.Services
{
    public class CarnetPrinter
    {
        private Persona persona;
        private PrintDocument printDoc;

        public CarnetPrinter(Persona persona)
        {
            this.persona = persona;
            printDoc = new PrintDocument();
            printDoc.PrintPage += PrintDoc_PrintPage;
        }

        // Método público reutilizable
        public void Imprimir()
        {
            PrintPreviewDialog preview = new PrintPreviewDialog
            {
                Document = printDoc,
                Width = 800,
                Height = 600
            };
            preview.ShowDialog();
        }

        // Diseño del carnet
        private void PrintDoc_PrintPage(object? sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = new Rectangle(100, 100, 350, 200);

            // Fondo del carnet
            g.FillRectangle(Brushes.LightBlue, rect);
            g.DrawRectangle(Pens.DarkBlue, rect);

            // Logo (si existe en Resources)
            if (Properties.Resources.logo != null)
                g.DrawImage(Properties.Resources.logo, 110, 110, 80, 80);

            // Datos
            Font titleFont = new Font("Arial", 14, FontStyle.Bold);
            Font textFont = new Font("Arial", 12, FontStyle.Regular);

            g.DrawString("Carnet de Socio", titleFont, Brushes.DarkBlue, 220, 110);
            g.DrawString($"Nombre: {persona.Nombre} {persona.Apellido}", textFont, Brushes.Black, 120, 200);
            g.DrawString($"Documento: {persona.Tipo} {persona.Documento}", textFont, Brushes.Black, 120, 225);
            g.DrawString($"Socio: {(persona.Relacion == 1 ? "Activo" : "No socio")}", textFont, Brushes.Black, 120, 250);
            g.DrawString($"Emitido: {DateTime.Now:dd/MM/yyyy}", textFont, Brushes.Black, 120, 275);
        }
    }
}
