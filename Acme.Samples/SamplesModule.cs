using Volo.Abp.Autofac;
using Volo.Abp.Modularity;
using Washyn.Widgets;

namespace Acme.Samples;

[DependsOn(typeof(TemplateModules))]
[DependsOn(typeof(AbpAutofacModule))]
[DependsOn(typeof(WashynWidgetModule))]
public class SamplesModule : AbpModule
{

}
