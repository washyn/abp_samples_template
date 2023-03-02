using Volo.Abp.Autofac;
using Volo.Abp.Modularity;
using Washyn.SbTheme;

namespace Acme.Samples;

[DependsOn(typeof(TemplateModules))]
[DependsOn(typeof(AbpAutofacModule))]
[DependsOn(typeof(WashynSbThemeModule))]
public class SamplesModule : AbpModule
{

}
