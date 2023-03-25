using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.Modularity;

namespace Washyn.Select2.Localization
{
    [DependsOn(typeof(AbpAspNetCoreMvcUiThemeSharedModule))]
    public class SelectLocalizationModule : AbpModule
    {
    }
}
