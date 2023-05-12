using System;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Bundling;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Volo.Abp.AspNetCore.Mvc.UI.Theme.Commercial
{
    [DependsOn(typeof(AbpAspNetCoreMvcUiThemeSharedModule))]
    public class AbpAspNetCoreMvcUiThemeCommercialModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            this.PreConfigure<IMvcBuilder>((Action<IMvcBuilder>) (mvcBuilder =>
                mvcBuilder.AddApplicationPartIfNotExists(typeof (AbpAspNetCoreMvcUiThemeCommercialModule).Assembly)));
        }
        
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            this.Configure<AbpVirtualFileSystemOptions>((Action<AbpVirtualFileSystemOptions>) 
                (options => options.FileSets.AddEmbedded<AbpAspNetCoreMvcUiThemeCommercialModule>()));
            this.Configure<AbpBundlingOptions>((Action<AbpBundlingOptions>) 
                (options => options.ScriptBundles.Configure(StandardBundles.Scripts.Global, (Action<BundleConfiguration>) 
                    (configuration => configuration.AddContributors(typeof (CommercialThemeScriptContributor))))));
        }
        
        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            // AbpAspNetCoreMvcUiThemeCommercialModule.LicenseChecker.Check<AbpAspNetCoreMvcUiThemeCommercialModule>(context);
        }
    }
}