using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.MultiTenancy;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Toolbars;
using Volo.Abp.AspNetCore.Mvc.UI.Theming;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;
using Washyn.Dastone.Bundling;
using Washyn.Dastone.Toolbars;

namespace Washyn.Dastone;

[DependsOn(
    typeof(AbpAspNetCoreMvcUiThemeSharedModule),
    typeof(AbpAspNetCoreMvcUiMultiTenancyModule)
    )]
public class AbpAspNetCoreMvcUiDastoneThemeModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(AbpAspNetCoreMvcUiDastoneThemeModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpThemingOptions>(options =>
        {
            options.Themes.Add<DastoneTheme>();

            if (options.DefaultThemeName == null)
            {
                options.DefaultThemeName = DastoneTheme.Name;
            }
        });

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<AbpAspNetCoreMvcUiDastoneThemeModule>("Washyn.Dastone");
        });

        Configure<AbpToolbarOptions>(options =>
        {
            options.Contributors.Add(new BasicThemeMainTopToolbarContributor());
        });

        Configure<AbpBundlingOptions>(options =>
        {
            options
                .StyleBundles
                .Add(DafstoneAppContributor.Styles.Global, bundle =>
                {
                    bundle
                        .AddBaseBundles(StandardBundles.Styles.Global)
                        .AddContributors(typeof(DafstoneAppStyleContributor))
                        .AddContributors(typeof(DafstonePluginStyleContributor))
                        .AddFiles("/assets/css/app.min.css")
                        ;
                });

            options
                .ScriptBundles
                .Add(DafstoneAppContributor.Scripts.Global, bundle =>
                {
                    bundle
                        .AddBaseBundles(StandardBundles.Scripts.Global)
                        .AddContributors(typeof(DafstoneAppScriptContributor))
                        .AddContributors(typeof(DafstonePluginScriptContributor))
                        .AddFiles("/assets/js/app.js")
                        ;
                });

            #region Account layout

            options.StyleBundles.Add(DafstoneAuthContributor.Styles.Global, configuration =>
            {
                configuration.AddBaseBundles(StandardBundles.Styles.Global)
                    .AddContributors(typeof(DafstoneAuthStyleContributor))
                    ;
            });

            options.ScriptBundles.Add(DafstoneAuthContributor.Scripts.Global, configuration =>
            {
                configuration.AddBaseBundles(StandardBundles.Scripts.Global)
                    .AddContributors(typeof(DafstoneAuthScriptContributor))
                    ;
            });
            
            #endregion
        });
    }
}
