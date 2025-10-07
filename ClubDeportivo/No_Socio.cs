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
        public NoSocio(string nombre, string apellido, string dni, string email, string telefono,
                       string apto, string carnetNoSocio)
            : base(nombre, apellido, dni, email, telefono)
        {
            this.AptoFisico = apto;
            this.CarnetNoSocio = carnetNoSocio;
        }

        // Constructor vacío
        public NoSocio() { }

        
        public override void Inscribir()
        {
            // 1. Ejecutar la inscripción de los datos básicos en la tabla Persona
            base.Inscribir();

            // 2. Lógica específica del no socio (insertar en tabla No_Socio).
            Console.WriteLine($"Registrando apto y carnet en tabla NO_SOCIO.");

            // Aquí iría el INSERT INTO No_Socio (id_persona, apto_fisico, carnet_noSocio) VALUES (...)
        }
    }//solo es comentario de prueba
}
