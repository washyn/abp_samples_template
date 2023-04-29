using System.Collections.Generic;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.Modularity;
using Washyn.Select2.Localization.Select2;

namespace Washyn.Select2.Boostrap5.Select2
{
    [DependsOn(typeof(Select2LocalizationScriptContributor))]
    public class Select2BoostrapScriptContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            // context.Files.AddIfNotContains("/js/dom-event-handler-bootstrap.js");
            // TODO: fix for unuse this, for these migrate to minor version of jquery, select2 and jquery recent vetsions generate this issue
            context.Files.AddIfNotContains("/js/select2-autofocus-fix.js");
        }
    }
}