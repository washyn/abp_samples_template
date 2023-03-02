using Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;
using Washyn.SbTheme;
using Washyn.ProfilePicture.Pages.Components.ProfileManagement.ProfilePictureSetting;
using LogoManagment;
using Volo.Abp.Autofac;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.Ui.Branding;


namespace Acme.Samples;

[DependsOn(typeof(TemplateModules))]
[DependsOn(typeof(LogoManagmentModule))]
[DependsOn(typeof(AbpAutofacModule))]
[DependsOn(typeof(WashynSbThemeModule))]
[DependsOn(typeof(UserProfileAvatarModule))]
public class SamplesModule : AbpModule
{

}

[Dependency(ReplaceServices = true)]
public class ExampleBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "";
    public override string LogoUrl  => "/logo";
    public override string LogoReverseUrl  => "/logo";
}