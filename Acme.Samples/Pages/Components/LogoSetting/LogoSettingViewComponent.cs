using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.SettingManagement.Web.Pages.SettingManagement;

namespace Acme.Samples.Pages.Components.LogoSetting;

public class LogoSettingViewComponent : AbpViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View("~/Pages/Components/LogoSetting/Default.cshtml");
    }
}


public class LogoSettingPageContributor : ISettingPageContributor
{
    public Task ConfigureAsync(SettingPageCreationContext context)
    {
        context.Groups.AddFirst(new SettingPageGroup("LogoSettingId", 
            "Confuguracion de logo", 
            typeof(LogoSettingViewComponent)));
        return Task.CompletedTask;
    }

    public Task<bool> CheckPermissionsAsync(SettingPageCreationContext context)
    {
        return Task.FromResult(true);
    }
}