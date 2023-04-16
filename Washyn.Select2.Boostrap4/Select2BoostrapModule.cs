using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Washyn.Select2.Boostrap4
{
    [DependsOn(typeof(AbpAspNetCoreMvcUiThemeSharedModule))]
    public class Select2BoostrapModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<Select2BoostrapModule>("Washyn.Select2.Boostrap4");
            });
        }
    }
}