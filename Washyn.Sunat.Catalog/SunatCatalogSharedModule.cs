using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Washyn.Sunat.Catalog
{

    [DependsOn(typeof(AbpVirtualFileSystemModule))]
    public class SunatCatalogSharedModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<SunatCatalogSharedModule>("Washyn.Sunat.Catalog");
            });
        }
    }
}