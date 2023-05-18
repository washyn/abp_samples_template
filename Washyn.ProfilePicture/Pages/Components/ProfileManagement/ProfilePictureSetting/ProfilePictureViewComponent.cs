using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.SettingManagement;

namespace Washyn.ProfilePicture.Pages.Components.ProfileManagement.ProfilePictureSetting;

public class ProfilePictureViewComponent : ViewComponent
{
    private readonly ISettingManager _settingManager;

    public ProfilePictureViewComponent(ISettingManager settingManager)
    {
        _settingManager = settingManager;
    }
    public virtual async Task<IViewComponentResult> InvokeAsync()
    {
        var model = new ShowProfilePictureViewModel();
        model.FileName = await _settingManager.GetOrNullForCurrentUserAsync(ProfilePictureSettings.ProfilePictureFile);
        return View("~/Pages/Components/ProfileManagement/ProfilePictureSetting/Default.cshtml",model);
    }
}

public class ShowProfilePictureViewModel
{
    public string FileName { get; set; }
}