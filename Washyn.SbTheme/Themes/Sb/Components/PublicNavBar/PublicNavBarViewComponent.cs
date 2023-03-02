using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Acme.Samples.Themes.Sb.Components.PublicNavBar;

public class PublicNavBarViewComponent : AbpViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View("~/Themes/Sb/Components/PublicNavBar/Default.cshtml");
    }
}