using System.Collections.Generic;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Washyn.Select2.Localization.Select2;

namespace Washyn.Select2.Boostrap5.Select2
{
    [DependsOn(typeof(Select2LocalizationStyleContributor))]
    public class Select2BoostrapStyleContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            if (CultureHelper.IsRtl)
            {
                context.Files.AddIfNotContains("/libs/select2-bootstrap-5-theme/dist/select2-bootstrap-5-theme.rtl.css");
            }
            else
            {
                context.Files.AddIfNotContains("/libs/select2-bootstrap-5-theme/dist/select2-bootstrap-5-theme.css");
            }
        }
    }
}