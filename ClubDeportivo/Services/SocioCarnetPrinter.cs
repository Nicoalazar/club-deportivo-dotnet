using System.Drawing.Printing;
using ClubDeportivo.Models;
using System.Windows.Forms;

namespace ClubDeportivo.Services
{
    public class SocioCarnetPrinter
    {
        private Socio socio;
        private PrintDocument printDoc;

        public SocioCarnetPrinter(Socio socio)
        {
            this.socio = socio;
            printDoc = new PrintDocument();
            printDoc.PrintPage += PrintDoc_PrintPage;
        }

        public void Imprimir()
        {
            var preview = new PrintPreviewDialog
            {
                Document = printDoc,
                Width = 900,
                Height = 600
            };
            preview.ShowDialog();
        }

        private void PrintDoc_PrintPage(object? sender, PrintPageEventArgs e)
        {
            var g = e.Graphics!;
            var rect = new Rectangle(100, 100, 500, 300);

            // Fondo azul claro institucional
            g.FillRectangle(Brushes.LightBlue, rect);
            g.DrawRectangle(Pens.DarkBlue, rect);

            // Logo opcional
            if (Properties.Resources.logo != null)
                g.DrawImage(Properties.Resources.logo, 110, 110, 80, 80);

            Font titleFont = new Font("Arial", 16, FontStyle.Bold);
            Font textFont = new Font("Arial", 12, FontStyle.Regular);

            g.DrawString("Carnet de Socio", titleFont, Brushes.DarkBlue, 220, 110);
            g.DrawString($"Nombre Completo: {socio.Persona.Nombres} {socio.Persona.Apellidos}", textFont, Brushes.Black, 120, 200);
            g.DrawString($"{socio.Persona.TipoDocumento} {socio.Persona.NumeroDocumento}", textFont, Brushes.Black, 120, 225);
            g.DrawString($"N° Socio: {socio.NumeroSocio} - Estado: {socio.Observaciones}", textFont, Brushes.Black, 120, 250);
            if (socio.VtoAptoFisico > DateTime.Now)
            {
                g.DrawString($"Apto Físico Válido Hasta: {socio.VtoAptoFisico:dd/MM/yyyy}", textFont, Brushes.Black, 120, 275);
            }
            else
            {
                g.DrawString($"Apto Físico Vencido", textFont, Brushes.Black, 120, 275);
            }

        }
    }
}