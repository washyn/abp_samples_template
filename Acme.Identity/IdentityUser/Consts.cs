namespace Acme.Identity.IdentityUser
{
    public class Consts
    {
        public enum Roles
        {
            Administrador,
            Usuario
        }
        public class RolConsts
        {
            public const string Administrador = nameof(Roles.Administrador);
            public const string Usuario = nameof(Roles.Usuario);
            public const string AdministradorUsuario = Administrador +","+ Usuario;
        }
    }
}