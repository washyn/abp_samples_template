using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Alerts;

namespace Acme.Samples.Themes.Basic.Components.Sidebar;

public class SidebarViewComponent:AbpViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View("~/Themes/Basic/Components/Sidebar/Default.cshtml");
    }
}