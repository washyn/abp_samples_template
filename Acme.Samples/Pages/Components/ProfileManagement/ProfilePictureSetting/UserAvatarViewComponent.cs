using System.ComponentModel.DataAnnotations;
using Acme.Samples.Pages.Components.UserAvatar;
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
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.SettingManagement;
using Volo.Abp.Settings;
using Volo.Abp.VirtualFileSystem;

namespace Acme.Samples.Pages.Components.ProfileManagement.ProfilePictureSetting;

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
    
    // [ResponseCache(Location = ResponseCacheLocation.Client, Duration = 120, VaryByQueryKeys = new []{"id"})]
    [ResponseCache(Duration = 120)]
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

#endregion
public class UpdateProfilePictureViewModel
{
    [Required]
    public IFormFile File { get; set; }
}
public class UserAvatarViewComponent : ViewComponent
{
    private readonly ISettingManager _settingManager;

    public UserAvatarViewComponent(ISettingManager settingManager)
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

public class UserAvatarPageContributor : IProfileManagementPageContributor
{
    public Task ConfigureAsync(ProfileManagementPageCreationContext context)
    {
        var l = context.ServiceProvider.GetRequiredService<IStringLocalizer<ProfilePictureResource>>();

        context.Groups.Add(
            new ProfileManagementPageGroup(
                "Account.ProfilePicture",
                l["Imagen de perfil"],
                typeof(UserAvatarViewComponent)
            )
        );
        return Task.CompletedTask;
    }
}

public class ShowProfilePictureViewModel
{
    public string FileName { get; set; }
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
            options.Contributors.AddFirst(new UserAvatarPageContributor());
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