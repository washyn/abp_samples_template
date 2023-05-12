using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Volo.Abp.Account.Web;
using Volo.Abp.Account.Web.ProfileManagement;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Packages.CropperJs;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Toolbars;
using Volo.Abp.BlobStoring;
using Volo.Abp.Features;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.SettingManagement;
using Volo.Abp.Settings;
using Volo.Abp.Users;
using Volo.Abp.Validation.StringValues;
using Volo.Abp.VirtualFileSystem;
using Washyn.ProfilePicture.Pages.Components.ProfileManagement.ProfilePictureSetting;
using Washyn.ProfilePicture.Pages.Components.UserAvatar;

namespace Washyn.ProfilePicture;

[Authorize]
[Route("account/profile-picture-file")]
[RequiresFeature(ProfilePictureFeature.Feature)]
public class ProfilePictureController : AbpController
{
    private readonly IBlobContainer<ProfilePictureContainer> _container;
    private readonly IVirtualFileProvider _fileProvider;
    private readonly ISettingManager _settingManager;

    public ProfilePictureController(IBlobContainer<ProfilePictureContainer> container,
        IVirtualFileProvider fileProvider, ISettingManager settingManager)
    {
        _container = container;
        _fileProvider = fileProvider;
        _settingManager = settingManager;
    }

    [HttpPost]
    public async Task UploadPicture([FromForm] UpdateProfilePictureViewModel model)
    {
        ValidateModel();
        var id = GuidGenerator.Create().ToString();
        await _container.SaveAsync(id, model.File.OpenReadStream());
        var prevImage = await _settingManager.GetOrNullForCurrentUserAsync(ProfilePictureSettings.ProfilePictureFile);
        if (!string.IsNullOrEmpty(prevImage))
        {
            await _container.DeleteAsync(prevImage);
        }

        await _settingManager.SetForCurrentUserAsync(ProfilePictureSettings.ProfilePictureFile, id);
    }

    [Route("{id}")]
    [HttpGet]
    public async Task<IActionResult> GetProfilePicture(Guid id)
    {
        var imageMime = "image/*";
        var file = await _container.GetOrNullAsync(id.ToString());
        if (file is null)
        {
            return BadRequest();
        }

        return File(await file.GetAllBytesAsync(), imageMime);
    }

    [Route("default")]
    [HttpPost]
    public async Task SetDefaultImage()
    {
        await _settingManager.SetForCurrentUserAsync(ProfilePictureSettings.ProfilePictureFile, string.Empty);
    }

    [ResponseCache(Duration = 60 * 60 * 24 * 30 * 12)]
    [Route("default")]
    [HttpGet]
    public async Task<IActionResult> GetDefaultImage()
    {
        var imageMime = "image/*";
        var stream = _fileProvider.GetFileInfo(ProfilePictureSettings.PathFileName).CreateReadStream();
        return File(await stream.GetAllBytesAsync(), imageMime);
    }
}

[DependsOn(typeof(AbpBlobStoringModule))]
[DependsOn(typeof(AbpLocalizationModule))]
[DependsOn(typeof(AbpAccountWebModule))]
[DependsOn(typeof(AbpSettingsModule))]
[DependsOn(typeof(AbpVirtualFileSystemModule))]
public class ProfilePictureModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var hosting = context.Services.GetHostingEnvironment();
        Configure<AbpVirtualFileSystemOptions>(options => { options.FileSets.AddEmbedded<ProfilePictureModule>("Washyn.ProfilePicture"); });

        Configure<ProfileManagementPageOptions>(options =>
        {
            options.Contributors.AddFirst(new ProfilePicturePageContributor());
        });

        Configure<AbpToolbarOptions>(options => { options.Contributors.Add(new UserAvatarToolbarContributor()); });

        Configure<AbpBundlingOptions>(options =>
        {
            options.StyleBundles.Configure(StandardBundles.Styles.Global,
                bundle => { bundle.AddContributors(typeof(CropperJsStyleContributor)); });
            options.ScriptBundles.Configure(StandardBundles.Scripts.Global,
                bundle => { bundle.AddContributors(typeof(CropperJsScriptContributor)); });
        });

        Configure<AbpBundlingOptions>(options =>
        {
            options.ScriptBundles.Configure(typeof(Volo.Abp.Account.Web.Pages.Account.ManageModel).FullName,
                configuration =>
                {
                    configuration.AddFiles(
                        "/Pages/Components/ProfileManagement/ProfilePictureSetting/Default.cshtml.js");
                });
        });
    }
}

#region SettingDefinitions

public class ProfilePictureSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        context.Add(new SettingDefinition(ProfilePictureSettings.ProfilePictureFile, string.Empty));
    }
}

public static class ProfilePictureSettings
{
    private const string Prefix = "ProfilePicture";
    public const string ProfilePictureFile = Prefix + ".ProfilePictureFile";
    public const string PathFileName = "/Images/9385f872-7563-3a64-2bd2-3a0801e89e21.jpeg";
}

public static class ProfilePictureFeature
{
    private const string GroupName = "App";
    public const string Feature = GroupName + ".ProfilePicture";
}

public class ProfilePictureFeatureDefinitionProvider : FeatureDefinitionProvider
{
    public override void Define(IFeatureDefinitionContext context)
    {
        var myGroup = context.AddGroup("ProfilePicture", L("Imagen de perfil"));

        myGroup.AddFeature(ProfilePictureFeature.Feature, defaultValue: "false",
            displayName: L("Caracteristica de seleccionar imagen de perfil"),
            description: L("Permite seleccionar una imagen de perfil"), valueType: new ToggleStringValueType());
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ProfilePictureResource>(name);
    }
}

#endregion

#region Others

public class UpdateProfilePictureViewModel
{
    [Required] public IFormFile File { get; set; }
}

public class ProfilePicturePageContributor : IProfileManagementPageContributor
{
    public async Task ConfigureAsync(ProfileManagementPageCreationContext context)
    {
        var l = context.ServiceProvider.GetRequiredService<IStringLocalizer<ProfilePictureResource>>();
        if (await FeatureIsAvailable(context))
        {
            context.Groups.Add(new ProfileManagementPageGroup("Account.ProfilePicture", l["Imagen de perfil"],
                typeof(ProfilePictureViewComponent)));
        }
    }

    private async Task<bool> FeatureIsAvailable(ProfileManagementPageCreationContext context)
    {
        var feature = context.ServiceProvider.GetRequiredService<IFeatureChecker>();
        return await feature.IsEnabledAsync(ProfilePictureFeature.Feature);
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

[LocalizationResourceName("UserAvatar")]
public class ProfilePictureResource
{
}

[BlobContainerName("profile-pictures")]
public class ProfilePictureContainer
{
}

#endregion