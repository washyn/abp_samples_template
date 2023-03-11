using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.Demo;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;
using Washyn.SbTheme;

namespace Acme.Samples;

[DependsOn(typeof(AbpAspNetCoreMvcUiBootstrapDemoModule))]
[DependsOn(typeof(TemplateModules))]
[DependsOn(typeof(AbpAutofacModule))]
[DependsOn(typeof(WashynSbThemeModule))]
public class SamplesModule : AbpModule
{

}
