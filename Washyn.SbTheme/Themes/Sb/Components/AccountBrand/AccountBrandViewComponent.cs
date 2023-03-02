using Microsoft.AspNetCore.Mvc;

namespace Acme.Samples.Themes.Sb.Components.LoginBrand;

public class AccountBrandViewComponent : ViewComponent
{
    public virtual IViewComponentResult Invoke()
    {
        return View("~/Themes/Sb/Components/AccountBrand/Default.cshtml");
    }
}