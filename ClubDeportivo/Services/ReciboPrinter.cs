using ClubDeportivo.Config;
using ClubDeportivo.Models;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;

namespace ClubDeportivo.Services
{
    public class ReciboPrinter
    {
        private Persona persona;
        private readonly int paramId;
        private readonly string Categoria;
        private readonly string periodo;
        private readonly string medioPago;
        private readonly DateTime fecha;
        private readonly string tipoRecibo;

        private PrintDocument printDoc;

        public ReciboPrinter(int Id, string Categoria, string periodo, string medioPago, string tipoRecibo)
        {
            this.paramId = Id;
            this.Categoria = Categoria;
            this.periodo = periodo;
            this.medioPago = medioPago;
            this.fecha = DateTime.Now;
            this.tipoRecibo = tipoRecibo;

            this.persona = search();


            printDoc = new PrintDocument();
            printDoc.PrintPage += PrintDoc_PrintPage;
        }

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

        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics!;
            Font fontNormal = new Font("Arial", 10);
            Font fontBold = new Font("Arial", 11, FontStyle.Bold);
            string titulo = tipoRecibo.ToUpper() == "CUOTA"
                ? "RECIBO DE PAGO DE CUOTA"
                : "RECIBO DE PAGO DE ACTIVIDAD";

            int y = 20;
            int salto = 22;

            g.DrawString($"CLUB DEPORTIVO GRUPO20 - {titulo}", fontBold, Brushes.Black, 50, y); y += salto;
            g.DrawString($"Fecha: {fecha:dd/MM/yyyy HH:mm}", fontNormal, Brushes.Black, 50, y); y += salto;
            g.DrawString($"Persona: {persona.Apellidos}, {persona.Nombres}", fontNormal, Brushes.Black, 50, y); y += salto;
            g.DrawString($"Documento: {persona.TipoDocumento} {persona.NumeroDocumento}", fontNormal, Brushes.Black, 50, y); y += salto;
            if (tipoRecibo.ToUpper() == "CUOTA")
            {
                g.DrawString($"Período: {periodo}", fontNormal, Brushes.Black, 50, y);
                y += salto;
            }
            else
            {
                g.DrawString("Tipo: Actividad diaria", fontNormal, Brushes.Black, 50, y);
                y += salto;
            }
            if (tipoRecibo.ToUpper() == "CUOTA")
            {
                g.DrawString($"Monto abonado: ${ValoresCuotas.MontoCuota:N2}", fontNormal, Brushes.Black, 50, y);
                y += salto;
            }
            else
            {
                g.DrawString($"Monto abonado: ${ValoresCuotas.MontoActividad:N2}", fontNormal, Brushes.Black, 50, y);
                y += salto;
            }
            g.DrawString($"Medio de pago: {medioPago}", fontNormal, Brushes.Black, 50, y); y += salto;
            g.DrawString($"Atendido por: {SesionUsuario.Usuario}", fontNormal, Brushes.Black, 50, y); y += salto * 2;
            g.DrawString("¡Gracias por su pago!", fontBold, Brushes.Black, 50, y);

            // Línea separadora
            g.DrawLine(Pens.Black, 50, y + salto, 500, y + salto);

            e.HasMorePages = false;
        }

        private Persona search()
        {
            using var cn = Conexion.getInstancia().CrearConcexion();
            cn.Open();
            using var cmd = new MySqlCommand("SELECT " +
                "Id,Categoría,Nombres,Apellidos,Sexo,Tipo,NroDocumento,Nacimiento,Email" +
                " FROM grupo20_clubdeportivo.personas_data " +
                "WHERE id = @id AND Categoría = @categoria", cn);
            cmd.Parameters.AddWithValue("@id", paramId);
            cmd.Parameters.AddWithValue("@categoria", Categoria);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                persona = new Persona(
                    reader.GetString("nombres"),
                    reader.GetString("apellidos"),
                    reader.GetString("sexo"),
                    reader.GetString("Tipo"),
                    reader.GetString("NroDocumento"),
                    reader.GetDateTime ("Nacimiento"),
                    reader.GetString("email"),
                    "",
                    ""
                    );
                return persona;
            }else
            {
                Persona persona = null!;
                return persona;
            }
        }
    }
}
