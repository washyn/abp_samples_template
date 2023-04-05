using Volo.Abp.Autofac;
using Volo.Abp.Modularity;
using Washyn.Sunat.Catalog;

namespace Acme.Samples;

[DependsOn(typeof(TemplateModules))]
[DependsOn(typeof(AbpAutofacModule))]
[DependsOn(typeof(WashynSunatCatalogModule))]
public class SamplesModule : AbpModule
{

}
