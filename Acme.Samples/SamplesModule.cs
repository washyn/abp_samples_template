using Acme.Samples.Pages.Components.ProfileManagement.ProfilePictureSetting;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Acme.Samples;

[DependsOn(typeof(TemplateModules))]
[DependsOn(typeof(AbpAutofacModule))]
[DependsOn(typeof(UserProfileAvatarModule))]
public class SamplesModule : AbpModule
{

}
