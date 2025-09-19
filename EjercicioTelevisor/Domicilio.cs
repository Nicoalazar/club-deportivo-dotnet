using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2PracticaFormativa
{
    internal class Domicilio
    {
        public string Calle {  get; }
        public int Numero { get; }
         public string Barrio { get; }

        public Domicilio(string calle, int numero, string barrio)
        {
            this.Calle = calle;
            this.Numero = numero;
            this.Barrio = barrio;
        }
        public override string ToString() => $"{Calle} {Numero}, {Barrio}";
    }
}
