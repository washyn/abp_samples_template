using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Volo.Abp.Identity;

[DependsOn(typeof(AbpVirtualFileSystemModule))]
[DependsOn(typeof(AbpAutoMapperModule))]
public class AbpOuIdentityModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<AbpOuIdentityModule>("Volo.Abp.Identity");
        });
        
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<AbpOuIdentityModule>();
        });
        
        Configure<AbpAspNetCoreMvcOptions>(options =>
        {
            options.ConventionalControllers.Create(typeof(AbpOuIdentityModule).Assembly);
        });
    }
}