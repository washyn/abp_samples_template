using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Acme.Identity.Pages.Shared.Components.UserLoginLink
{
    public class UserLoginLinkViewComponent : AbpViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Pages/Shared/Components/UserLoginLink/Default.cshtml");
        }
    }
}
