using Acme.Samples.Localization;
using Volo.Abp.Emailing.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Settings;

namespace Acme.Samples.Settings;

public class DatosSolSettingProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        context.Add(
            new SettingDefinition(
                DatosSolSettingNames.User,
                defaultValue:"test",
                displayName: L("Usuario SOL"),
                description: L("Usuario SOL")),
            
            new SettingDefinition(
                DatosSolSettingNames.Password,
                defaultValue:"test",
                displayName: L("Clave SOL"),
                description: L("Clave SOL"),
                isEncrypted: true)
        );
    }
    
    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<SamplesResource>(name);
    }
}