using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Acme.Samples;

[DependsOn(typeof(TemplateModules))]
[DependsOn(typeof(AbpAutofacModule))]
[DependsOn(typeof(SecurityLogModule))]
public class SamplesModule : AbpModule
{

}
