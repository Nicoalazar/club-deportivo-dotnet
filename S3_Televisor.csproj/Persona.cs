using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2PracticaFormativa
{
    internal class Persona
    {
        public string Nombre { get; }
        public Domicilio Domicilio { get; }

        public Persona(string nombre, Domicilio domicilio)
        {
            this.Nombre = nombre;
            this.Domicilio = domicilio;
        }
        public override string ToString() => $"{Nombre} {(Domicilio)}";
    }
}
