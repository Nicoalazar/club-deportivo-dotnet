namespace ClubDeportivo
{
    public class Persona
    
        {
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string TipoDocumento { get; set; } // DNI / Pasaporte / Extranjero
            public string DNI { get; set; }
            public string Email { get; set; }
            public string Telefono  { get; set; }
            public bool EsSocio { get; set; } // true = socio, false = no socio

            public Persona() { }

            public Persona(string nombre, string apellido, string tipoDocumento, string DNI, string Email,string Telefono, bool esSocio = false)
            {
                this.Nombre = nombre;
                this.Apellido = apellido;
                this.TipoDocumento = tipoDocumento;
                this.DNI = DNI;
                this.Email = Email;
                this.Telefono = Telefono;
                this.EsSocio = esSocio;
            }//nose si aca iria el tema de clasificar si persona es socio o no ?
        }
    }
}
}
