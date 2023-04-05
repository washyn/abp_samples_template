using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Bundling;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Washyn.Select2.Boostrap5;
using Washyn.Select2.Boostrap5.Select2;
using Washyn.Select2.Localization;
using Washyn.Select2.Localization.Select2;


namespace EasyAbp.Abp.TagHelperPlus
{
    [DependsOn(typeof(AbpAspNetCoreMvcUiThemeSharedModule))]
    [DependsOn(typeof(AbpAspNetCoreMvcUiBootstrapModule))]
    [DependsOn(typeof(AbpHttpClientModule))]
    [DependsOn(typeof(SelectLocalizationModule))]
    [DependsOn(typeof(Select2BoostrapModule))]
    public class AbpTagHelperPlusModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBundlingOptions>(options =>
            {
                options.StyleBundles.Configure(
                    BasicThemeBundles.Styles.Global,
                    bundle =>
                    {
                        bundle.Contributors.Add(typeof(Select2LocalizationStyleContributor));
                        bundle.Contributors.Add(typeof(Select2BoostrapStyleContributor));
                    }
                );
                
                options.ScriptBundles.Configure(
                    BasicThemeBundles.Scripts.Global,
                    bundle =>
                    {
                        bundle.Contributors.Add(typeof(Select2LocalizationScriptContributor));
                        bundle.Contributors.Add(typeof(Select2BoostrapScriptContributor));
                    }
                );
            });
        }
    }
}