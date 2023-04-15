using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Packages.CropperJs;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Bundling;
using Volo.Abp.BlobStoring;
using Volo.Abp.BlobStoring.FileSystem;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.SettingManagement.Web;
using Volo.Abp.SettingManagement.Web.Pages.SettingManagement;
using Volo.Abp.VirtualFileSystem;
using Washyn.Logo.Controllers;

// app logo
namespace Washyn.Logo
{
    [DependsOn(typeof(AbpAspNetCoreMvcUiThemeSharedModule))]
    [DependsOn(typeof(AbpAspNetCoreMvcModule))]
    [DependsOn(typeof(Volo.Abp.Settings.AbpSettingsModule))]
    [DependsOn(typeof(AbpBlobStoringFileSystemModule))]
    [DependsOn(typeof(AbpLocalizationModule))]
    [DependsOn(typeof(AbpSettingManagementWebModule))]
    public class LogoManagmentModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var hostingEnvironment = context.Services.GetHostingEnvironment();
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
                options.FileSets.AddEmbedded<LogoManagmentModule>("Washyn.Logo");
            });
            Configure<SettingManagementPageOptions>(options =>
            {
                options.Contributors.Add(new LogoSettingPageContributor());
            });
            Configure<AbpBundlingOptions>(options =>
            {
                options.StyleBundles.Configure(StandardBundles.Styles.Global,
                    bundle => { bundle.Contributors.Add(typeof(CropperJsStyleContributor)); });
                options.ScriptBundles.Configure(StandardBundles.Scripts.Global,
                    bundle => { bundle.Contributors.Add(typeof(CropperJsScriptContributor)); });
            });
            Configure<AbpBundlingOptions>(options =>
            {
                options.StyleBundles.Configure(StandardBundles.Styles.Global,
                    bundle => { bundle.AddFiles("/Pages/Components/logo-style.css"); });
            });
#if !NET6_0_OR_GREATER
            Configure<AbpBundlingOptions>(options =>
            {
                options.ScriptBundles.Configure(
                    typeof(Volo.Abp.SettingManagement.Web.Pages.SettingManagement.IndexModel).FullName,
                    configuration =>
                    {
                        configuration.AddFiles(
                            "/Pages/Components/ProfileManagement/ProfilePictureSetting/Default.cshtml.js");
                    });
            });
#endif
        }
    }
}