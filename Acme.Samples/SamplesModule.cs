using Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;
// using Washyn.SecurityLogs;
// using Washyn.SbTheme;
// using Washyn.Billing.OtherSettings;
// using Washyn.Logo;
// using Washyn.OrganizationUnit;
// using Washyn.SecurityLogs;
// using Washyn.SbTheme;
// using Washyn.Billing.OtherSettings;
// using Washyn.Dastone;
// using Washyn.Logo;
// using Washyn.ProfilePicture;
// using Washyn.Widgets;
// using Washyn.Sunat.Catalog;
// using EasyAbp.LoggingManagement.Web;

namespace Acme.Samples;

[DependsOn(typeof(AbpAspNetCoreMvcUiBasicThemeModule))]
[DependsOn(typeof(AbpAutofacModule))]
[DependsOn(typeof(TemplateModules))]
// [DependsOn(typeof(LogoManagmentModule))]
// [DependsOn(typeof(SecurityLogModule))]
// [DependsOn(typeof(ProfilePictureModule))]
// [DependsOn(typeof(WashynWidgetModule))]
// [DependsOn(typeof(BillingOtherSettingsModule))]
// [DependsOn(typeof(OrganizationUnitModule))]
// [DependsOn(typeof(LogoManagmentModule))]
// [DependsOn(typeof(SecurityLogModule))]
// [DependsOn(typeof(ProfilePictureModule))]
// [DependsOn(typeof(WashynWidgetModule))]
// [DependsOn(typeof(BillingOtherSettingsModule))]
// [DependsOn(typeof(WashynSunatCatalogModule))]
// [DependsOn(typeof(LoggingManagementWebModule))]
// [DependsOn(typeof(Acme.Identity.IdentityModule))]
public class SamplesModule : AbpModule
{

}

// [Dependency(ReplaceServices = true)]
// public class ExampleBrandingProvider : DefaultBrandingProvider
// {
//     public override string AppName => "Acme";
//     public override string LogoUrl  => "/logo";
//     public override string LogoReverseUrl  => "/logo";
// }