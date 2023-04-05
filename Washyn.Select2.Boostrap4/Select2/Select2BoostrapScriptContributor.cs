using System.Collections.Generic;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Packages.Select2;
using Volo.Abp.Modularity;

namespace Washyn.Select2.Boostrap5.Select2
{
    [DependsOn(typeof(Select2ScriptContributor))]
    public class Select2BoostrapScriptContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            // context.Files.AddIfNotContains("/js/dom-event-handler-bootstrap.js");
            // TODO: fix for unuse this
            // context.Files.AddIfNotContains("/js/select2-autofocus-fix.js");
        }
    }
}