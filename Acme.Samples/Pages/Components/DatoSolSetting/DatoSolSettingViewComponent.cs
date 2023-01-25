using System.ComponentModel.DataAnnotations;
using Acme.Samples.Services;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Auditing;

namespace Acme.Samples.Pages.Components.DatoSolSetting;

public class DatoSolSettingViewComponent : AbpViewComponent
{
    private readonly DatosSolAppService _datosSolAppService;

    public DatoSolSettingViewComponent(DatosSolAppService datosSolAppService)
    {
        _datosSolAppService = datosSolAppService;
    }

    public virtual async Task<IViewComponentResult> InvokeAsync()
    {
        var data = await _datosSolAppService.GetAsync();
        var model = new UpdateDatosSolSettingViewModel()
        {
            User = data.User,
            Password = data.Password,
        };
        return View("~/Pages/Components/DatoSolSetting/Default.cshtml", model);
    }
}

public class UpdateDatosSolSettingViewModel
{
    [Required]
    public string User { get; set; }
    
    [Required]
    [DisableAuditing]
    public string Password { get; set; }
}