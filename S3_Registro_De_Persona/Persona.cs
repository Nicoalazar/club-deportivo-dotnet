using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3_Registro_De_Postulantes
{
    public class Persona
    {
        private string? nombre;
        private string? apellido;
        private string? tipo;
        private int documento;
        public Persona(string nombre, string apellido, string tipo, int
       documento, bool esSocio = false)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Tipo = tipo;
            this.Documento = documento;
            this.EsSocio = esSocio;
        }
        public string? Nombre { get => nombre; set => nombre = value; }
        public string? Apellido { get => apellido; set => apellido = value; }
        public string? Tipo { get => tipo; set => tipo = value; }
        public int Documento { get => documento; set => documento = value; }
        public bool EsSocio { get; set; }

    }
}
