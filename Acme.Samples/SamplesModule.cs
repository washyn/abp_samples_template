using Volo.Abp.Autofac;
using Volo.Abp.Modularity;
using Washyn.SecurityLogs;
using Washyn.SbTheme;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;
using Washyn.Logo;
using Washyn.ProfilePicture;

namespace Acme.Samples;

[DependsOn(typeof(TemplateModules))]
[DependsOn(typeof(LogoManagmentModule))]
[DependsOn(typeof(AbpAutofacModule))]
[DependsOn(typeof(SecurityLogModule))]
[DependsOn(typeof(WashynSbThemeModule))]
[DependsOn(typeof(ProfilePictureModule))]
public class SamplesModule : AbpModule
{

}

[Dependency(ReplaceServices = true)]
public class ExampleBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Acme";
    public override string LogoUrl  => "/logo";
    public override string LogoReverseUrl  => "/logo";
}