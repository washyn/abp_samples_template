using System.ComponentModel.DataAnnotations;
using Acme.Samples.Pages.Components.UserAvatar;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Volo.Abp.Account.Web;
using Volo.Abp.Account.Web.ProfileManagement;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Toolbars;
using Volo.Abp.BlobStoring;
using Volo.Abp.BlobStoring.FileSystem;
using Volo.Abp.Content;
using Volo.Abp.Features;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.SettingManagement;
using Volo.Abp.Settings;
using Volo.Abp.Validation.StringValues;
using Volo.Abp.VirtualFileSystem;

namespace Acme.Samples.Pages.Components.ProfileManagement.ProfilePictureSetting;

[Authorize]
[Route("account/profile-picture-file")]
public class ProfilePictureController : AbpController
{
    private readonly IBlobContainer<ProfilePictureContainer> _container;
    private readonly IVirtualFileProvider _fileProvider;
    private readonly ISettingManager _settingManager;

    public ProfilePictureController(IBlobContainer<ProfilePictureContainer> container,
        IVirtualFileProvider fileProvider,
        ISettingManager settingManager)
    {
        _container = container;
        _fileProvider = fileProvider;
        _settingManager = settingManager;
    }
    
    [RequiresFeature(ProfilePictureFeature.Feature)]
    [HttpPost]
    public async Task UploadPicture([FromForm]UpdateProfilePictureViewModel model)
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
    
    // [ResponseCache(Duration = 120)]
    [RequiresFeature(ProfilePictureFeature.Feature)]
    [Route("{id:guid:required}")]
    [HttpGet]
    public async Task<IRemoteStreamContent> GetProfilePicture(Guid id)
    {
        HttpContext.Response.Headers.Add("content-type","image/jpeg");
        var file = await _container.GetOrNullAsync(id.ToString());
        if (file is null)
        {
            var stream = _fileProvider.GetFileInfo("/images/9385f872-7563-3a64-2bd2-3a0801e89e21.jpeg").CreateReadStream();
            var remoteStream = new RemoteStreamContent(stream);
            await stream.FlushAsync();
            return remoteStream;
        }
        return new RemoteStreamContent(file);
    }
}

#region SettingDefinitions

public class ProfilePictureSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        context.Add(new SettingDefinition(ProfilePictureSettings.ProfilePictureFile, "9385f872-7563-3a64-2bd2-3a0801e89e21"));
    }
}
    
public static class ProfilePictureSettings
{
    private const string Prefix = "ProfilePicture";
    public const string ProfilePictureFile = Prefix + ".ProfilePictureFile";
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

        myGroup.AddFeature(
            ProfilePictureFeature.Feature,
            defaultValue: "false",
            displayName: L("Caracteristica de seleccionar imagen de perfil"),
            description: L("Permite seleccionar una imagen de perfil"),
            valueType: new ToggleStringValueType()
        );
    }
    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ProfilePictureResource>(name);
    }
}

#endregion
public class UpdateProfilePictureViewModel
{
    [Required]
    public IFormFile File { get; set; }
}
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
        if (string.IsNullOrEmpty(model.FileName))
        {
            model.FileName = "9385f872-7563-3a64-2bd2-3a0801e89e21";
        }
        return View("~/Pages/Components/ProfileManagement/ProfilePictureSetting/Default.cshtml",model);
    }
}

public class ProfilePicturePageContributor : IProfileManagementPageContributor
{
    public async Task ConfigureAsync(ProfileManagementPageCreationContext context)
    {
        var l = context.ServiceProvider.GetRequiredService<IStringLocalizer<ProfilePictureResource>>();
        if (await FeatureIsAvailable(context))
        {
            context.Groups.Add(
                new ProfileManagementPageGroup(
                    "Account.ProfilePicture",
                    l["Imagen de perfil"],
                    typeof(ProfilePictureViewComponent)
                )
            );
        }
    }

    private async Task<bool> FeatureIsAvailable(ProfileManagementPageCreationContext context)
    {
        var feature = context.ServiceProvider.GetRequiredService<IFeatureChecker>();
        return await feature.IsEnabledAsync(ProfilePictureFeature.Feature);
    }
}

public class ShowProfilePictureViewModel
{
    public string FileName { get; set; }
    
    [EnumDataType(typeof(TypeProfilePicture))]
    public TypeProfilePicture PictureType { get; set; }
}

public enum TypeProfilePicture
{
    Default,
    Upload,
}

[LocalizationResourceName("UserAvatar")]
public class ProfilePictureResource
{
}

[BlobContainerName("profile-pictures")]
public class ProfilePictureContainer
{
        
}

[DependsOn(typeof(Volo.Abp.BlobStoring.FileSystem.AbpBlobStoringFileSystemModule))]
[DependsOn(typeof(Volo.Abp.Localization.AbpLocalizationModule))]
[DependsOn(typeof(Volo.Abp.Account.Web.AbpAccountWebModule))]
[DependsOn(typeof(Volo.Abp.Settings.AbpSettingsModule))]

[DependsOn(typeof(Volo.Abp.BlobStoring.Database.BlobStoringDatabaseDomainSharedModule))]
[DependsOn(typeof(Volo.Abp.BlobStoring.Database.BlobStoringDatabaseDomainModule))]
[DependsOn(typeof(Volo.Abp.BlobStoring.Database.EntityFrameworkCore.BlobStoringDatabaseEntityFrameworkCoreModule))]

[DependsOn(typeof(AbpVirtualFileSystemModule))]
public class UserProfileAvatarModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var hostingEnvironment = context.Services.GetHostingEnvironment();
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<UserProfileAvatarModule>();
            
            if (hostingEnvironment.IsDevelopment())
            {
                options.FileSets.ReplaceEmbeddedByPhysical<UserProfileAvatarModule>(hostingEnvironment.ContentRootPath);
            }
        });

        Configure<ProfileManagementPageOptions>(options =>
        {
            options.Contributors.AddFirst(new ProfilePicturePageContributor());
        });

        Configure<AbpBundlingOptions>(options =>
        {
            options.ScriptBundles
                .Configure(typeof(Volo.Abp.Account.Web.Pages.Account.ManageModel).FullName,
                    configuration =>
                    {
                        configuration.AddFiles("/Pages/Components/ProfileManagement/ProfilePictureSetting/Default.js");
                    });
        });

        var hosting = context.Services.GetHostingEnvironment();
        Configure<AbpBlobStoringOptions>(options =>
        {
            options.Containers.ConfigureDefault(container =>
            {
                // container.UseDatabase();
                container.UseFileSystem(fileSystem =>
                {
                    fileSystem.BasePath = hosting.WebRootPath;
                });
            });
        });
        
        Configure<AbpToolbarOptions>(options =>
        {
            options.Contributors.Add(new UserAvatarToolbarContributor());
        });
    }
}