using System.Collections.Generic;
using Microsoft.Extensions.Options;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Packages.Select2;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace Washyn.Select2.Localization.Select2
{
    [DependsOn(typeof(Select2ScriptContributor))]
    public class Select2LocalizationScriptContributor : BundleContributor
    {
        public const string PackageName = "select2";
        
        public override void ConfigureDynamicResources(BundleConfigurationContext context)
        {
            var fileName = context.LazyServiceProvider
                .LazyGetRequiredService<IOptions<AbpLocalizationOptions>>()
                .Value
                .GetCurrentUICultureLanguageFilesMap(PackageName);
            var filePath = $"/libs/select2/js/i18n/{fileName}.js";
            if (context.FileProvider.GetFileInfo(filePath).Exists)
            {
                context.Files.AddIfNotContains(filePath);
            }
        }
    }
}