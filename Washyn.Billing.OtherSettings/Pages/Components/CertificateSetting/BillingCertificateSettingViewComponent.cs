using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Washyn.BillingOtherSettings.Controllers;

namespace Washyn.BillingOtherSettings.Pages.Components.CertificateSetting;

public class BillingCertificateSettingViewComponent : AbpViewComponent
{
    public IViewComponentResult Invoke()
    {
        var model = new CertificatePasswordViewModel();
        return View("~/Pages/Components/CertificateSetting/Default.cshtml",model);
    }
}