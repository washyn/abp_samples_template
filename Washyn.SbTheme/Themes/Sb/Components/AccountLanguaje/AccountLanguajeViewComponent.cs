using Microsoft.AspNetCore.Mvc;

namespace Acme.Samples.Themes.Sb.Components.AccountLanguaje;

public class AccountLanguajeViewComponent : ViewComponent
{
    public virtual IViewComponentResult Invoke()
    {
        return View("~/Themes/Sb/Components/AccountLanguaje/Default.cshtml");
    }
}