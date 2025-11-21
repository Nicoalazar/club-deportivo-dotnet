using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace ClubDeportivo.Services
{
    public class ListadoPrinter
    {
        private readonly DataTable datos;
        private readonly DateTime fecha;
        private readonly bool incluirPorVencer;
        private PrintDocument printDoc;
        private int filaActual = 0;

        public ListadoPrinter(DataTable datos, DateTime fecha, bool incluirPorVencer)
        {
            this.datos = datos;
            this.fecha = fecha;
            this.incluirPorVencer = incluirPorVencer;

            printDoc = new PrintDocument();
            printDoc.DefaultPageSettings.Landscape = true; // horizontal
            printDoc.PrintPage += PrintDoc_PrintPage;
        }

        public void Imprimir()
        {
            PrintPreviewDialog preview = new PrintPreviewDialog
            {
                Document = printDoc,
                Width = 1000,
                Height = 700
            };
            preview.ShowDialog();
        }

        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics!;
            Font fontTitulo = new Font("Arial", 12, FontStyle.Bold);
            Font fontCabecera = new Font("Arial", 10, FontStyle.Bold);
            Font fontNormal = new Font("Arial", 9);
            int y = 50;
            int x = 50;
            int salto = 20;

            // Título
            string titulo = incluirPorVencer ? "LISTADO DE CUOTAS VENCIDAS Y POR VENCER" : "LISTADO DE CUOTAS VENCIDAS";
            g.DrawString($"CLUB DEPORTIVO GRUPO20 - {titulo}", fontTitulo, Brushes.Black, x, y);
            y += salto;
            g.DrawString($"Fecha de referencia: {fecha:dd/MM/yyyy}", fontNormal, Brushes.Black, x, y);
            y += salto * 2;

            // Cabecera de la tabla
            g.DrawString("ID", fontCabecera, Brushes.Black, x, y);
            g.DrawString("Apellidos", fontCabecera, Brushes.Black, x + 50, y);
            g.DrawString("Nombres", fontCabecera, Brushes.Black, x + 180, y);
            g.DrawString("Periodo", fontCabecera, Brushes.Black, x + 310, y);
            g.DrawString("Vencimiento", fontCabecera, Brushes.Black, x + 400, y);
            g.DrawString("Monto", fontCabecera, Brushes.Black, x + 520, y);
            g.DrawString("Estado", fontCabecera, Brushes.Black, x + 620, y);
            y += salto;

            g.DrawLine(Pens.Black, x, y - 5, x + 720, y - 5);

            // Cuerpo del listado
            int filasPorPagina = 50;
            int filasImpresas = 0;
            while (filaActual < datos.Rows.Count && filasImpresas < filasPorPagina)
            {
                DataRow fila = datos.Rows[filaActual];
                g.DrawString(fila["id"].ToString(), fontNormal, Brushes.Black, x, y);
                g.DrawString(fila["apellidos"].ToString(), fontNormal, Brushes.Black, x + 50, y);
                g.DrawString(fila["nombres"].ToString(), fontNormal, Brushes.Black, x + 180, y);
                g.DrawString(fila["periodo"].ToString(), fontNormal, Brushes.Black, x + 310, y);
                g.DrawString(Convert.ToDateTime(fila["fecha_vencimiento"]).ToString("dd/MM/yyyy"), fontNormal, Brushes.Black, x + 400, y);
                g.DrawString($"${fila["monto"]:N0}", fontNormal, Brushes.Black, x + 520, y);
                g.DrawString(fila["estado"].ToString(), fontNormal, Brushes.Black, x + 620, y);

                y += salto;
                filasImpresas++;
                filaActual++;
            }
            if (filaActual < datos.Rows.Count)
            {
                e.HasMorePages = true;
            }
            else
            {
                filaActual = 0; // reset para futuras impresiones
                e.HasMorePages = false;

                y += salto;
                g.DrawLine(Pens.Black, x, y, x + 720, y);
                y += salto;
                g.DrawString($"Total de registros: {datos.Rows.Count}", fontCabecera, Brushes.Black, x, y);
            }
        }
    }
}
