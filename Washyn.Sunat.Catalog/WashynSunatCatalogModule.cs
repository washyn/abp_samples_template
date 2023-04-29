using Localization.Resources.AbpUi;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;
using Volo.Abp.Application.Services;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap;
using Volo.Abp.Autofac;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;
using Volo.Abp.VirtualFileSystem;
using Washyn.Abp.Select2;
using Washyn.Sunat.Catalog.Select;

namespace Washyn.Sunat.Catalog;

[DependsOn(typeof(AbpAutofacModule))]
[DependsOn(typeof(EasyAbp.Abp.TagHelperPlus.AbpTagHelperPlusModule))]
[DependsOn(typeof(AbpVirtualFileSystemModule))]
[DependsOn(typeof(AbpAspNetCoreMvcUiBootstrapModule))]
[DependsOn(typeof(AbpAspNetCoreMvcModule))]
public class WashynSunatCatalogModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<WashynSunatCatalogModule>("Washyn.Sunat.Catalog");
        });
        
        Configure<AbpNavigationOptions>(options =>
        {
            options.MenuContributors.Add(new SunatCatalogMenuContributor());
        });
        Configure<AbpAspNetCoreMvcOptions>(options =>
        {
            options.ConventionalControllers.Create(typeof(WashynSunatCatalogModule).Assembly);
        });
        
        Configure<Select2ThemeOptions>(options =>
        {
            options.ThemeName = "bootstrap-5";
        });
    }
}

public class SunatCatalogMenuContributor : IMenuContributor
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
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<AbpUiResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                "SunatCatalog.Home",
                l["Sunat catalog"],
                "~/catalog",
                icon: "fas fa-home",
                order: 0
            )
        );
    }
}