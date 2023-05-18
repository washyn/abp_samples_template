using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Packages.CropperJs;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Bundling;
using Volo.Abp.Modularity;
using Volo.Abp.SettingManagement.Web.Pages.SettingManagement;
using Volo.Abp.VirtualFileSystem;
using Washyn.Billing.OtherSettings.Controllers;

namespace Washyn.Billing.OtherSettings
{
    [DependsOn(typeof(AbpAspNetCoreMvcUiThemeSharedModule))]
    [DependsOn(typeof(AbpAspNetCoreMvcModule))]
    [DependsOn(typeof(Volo.Abp.Settings.AbpSettingsModule))]
    [DependsOn(typeof(Volo.Abp.BlobStoring.AbpBlobStoringModule))]
    public class BillingOtherSettingsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var hostingEnvironment =  context.Services.GetHostingEnvironment();

            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<BillingOtherSettingsModule>("Washyn.Billing.OtherSettings");
            });
            
            Configure<SettingManagementPageOptions>(options =>
            {
                options.Contributors.Add(new BillingLogoSettingPageContributor());
                options.Contributors.Add(new BillingCetificateSettingPageContributor());
            });

            #region Scripts and styles

            Configure<AbpBundlingOptions>(options =>
            {
                options.StyleBundles.Configure(
                    StandardBundles.Styles.Global,
                    bundle =>
                    {
                        bundle.Contributors.Add(typeof(CropperJsStyleContributor));
                    }
                );
                options.ScriptBundles.Configure(
                    StandardBundles.Scripts.Global,
                    bundle =>
                    {
                        bundle.Contributors.Add(typeof(CropperJsScriptContributor));
                    }
                );
            });
            
            // Configure<AbpBundlingOptions>(options =>
            // {
            //     options.StyleBundles
            //         .Configure(typeof(Volo.Abp.SettingManagement.Web.Pages.SettingManagement.IndexModel).FullName,
            //             configuration =>
            //             {
            //                 configuration.Contributors.Add(typeof(CropperJsStyleContributor));
            //                 configuration.AddFiles("/Pages/Components/LogoSetting/Default.cshtml.css");
            //             });
            //     
            //     options.ScriptBundles
            //         .Configure(typeof(Volo.Abp.SettingManagement.Web.Pages.SettingManagement.IndexModel).FullName,
            //             configuration =>
            //             {
            //                 configuration.Contributors.Add(typeof(CropperJsScriptContributor));
            //                 configuration.AddFiles("/Pages/Components/LogoSetting/Default.cshtml.js");
            //             });
            // });
            
            #endregion
        }
    }
}
