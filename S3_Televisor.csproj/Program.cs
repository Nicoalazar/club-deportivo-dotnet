namespace A2PracticaFormativa
{
    internal static class Test
    {
        
        [STAThread]
        static void Main()
        {
                        
            //Domicilio compartido
            Domicilio domicilio = new Domicilio("Jonte",5299,"Monte Castro");
            
            //Personas
            Persona facundo = new Persona("nico",domicilio);
            Persona camila = new Persona("Camila", domicilio);

            //Televisor compartido
            Televisor tv = new Televisor(
                marca: "Samsung",
                modelo: "Q60B",
                cantPulgadas: 55,
                propietarios: new[] { facundo, camila }
            );

            Console.WriteLine("--Estado Inicial--");
            bool check = tv.CheckUser();
            Console.WriteLine($"¿Inicio exitoso? {check}");
            Console.WriteLine(tv);

            // Intento de cambiar canal con TV apagado (debe fallar)
            Console.WriteLine("\nFacundo intenta poner el canal 45 con el TV apagado...");
            bool ok = tv.CambiarCanal(45);
            Console.WriteLine($"¿Cambio de canal exitoso? {ok}");
            Console.WriteLine(tv);
            // Facundo enciende el TV y cambia a canal 45
            Console.WriteLine("\nFacundo enciende el TV...");
            tv.CambiarEstado();
            Console.WriteLine(tv);
            Console.WriteLine("\nFacundo cambia a canal 45...");
            ok = tv.CambiarCanal(45);
            Console.WriteLine($"¿Cambio de canal exitoso? {ok}");
            Console.WriteLine(tv);

            // Camila avanza canal(+1)
            Console.WriteLine("\nCamila avanza un canal...");
            ok = tv.CambiarCanal();
            Console.WriteLine($"¿Avance de canal exitoso? {ok}");
            Console.WriteLine(tv);

            // Camila prueba el borde: setea 150 y avanza -> vuelve a 1
            Console.WriteLine("\nCamila setea canal 150 y luego avanza (debe volver a 1)...");
            tv.CambiarCanal(150);
            Console.WriteLine(tv);
            tv.CambiarCanal();
            Console.WriteLine(tv);
            Console.WriteLine("\nCamila setea canal 15");
            tv.CambiarCanal(15);

            // Camila apaga el TV
            Console.WriteLine("\nCamila apaga el TV...");
            tv.CambiarEstado();
            Console.WriteLine(tv);

            // Facundo intenta avanzar canal con TV apagado (debe fallar)
            Console.WriteLine("\nFacundo intenta avanzar canal con el TV apagado...");
            ok = tv.CambiarCanal();
            Console.WriteLine($"¿Avance de canal exitoso? {ok}");
            Console.WriteLine(tv);

            Console.WriteLine("\n== Fin de la demo ==");
        }
    }
}