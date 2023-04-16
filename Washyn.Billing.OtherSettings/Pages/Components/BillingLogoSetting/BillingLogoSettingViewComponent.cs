using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Washyn.Billing.OtherSettings.Pages.Components.BillingLogoSetting;

public class BillingLogoSettingViewComponent : AbpViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View("~/Pages/Components/BillingLogoSetting/Default.cshtml");
    }
}