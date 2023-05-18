using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.SettingManagement;

namespace Washyn.ProfilePicture.Pages.Components.UserAvatar;

public class UserAvatarViewComponent : AbpViewComponent
{
    private readonly ISettingManager _manager;

    public UserAvatarViewComponent(ISettingManager manager)
    {
        _manager = manager;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var fileId = await _manager.GetOrNullForCurrentUserAsync(ProfilePictureSettings.ProfilePictureFile);
        return View("~/Pages/Components/UserAvatar/Default.cshtml", fileId);
    }
}