using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Bundling;
using Volo.Abp.Modularity;

namespace Volo.Abp.AspNetCore.Mvc.UI.Theme.Commercial
{
    [DependsOn(typeof(SharedThemeGlobalScriptContributor))]
    public class CommercialThemeScriptContributor : BundleContributor
    {
        // TODO: Agregar script si es que necesita, al parecer es una dependencia fake.
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            base.ConfigureBundle(context);
        }
    }
}