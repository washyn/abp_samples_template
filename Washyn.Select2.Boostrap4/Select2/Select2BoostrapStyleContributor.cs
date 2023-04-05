﻿using System.Collections.Generic;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Packages.Select2;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace Washyn.Select2.Boostrap5.Select2
{
    [DependsOn(typeof(Select2StyleContributor))]
    public class Select2BoostrapStyleContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            // if (CultureHelper.IsRtl)
            // {
            //     context.Files.AddIfNotContains("/libs/select2-bootstrap-5-theme/dist/select2-bootstrap-5-theme.rtl.css");
            // }
            // else
            // {
            //     context.Files.AddIfNotContains("/libs/select2-bootstrap-5-theme/dist/select2-bootstrap-5-theme.css");
            // }
            context.Files.AddIfNotContains("/libs/select2-bootstrap4-theme/dist/select2-bootstrap4.css");
        }
    }
}