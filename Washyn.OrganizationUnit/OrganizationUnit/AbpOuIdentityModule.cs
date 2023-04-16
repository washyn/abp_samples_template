using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Volo.Abp.Identity;

[DependsOn(typeof(AbpVirtualFileSystemModule))]
public class AbpOuIdentityModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<AbpOuIdentityModule>("Volo.Abp.Identity");
        });
    }
}