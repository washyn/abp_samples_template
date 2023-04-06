using Acme.Identity.IdentityUser;
using Volo.Abp.Users;

namespace Acme.Identity.Others;


public static class CurrentUserExtensions
{
    public static bool IsUser(this ICurrentUser currentUser)
    {
        return currentUser.IsInRole(Consts.RolConsts.Usuario);
    }
    public static bool IsAdmin(this ICurrentUser currentUser)
    {
        return currentUser.IsInRole(Consts.RolConsts.Administrador);
    }
}