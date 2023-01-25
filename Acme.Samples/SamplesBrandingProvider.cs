using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Acme.Samples;

[Dependency(ReplaceServices = true)]
public class SamplesBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Samples";
}
