using LogoManagment;
using Volo.Abp.Autofac;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.Ui.Branding;

namespace Acme.Samples;

[DependsOn(typeof(TemplateModules))]
[DependsOn(typeof(LogoManagmentModule))]
[DependsOn(typeof(AbpAutofacModule))]
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