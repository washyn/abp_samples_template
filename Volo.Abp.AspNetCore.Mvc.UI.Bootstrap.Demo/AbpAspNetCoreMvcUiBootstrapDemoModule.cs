using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
// using Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.Demo;

[DependsOn(
    typeof(AbpAspNetCoreMvcUiThemeSharedModule),
    typeof(AbpAutofacModule)
    )]
public class AbpAspNetCoreMvcUiBootstrapDemoModule : AbpModule
{
    // public override void OnApplicationInitialization(ApplicationInitializationContext context)
    // {
    //     var app = context.GetApplicationBuilder();
    //     var env = context.GetEnvironment();
    //
    //     if (env.IsDevelopment())
    //     {
    //         app.UseDeveloperExceptionPage();
    //     }
    //
    //     app.UseRouting();
    //     app.UseStaticFiles();
    //     app.UseConfiguredEndpoints();
    // }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<AbpAspNetCoreMvcUiBootstrapDemoModule>();
            // if (hostingEnvironment.IsDevelopment())
            // {
            //     /* Using physical files in development, so we don't need to recompile on changes */
            //     options.FileSets.ReplaceEmbeddedByPhysical<TemplateModules>(hostingEnvironment.ContentRootPath);
            // }
        });
    }
}
