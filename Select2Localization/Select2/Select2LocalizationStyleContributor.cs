using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Packages.Select2;
using Volo.Abp.Modularity;

namespace Select2Localization.Select2
{
    [DependsOn(typeof(Select2StyleContributor))]
    public class Select2LocalizationStyleContributor : BundleContributor
    {
        
    }
}