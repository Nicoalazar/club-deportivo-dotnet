using S4_Abstraer_Y_Encapsular;

class Program
{
    static void Main()
    {
        // Crear un empleado
        Empleado emp1 = new Empleado("Juan Pérez", 30, "Analista de Sistemas");

        // Crear la empresa y asignar el empleado principal
        Empresa empresa = new Empresa("Tech Solutions S.A.", emp1);

        // Mostrar información
        empresa.MostrarEmpleadoPrincipal();

        Console.ReadKey();
    }
}
