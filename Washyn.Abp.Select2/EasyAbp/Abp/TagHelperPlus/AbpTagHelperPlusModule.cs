using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Bundling;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
// using Washyn.Billing.Web.Bundling.Select2;

namespace EasyAbp.Abp.TagHelperPlus
{
    [DependsOn(
        typeof(AbpHttpClientModule),
        typeof(AbpAspNetCoreMvcUiBootstrapModule)
    )]
    [DependsOn(typeof(AbpAspNetCoreMvcUiThemeSharedModule))]
    public class AbpTagHelperPlusModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBundlingOptions>(options =>
            {
                options.ScriptBundles.Configure(
                    StandardBundles.Scripts.Global,
                    bundle =>
                    {
                        // bundle.AddContributors(typeof(Select2LocalizationScriptContributor));
                    }
                );
            });
        }
    }
}