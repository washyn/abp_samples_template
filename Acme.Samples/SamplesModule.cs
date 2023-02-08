using Acme.Samples.Pages.Components.ImagesWidget;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Acme.Samples;

[DependsOn(typeof(TemplateModules))]
[DependsOn(typeof(AbpAutofacModule))]
[DependsOn(typeof(ExampleWidgetModule))]
public class SamplesModule : AbpModule
{

}
