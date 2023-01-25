using Acme.Samples.Pages.Components.DatoSolSetting;
using Volo.Abp.SettingManagement.Web.Pages.SettingManagement;

namespace Acme.Samples.Settings;

public class DatosSettingsPageContributor : ISettingPageContributor
{
    public async Task ConfigureAsync(SettingPageCreationContext context)
    {
        if (await CheckPermissionsAsync(context))
        {
            context.Groups.Add(
                new SettingPageGroup(
                    "Settings.DatosSol",
                    "Datos SOL",
                    typeof(DatoSolSettingViewComponent)
                )
            );
        }
    }

    public Task<bool> CheckPermissionsAsync(SettingPageCreationContext context)
    {
        return Task.FromResult(true);
    }
}