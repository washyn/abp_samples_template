// using Acme.Samples.OrganizationUnit;
using Volo.Abp.Autofac;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace Acme.Samples;

[DependsOn(typeof(TemplateModules))]
[DependsOn(typeof(AbpAutofacModule))]
[DependsOn(typeof(OrganizationUnitModule))]
public class SamplesModule : AbpModule
{

}
