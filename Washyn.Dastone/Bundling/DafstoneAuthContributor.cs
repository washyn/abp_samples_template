using System.Collections.Generic;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace Washyn.Dastone.Bundling;

// Improvements: add another plugins
public class DafstonePluginScriptContributor : BundleContributor
{
    public override void ConfigureBundle(BundleConfigurationContext context)
    {
        context.Files.Add("/plugins/daterangepicker/daterangepicker.js");
    }
}


public class DafstonePluginStyleContributor : BundleContributor
{
    public override void ConfigureBundle(BundleConfigurationContext context)
    {
        context.Files.Add("/plugins/daterangepicker/daterangepicker.css");
    }
}

public class DafstoneAuthContributor
{
    public static class Styles
    {
        public const string Global = "Dafstone.Account";
    }

    public static class Scripts
    {
        public const string Global = "Dafstone.Account";
    }
}

public class DafstoneAppContributor
{
    public static class Styles
    {
        public const string Global = "Dafstone.App";
    }

    public static class Scripts
    {
        public const string Global = "Dafstone.App";
    }
}

public class DafstoneAuthStyleContributor : BundleContributor
{
    public override void ConfigureBundle(BundleConfigurationContext context)
    {
        context.Files.ReplaceOne("/libs/bootstrap/css/bootstrap.css","/assets/css/bootstrap.min.css");
        context.Files.Add("/assets/css/icons.min.css");
        context.Files.Add("/assets/css/app.min.css");
    }
}

public class DafstoneAuthScriptContributor : BundleContributor
{
    public override void ConfigureBundle(BundleConfigurationContext context)
    {
        context.Files.ReplaceOne("/libs/jquery/jquery.js","/assets/js/jquery.min.js");
        context.Files.ReplaceOne("/libs/bootstrap/js/bootstrap.bundle.js","/assets/js/bootstrap.bundle.min.js");

        context.Files.Add("/assets/js/waves.js");
        context.Files.Add("/assets/js/feather.min.js");
        context.Files.Add("/assets/js/simplebar.min.js");
    }
}


public class DafstoneAppStyleContributor : BundleContributor
{
    public override void ConfigureBundle(BundleConfigurationContext context)
    {
        context.Files.ReplaceOne("/libs/bootstrap/css/bootstrap.css", "/assets/css/bootstrap.min.css");
        
        context.Files.Add("/assets/css/icons.min.css");
        context.Files.Add("/assets/css/metisMenu.min.css");

        context.Files.Add("/themes/dastone/layout.css");
    }
}

public class DafstoneAppScriptContributor : BundleContributor
{
    public override void ConfigureBundle(BundleConfigurationContext context)
    {
        context.Files.ReplaceOne("/libs/jquery/jquery.js","/assets/js/jquery.min.js");
        context.Files.ReplaceOne("/libs/bootstrap/js/bootstrap.bundle.js","/assets/js/bootstrap.bundle.min.js");

        context.Files.Add("/assets/js/metismenu.min.js");
        context.Files.Add("/assets/js/waves.js");
        context.Files.Add("/assets/js/feather.min.js");
        context.Files.Add("/assets/js/simplebar.min.js");
        context.Files.Add("/assets/js/moment.js");
    }
}
