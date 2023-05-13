using Localization.Resources.AbpUi;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap;
using Volo.Abp.Autofac;
using Volo.Abp.Http.ProxyScripting.Generators.JQuery;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;
using Washyn.Abp.Select2;

namespace Washyn.Sunat.Catalog;

[DependsOn(typeof(SunatCatalogSharedModule))]
[DependsOn(typeof(EasyAbp.Abp.TagHelperPlus.AbpTagHelperPlusModule))]
[DependsOn(typeof(AbpAspNetCoreMvcUiBootstrapModule))]
[DependsOn(typeof(AbpAspNetCoreMvcModule))]
public class WashynSunatCatalogModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpNavigationOptions>(options =>
        {
            options.MenuContributors.Add(new SunatCatalogMenuContributor());
        });

        // Configure<AbpAspNetCoreMvcOptions>(options =>
        // {
        //     options.ConventionalControllers.Create(typeof(WashynSunatCatalogModule).Assembly);
        // });
        // TODO: Improve, disabling api
        Configure<DynamicJavaScriptProxyOptions>(options =>
        {
            // options.DisableModule("WashynSunatCatalogModule");
            // options.DisableModule("washyn.sunat.catalog.controllers");
            // options.DisableModule("app");
            // options.DisableModule("catalog");
            // options.DisableModule("washyn.sunat.catalog.controllers");
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