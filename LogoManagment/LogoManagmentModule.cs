using LogoManagment.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Bundling;
using Volo.Abp.BlobStoring;
using Volo.Abp.BlobStoring.FileSystem;
using Volo.Abp.Modularity;
using Volo.Abp.SettingManagement.Web.Pages.SettingManagement;
using Volo.Abp.VirtualFileSystem;

namespace LogoManagment
{
    [DependsOn(typeof(AbpAspNetCoreMvcUiThemeSharedModule))]
    [DependsOn(typeof(AbpAspNetCoreMvcModule))]
    [DependsOn(typeof(Volo.Abp.Settings.AbpSettingsModule))]
    [DependsOn(typeof(Volo.Abp.BlobStoring.FileSystem.AbpBlobStoringFileSystemModule))]
    public class LogoManagmentModule : AbpModule
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
                options.FileSets.AddEmbedded<LogoManagmentModule>();
            });
            
            Configure<SettingManagementPageOptions>(options =>
            {
                options.Contributors.Add(new LogoSettingPageContributor());
            });
            
            Configure<AbpBundlingOptions>(options =>
            {
                options.StyleBundles.Configure(
                    StandardBundles.Styles.Global,
                    bundle =>
                    {
                        bundle.AddFiles("/logo-style.css");
                    }
                );
            });
            
            Configure<AbpBundlingOptions>(options =>
            {
                options.ScriptBundles.Configure(
                    StandardBundles.Scripts.Global,
                    bundle =>
                    {
                        bundle.AddFiles("/logo-script.js");
                    }
                );
            });
        }
    }
}
