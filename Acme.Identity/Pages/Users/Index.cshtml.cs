using Acme.Identity.IdentityUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Acme.Identity.Pages.Users
{
    [Authorize(Roles = Consts.RolConsts.Administrador)]
    public class Index : PageModel
    {
        public void OnGet()
        {
            
        }
    }
}