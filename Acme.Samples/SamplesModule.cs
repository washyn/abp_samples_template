using Volo.Abp.Autofac;
using Volo.Abp.Modularity;
using Washyn.ProfilePicture.Pages.Components.ProfileManagement.ProfilePictureSetting;

namespace Acme.Samples;

[DependsOn(typeof(TemplateModules))]
[DependsOn(typeof(AbpAutofacModule))]
[DependsOn(typeof(UserProfileAvatarModule))]
public class SamplesModule : AbpModule
{

}
