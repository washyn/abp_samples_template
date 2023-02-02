using Select2Boostrap5;
using Select2Boostrap5.Select2;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic.Bundling;
using Volo.Abp.Modularity;

namespace Acme.Samples;

[DependsOn(typeof(Select2BoostrapModule))]
public class SelectModules : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBundlingOptions>(options =>
        {
            options.StyleBundles.Configure(
                BasicThemeBundles.Styles.Global,
                bundle =>
                {
                    bundle.AddFiles("/global-styles.css");
                    bundle.AddContributors(typeof(Select2BoostrapStyleContributor));
                }
            );
            options.ScriptBundles.Configure(
                BasicThemeBundles.Scripts.Global,
                bundle =>
                {
                    bundle.AddContributors(typeof(Select2BoostrapScriptContributor));
                }
            );
        });
    }
}