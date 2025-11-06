// ClubDeportivo.Services/SesionUsuario.cs
namespace ClubDeportivo.Services
{
    public static class SesionUsuario
    {
        public static string? Usuario { get; private set; }
        public static string? Rol { get; private set; }
        public static DateTime FechaLogin { get; private set; }

        public static void IniciarSesion(string usuario, string rol)
        {
            Usuario = usuario;
            Rol = rol;
            FechaLogin = DateTime.Now;
        }

        public static void CerrarSesion()
        {
            Usuario = null;
            Rol = null;
        }

        public static bool EstaAutenticado()
        {
            return !string.IsNullOrEmpty(Usuario);
        }

        public static bool EsAdministrador()
        {
            return Rol?.ToLower() == "administrador";
        }
    }
}