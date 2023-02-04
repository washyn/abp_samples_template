using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Content;
using Volo.Abp.MultiTenancy;
using Volo.Abp.SettingManagement;
using Volo.Abp.Settings;
using Volo.Abp.Ui.Branding;
using System.Linq;
using LogoManagment.Pages.Components.LogoSetting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.BlobStoring;
using Volo.Abp.Http;
using Volo.Abp.Localization;
using Volo.Abp.SettingManagement.Web.Pages.SettingManagement;
using Volo.Abp.VirtualFileSystem;

namespace LogoManagment.Controllers;
// TODO: improve with suport multitenat, and front ui resizer image cropper.
[Route("logo")]
public class LogoController : AbpController
{
    private readonly ILogger<LogoController> _logger;
    private readonly IBlobContainer<LogoPictureContainer> _blobContainer;
    private readonly IVirtualFileProvider _virtualFileProvider;
    private readonly ISettingProvider _settingProvider;
    private readonly ISettingManager _settingManager;

    public LogoController(ILogger<LogoController> logger,
        IBlobContainer<LogoPictureContainer> blobContainer,
        IVirtualFileProvider virtualFileProvider,
        ISettingProvider settingProvider,
        ISettingManager settingManager)
    {
        _logger = logger;
        _blobContainer = blobContainer;
        _virtualFileProvider = virtualFileProvider;
        _settingProvider = settingProvider;
        _settingManager = settingManager;
    }

    [RequestSizeLimit(LogoSettingDefinitionProvider.MaxLogoLogoFileSize)]
    [MaxFileSize(LogoSettingDefinitionProvider.MaxLogoLogoFileSize)]
    [Route("upload")]
    [HttpPost]
    public async Task UploadLogo([FromForm] LogoViewModel model)
    {
        await using var memoryStream = new MemoryStream();
        if (model.Logo != null && model.Logo.Length > 0)
        {
            await model.Logo.CopyToAsync(memoryStream);
            memoryStream.Position = 0;
            var fileName = GenerateFileName(model.Logo.FileName);
            var last = await GetLogoCurrent();
            if (!string.IsNullOrEmpty(last))
            {
                await _blobContainer.DeleteAsync(last);
            }
            await _blobContainer.SaveAsync(fileName, memoryStream);
            await _settingManager.SetForTenantOrGlobalAsync(CurrentTenant.Id, LogoSettingDefinitionProvider.LogoSettingName, fileName);
        }
        await memoryStream.DisposeAsync();
    }
    
    [ResponseCache(Duration = 60)]
    [HttpGet]
    public async Task<IRemoteStreamContent> GetLogo()
    {
        Response.Headers.Add("Accept-Ranges", "bytes");
        Response.ContentType = MimeTypes.Application.OctetStream;

        var logo = await GetLogoCurrent();
        
        if (string.IsNullOrEmpty(logo))
        {
            var stream = _virtualFileProvider.GetFileInfo("/images/laptop_mac-24px.png").CreateReadStream();
            var remoteStream = new RemoteStreamContent(stream);
            await stream.FlushAsync();
            return remoteStream;
        }
        var res = await _blobContainer.GetAsync(logo);
        var remoteStream1 = new RemoteStreamContent(res);
        await res.FlushAsync();
        return remoteStream1;
    }

    private async Task<string> GetLogoCurrent()
    {
        var logo = await _settingProvider.GetOrNullAsync(LogoSettingDefinitionProvider.LogoSettingName);
        if (CurrentTenant.IsAvailable)
        {
            logo = await _settingManager.GetOrNullForTenantAsync(LogoSettingDefinitionProvider.LogoSettingName, CurrentTenant.GetId(), false);
        }
        return logo;
    }
    
    private string GenerateFileName(string fileName)
    {
        var ext = Path.GetExtension(fileName);
        var newFileName = GuidGenerator.Create() + ext;
        return newFileName;
    }
}

