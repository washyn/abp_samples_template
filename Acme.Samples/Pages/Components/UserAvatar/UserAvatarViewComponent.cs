using Acme.Samples.Pages.Components.ProfileManagement.ProfilePictureSetting;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Account.Web.Modules.Account.Components.Toolbar.UserLoginLink;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Toolbars;
using Volo.Abp.Features;
using Volo.Abp.SettingManagement;
using Volo.Abp.Users;

namespace Acme.Samples.Pages.Components.UserAvatar;

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

public class UserAvatarToolbarContributor : IToolbarContributor
{
    public virtual async Task ConfigureToolbarAsync(IToolbarConfigurationContext context)
    {
        if (context.Toolbar.Name != StandardToolbars.Main)
        {
            return;
        }
        if (context.ServiceProvider.GetRequiredService<ICurrentUser>().IsAuthenticated)
        {
            if (await FeatureIsAvailable(context))
            {
                context.Toolbar.Items.Add(new ToolbarItem(typeof(UserAvatarViewComponent)));
            }
        }
    }
    
    private async Task<bool> FeatureIsAvailable(IToolbarConfigurationContext context)
    {
        var feature = context.ServiceProvider.GetRequiredService<IFeatureChecker>();
        return await feature.IsEnabledAsync(ProfilePictureFeature.Feature);
    }
}
