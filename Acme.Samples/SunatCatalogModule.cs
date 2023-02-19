using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Acme.Samples;

[DependsOn(typeof(AbpVirtualFileSystemModule))]
public class SunatCatalogModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            
        });
    }
}