public class LogoSettingDefinitionProvider : SettingDefinitionProvider
{
    public const string LogoSettingName = "LogoSettingName";
    public const int MaxLogoLogoFileSize = 1024 * 1024 * 2;
    public override void Define(ISettingDefinitionContext context)
    {
        context.Add(new SettingDefinition(LogoSettingName, 
            string.Empty)
        );
    }
}

public class LogoSettingPageContributor : ISettingPageContributor
{
    public async Task ConfigureAsync(SettingPageCreationContext context)
    {
        if (await CheckPermissionsAsync(context))
        {
            context.Groups.AddFirst(new SettingPageGroup("LogoSettingId", 
                "Confuguracion de logo", 
                typeof(LogoSettingViewComponent)));
        }
    }

    public async Task<bool> CheckPermissionsAsync(SettingPageCreationContext context)
    {
        var authorizationService = context.ServiceProvider.GetRequiredService<IAuthorizationService>();
        return await authorizationService.IsGrantedAsync(LogoPermissions.Logo.Default);
    }
}

public static class LogoPermissions
{
    public const string GroupName = "LogoGroup";
    public static class Logo
    {
        public const string Default = GroupName + ".Logo";
    }
}

public class LogoPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var eventHubGroup = context.AddGroup(LogoPermissions.GroupName, L("Configuración de logo"));
        var logoPermissions = eventHubGroup.AddPermission(LogoPermissions.Logo.Default, L("Permiso para cambiar de logo"));
    }
    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<LogoResource>(name);
    }
}

[LocalizationResourceName("Logo")]
public class LogoResource
{
}

[BlobContainerName("logo-pictures")]
public class LogoPictureContainer
{
}

public class ExampleBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "";
    public override string LogoUrl  => "/logo";
    public override string LogoReverseUrl  => "/logo";
}

public class LogoViewModel
{
    [Required]
    [MaxFileSize(maxFileSize: LogoSettingDefinitionProvider.MaxLogoLogoFileSize)]
    [AllowedExtensions(new string[] {".jpg", ".png", ".jpeg"})]
    public IFormFile Logo { get; set; }
}


#region Attributes validation

public class MaxFileSizeAttribute : ValidationAttribute
{
    private readonly int _maxFileSize;

    public MaxFileSizeAttribute(int maxFileSize)
    {
        _maxFileSize = maxFileSize;
    }

    protected override ValidationResult IsValid(
        object value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return ValidationResult.Success;
        }

        var file = value as IFormFile;

        if (file.Length > 0)
        {
            if (file.Length > _maxFileSize)
            {
                return new ValidationResult("Maximum file size: " + _maxFileSize);
            }
        }

        return ValidationResult.Success;
    }
}

public class AllowedExtensionsAttribute : ValidationAttribute
{
    private readonly string[] _allowedExtensions;

    public AllowedExtensionsAttribute(string[] allowedExtensions)
    {
        _allowedExtensions = allowedExtensions;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var file = value as IFormFile;
            
        if (file is { Length: > 0 })
        {
            var extension = Path.GetExtension(file.FileName);

            if (!_allowedExtensions.Contains(extension.ToLower()))
            {
                return new ValidationResult("This file extension is not allowed. Allowed extensions: " + string.Join(",", _allowedExtensions));
            }
        }

        return ValidationResult.Success;
    }
}

public class AllowedContentTypeAttribute : ValidationAttribute
{
    private readonly string[] _allowedContentType;

    public AllowedContentTypeAttribute(string[] allowedContentType)
    {
        _allowedContentType = allowedContentType;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var file = value as IFormFile;
            
        if (file is { Length: > 0 })
        {
            var contentType = file.ContentType;
            
            if (!_allowedContentType.Contains(contentType))
            {
                return new ValidationResult("This file type is not allowed. Allowed types: " + string.Join(",", _allowedContentType));
            }
        }

        return ValidationResult.Success;
    }
}

#endregion