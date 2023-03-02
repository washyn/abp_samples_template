using Microsoft.AspNetCore.Mvc;

namespace Acme.Samples.Themes.Sb.Components.Sidenav;

public class SidenavViewComponent: ViewComponent
{
    public virtual IViewComponentResult Invoke()
    {
        return View("~/Themes/Sb/Components/Sidenav/Default.cshtml");
    }
}