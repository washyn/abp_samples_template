using LogoManagment;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Acme.Samples;

[DependsOn(typeof(TemplateModules))]
[DependsOn(typeof(LogoManagmentModule))]
[DependsOn(typeof(AbpAutofacModule))]
[DependsOn(typeof(LogoManagmentModule))]
public class SamplesModule : AbpModule
{

}
