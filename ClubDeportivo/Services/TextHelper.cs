using ClubDeportivo.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClubDeportivo.Services
{
    public static class TextHelper
    {
        public static string ToTitleCase(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return texto;

            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(texto.Trim().ToLower());
        }
        public static string ToUpperCase(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return texto;

            return texto.Trim().ToUpper();
        }

        // Bonus: También puedes agregar lowercase
        public static string ToLowerCase(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return texto;

            return texto.Trim().ToLower();
        }
    }
}
