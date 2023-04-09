using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Acme.Identity.Pages.Components.UserLoginLink
{
    public class UserLoginLinkViewComponent : AbpViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Pages/Components/UserLoginLink/Default.cshtml");
        }
    }
}
