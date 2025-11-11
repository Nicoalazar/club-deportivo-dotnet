using ClubDeportivo.Models;
using System.Drawing.Printing;

namespace ClubDeportivo.Services
{
    public class NoSocioCarnetPrinter
    {
        private NoSocio noSocio;
        private PrintDocument printDoc;

        public NoSocioCarnetPrinter(NoSocio noSocio)
        {
            this.noSocio = noSocio;
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
            Graphics g = e.Graphics!;
            Rectangle rect = new Rectangle(100, 100, 500, 300);

            // Fondo gris claro para indicar NO SOCIO (muy evidente)
            g.FillRectangle(Brushes.LightGray, rect);
            g.DrawRectangle(Pens.DarkRed, rect);

            if (Properties.Resources.logo != null)
                g.DrawImage(Properties.Resources.logo, 110, 110, 80, 80);

            Font titleFont = new Font("Arial", 16, FontStyle.Bold);
            Font textFont = new Font("Arial", 12, FontStyle.Regular);

            g.DrawString("Carnet de No Socio", titleFont, Brushes.DarkBlue, 200, 110);
            g.DrawString($"Nombre Completo: {noSocio.Persona.Nombres} {noSocio.Persona.Apellidos}", textFont, Brushes.Black, 120, 200);
            g.DrawString($"Documento: {noSocio.Persona.TipoDocumento} {noSocio.Persona.NumeroDocumento}", textFont, Brushes.Black, 120, 225);
            g.DrawString($"Estado: {noSocio.Estado}", textFont, Brushes.Black, 120, 250);
            if (noSocio.VtoAptoFisico > DateTime.Now)
            {
                g.DrawString($"Apto Físico Válido Hasta: {noSocio.VtoAptoFisico:dd/MM/yyyy}", textFont, Brushes.Black, 120, 275);
            }
            else
            {
                g.DrawString($"Apto Físico Vencido", textFont, Brushes.Black, 120, 275);
            }

        }
    }
}
