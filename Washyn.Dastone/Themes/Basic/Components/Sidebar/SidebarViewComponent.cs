using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Washyn.Dastone.Themes.Basic.Components.Sidebar;

public class SidebarViewComponent:AbpViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View("~/Themes/Basic/Components/Sidebar/Default.cshtml");
    }
}