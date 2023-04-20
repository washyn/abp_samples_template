using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;
using Volo.Abp.VirtualFileSystem;

namespace Washyn.Samples;

public class SamplesPageModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        #region Preconfig setting tutorial

        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            //Add plugin assembly
            mvcBuilder.PartManager.ApplicationParts.Add(new AssemblyPart(typeof(SamplesPageModule).Assembly));
                
#if NET5_0
                //Add views assembly
                var viewDllPath = Path.Combine(Path.GetDirectoryName(typeof(IdentityModule).Assembly.Location), "Acme.Identity.Views.dll");
                var viewAssembly = new CompiledRazorAssemblyPart(Assembly.LoadFrom(viewDllPath));
                mvcBuilder.PartManager.ApplicationParts.Add(viewAssembly);
#else
            //Add CompiledRazorAssemblyPart if the PlugIn module contains razor views.
            mvcBuilder.PartManager.ApplicationParts.Add(new CompiledRazorAssemblyPart(typeof(SamplesPageModule).Assembly)); 
#endif
        });

        #endregion
    }
    
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpNavigationOptions>(options =>
        {
            options.MenuContributors.Add(new SamplePagesMenuContributor());
        });
        
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<SamplesPageModule>("Washyn.Samples");
        });
        
        Configure<AbpAspNetCoreMvcOptions>(options =>
        {
            options.ConventionalControllers.Create(typeof(SamplesPageModule).Assembly);
        });
    }
}


public class SamplePagesMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                "Washyn.Samples",
                "Samples pages",
                "~/samples/FormCOntrols"
            )
        );
    }
}