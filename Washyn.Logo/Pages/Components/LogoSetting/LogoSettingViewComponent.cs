using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace LogoManagment.Pages.Components.LogoSetting;

public class LogoSettingViewComponent : AbpViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View("~/Pages/Components/LogoSetting/Default.cshtml");
    }
}