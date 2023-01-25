using Acme.Samples.Services.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.SettingManagement;
using Volo.Abp.Settings;

namespace Acme.Samples.Services;

public class DatosSolAppService : ApplicationService
{
    private readonly ISettingManager _settingManager;
    private readonly ISettingProvider _settingProvider;

    public DatosSolAppService(ISettingManager settingManager, ISettingProvider settingProvider)
    {
        _settingManager = settingManager;
        _settingProvider = settingProvider;
    }
    
    public async Task<DatosSolDto> GetAsync()
    {
        return new DatosSolDto()
        {
            Password = await _settingProvider.GetOrNullAsync(DatosSolSettingNames.Password),
            User = await _settingProvider.GetOrNullAsync(DatosSolSettingNames.User),
        };
    }

    public async Task UpdateAsync(UpdateDatosSolDto input)
    {
        await _settingManager.SetForTenantOrGlobalAsync(CurrentTenant.Id, DatosSolSettingNames.User, input.User);
        await _settingManager.SetForTenantOrGlobalAsync(CurrentTenant.Id, DatosSolSettingNames.Password, input.Password);
    }
}