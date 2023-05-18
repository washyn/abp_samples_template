using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Washyn.Billing.OtherSettings.Controllers;

namespace Washyn.Billing.OtherSettings.Pages.Components.CertificateSetting
{
    public class BillingCertificateSettingViewComponent : AbpViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var model = new CertificatePasswordViewModel();
            return View("~/Pages/Components/CertificateSetting/Default.cshtml",model);
        }
    }
}