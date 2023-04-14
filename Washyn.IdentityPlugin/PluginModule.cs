using Microsoft.Extensions.Logging;
using Volo.Abp.DependencyInjection;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.Modularity;

namespace Washyn.IdentityPlugin;

[DependsOn(typeof(AbpAspNetCoreMvcUiThemeSharedModule))]
public class IdentityPlugInModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            //Add plugin assembly
            mvcBuilder.PartManager.ApplicationParts.Add(new AssemblyPart(typeof(IdentityPlugInModule).Assembly));

            //Add CompiledRazorAssemblyPart if the PlugIn module contains razor views.
            mvcBuilder.PartManager.ApplicationParts.Add(new CompiledRazorAssemblyPart(typeof(IdentityPlugInModule).Assembly));
        });
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var myService = context.ServiceProvider
            .GetRequiredService<MyService>();

        myService.Initialize();
    }
}


public class MyService : ITransientDependency
{
    private readonly ILogger<MyService> _logger;

    public MyService(ILogger<MyService> logger)
    {
        _logger = logger;
    }

    public void Initialize()
    {
        _logger.LogInformation("MyService has been initialized");
    }
}