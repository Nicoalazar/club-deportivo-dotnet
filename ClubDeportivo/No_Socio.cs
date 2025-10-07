using System;

namespace ClubDeportivo
{
    // Clase NoSocio que hereda de Persona
    public class NoSocio : Persona
    {
        // =============================================================
        // PROPIEDADES (ATRIBUTOS)
        // Coinciden con el diagrama UML para 'No socios'
        // =============================================================

        // apto_físico
        public string AptoFisico { get; set; }

        // carnet_noSocio (Puede ser un ID temporal o genérico)
        public string CarnetNoSocio { get; set; }

        // Constructor que llama al constructor de la clase base (Persona)
        public NoSocio(string nombre, string apellido, string tipoDocumento,string dni, string apto, string carnetNoSocio)
            : base(nombre, apellido,tipoDocumento, dni)
        {
            this.AptoFisico = apto;
            this.CarnetNoSocio = carnetNoSocio;
        }

     
        
        
       
    }//solo es comentario de prueba
}
