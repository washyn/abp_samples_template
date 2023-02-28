using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Acme.Samples.Themes.Sb.Components.PublicNavBar;

public class PublicNavBarViewComponent : AbpViewComponent
{
    public IViewComponentResult Invoke(string name)
    {
        return View("~/Themes/Sb/Components/PublicNavBar/Default.cshtml");
    }
}