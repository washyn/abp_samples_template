using System.Collections.Generic;
using Select2Localization.Select2;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.Modularity;

namespace Select2Boostrap5.Select2
{
    [DependsOn(typeof(Select2LocalizationScriptContributor))]
    public class Select2BoostrapScriptContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            context.Files.AddIfNotContains("/js/dom-event-handler-bootstrap.js");
            context.Files.AddIfNotContains("/js/select2-autofocus-fix.js");
        }
    }
}