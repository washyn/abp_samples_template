using Microsoft.AspNetCore.Mvc;

namespace Acme.Samples.Themes.Sb.Components.Footer;

public class FooterViewComponent : ViewComponent
{
    public virtual IViewComponentResult Invoke()
    {
        return View("~/Themes/Sb/Components/Footer/Default.cshtml");
    }
}