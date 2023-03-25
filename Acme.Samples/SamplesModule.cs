using Volo.Abp.Autofac;
using Volo.Abp.Modularity;
using Washyn.Sunat.Catalog;

namespace Acme.Samples;

[DependsOn(typeof(TemplateModules))]
[DependsOn(typeof(AbpAutofacModule))]
// [DependsOn(typeof(EasyAbp.Abp.TagHelperPlus.AbpTagHelperPlusModule))]
[DependsOn(typeof(EasyAbp.Abp.TagHelperPlus.AbpTagHelperPlusModule))]
[DependsOn(typeof(SelectModules))]
[DependsOn(typeof(WashynSunatCatalogModule))]
public class SamplesModule : AbpModule
{

}
