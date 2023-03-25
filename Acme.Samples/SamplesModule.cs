using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Acme.Samples;

[DependsOn(typeof(TemplateModules))]
[DependsOn(typeof(AbpAutofacModule))]
// [DependsOn(typeof(EasyAbp.Abp.TagHelperPlus.AbpTagHelperPlusModule))]
[DependsOn(typeof(EasyAbp.Abp.TagHelperPlus.AbpTagHelperPlusModule))]
public class SamplesModule : AbpModule
{

}
