using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic.Bundling;
using Volo.Abp.Modularity;
using Washyn.Select2.Boostrap5;
using Washyn.Select2.Boostrap5.Select2;

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