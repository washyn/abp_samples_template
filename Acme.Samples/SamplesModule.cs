using Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;


namespace Acme.Samples;

[DependsOn(typeof(AbpAspNetCoreMvcUiBasicThemeModule))]
[DependsOn(typeof(AbpAutofacModule))]
[DependsOn(typeof(TemplateModules))]

// [DependsOn(typeof(EasyAbp.LoggingManagement.Web.LoggingManagementWebModule))]

// [DependsOn(typeof(Washyn.Logo.LogoManagmentModule))]
// [DependsOn(typeof(Washyn.SecurityLogs.SecurityLogModule))]
// [DependsOn(typeof(Washyn.ProfilePicture.ProfilePictureModule))]
// [DependsOn(typeof(Washyn.Billing.OtherSettings.BillingOtherSettingsModule))]
// [DependsOn(typeof(Washyn.OrganizationUnit.OrganizationUnitModule))]
// [DependsOn(typeof(Washyn.ProfilePicture.ProfilePictureModule))]
// [DependsOn(typeof(Washyn.Widgets.WashynWidgetModule))]
// [DependsOn(typeof(Washyn.Sunat.Catalog.WashynSunatCatalogModule))]

// [DependsOn(typeof(Washyn.ComprobantePdf.ComprobantePdfModule))]
// [DependsOn(typeof(Washyn.SbTheme.WashynSbThemeModule))]
// [DependsOn(typeof(Washyn.Dastone.AbpAspNetCoreMvcUiDastoneThemeModule))]
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