using Volo.Abp.AutoMapper;
using Volo.Abp.Identity;
using Volo.Abp.Identity.Web;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;
using Volo.Abp.VirtualFileSystem;

namespace Washyn.OrganizationUnit
{
    [DependsOn(typeof(AbpVirtualFileSystemModule))]
    [DependsOn(typeof(AbpIdentityApplicationModule))]
    [DependsOn(typeof(AbpIdentityDomainModule))]
    [DependsOn(typeof(AbpIdentityWebModule))]
    [DependsOn(typeof(AbpAutoMapperModule))]
    [DependsOn(typeof(AbpOuIdentityModule))]
    public class OrganizationUnitModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<OrganizationUnitModule>("Washyn.OrganizationUnit");
            });
            
            ConfigureNavigationServices();
            ConfigureAutoMapper();
        }
    
        private void ConfigureAutoMapper()
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<OrganizationUnitModule>();
            });
        }
    
        private void ConfigureNavigationServices()
        {
            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new AbpOuWebMainMenuContributor());
            });
        }
    }
}