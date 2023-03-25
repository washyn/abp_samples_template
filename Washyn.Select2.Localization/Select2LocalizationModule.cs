using System;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.Modularity;

namespace Select2Localization
{
    [DependsOn(typeof(AbpAspNetCoreMvcUiThemeSharedModule))]
    public class SelectLocalizationModule : AbpModule
    {
    }
}
