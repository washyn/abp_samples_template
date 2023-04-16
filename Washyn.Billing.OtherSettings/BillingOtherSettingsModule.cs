using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Packages.CropperJs;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Bundling;
using Volo.Abp.BlobStoring;
using Volo.Abp.BlobStoring.FileSystem;
using Volo.Abp.Modularity;
using Volo.Abp.SettingManagement.Web.Pages.SettingManagement;
using Volo.Abp.VirtualFileSystem;
using Washyn.BillingOtherSettings.Controllers;

namespace Washyn.BillingOtherSettings
{
    [DependsOn(typeof(AbpAspNetCoreMvcUiThemeSharedModule))]
    [DependsOn(typeof(AbpAspNetCoreMvcModule))]
    [DependsOn(typeof(Volo.Abp.Settings.AbpSettingsModule))]
    [DependsOn(typeof(Volo.Abp.BlobStoring.FileSystem.AbpBlobStoringFileSystemModule))]
    public class BillingOtherSettingsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var hostingEnvironment =  context.Services.GetHostingEnvironment();
            Configure<AbpBlobStoringOptions>(options =>
            {
                options.Containers.ConfigureDefault(container =>
                {
                    container.UseFileSystem(fileSystem =>
                    {
                        fileSystem.BasePath = hostingEnvironment.WebRootPath;
                    });
                });
            });

            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<BillingOtherSettingsModule>();
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
            });
            
            Configure<AbpBundlingOptions>(options =>
            {
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
