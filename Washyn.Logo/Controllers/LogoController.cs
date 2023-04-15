using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.BlobStoring;
using Volo.Abp.Localization;
using Volo.Abp.SettingManagement;
using Volo.Abp.SettingManagement.Web.Pages.SettingManagement;
using Volo.Abp.Settings;
using Volo.Abp.VirtualFileSystem;
using Washyn.Logo.Pages.Components.LogoSetting;

namespace Washyn.Logo.Controllers;

[Authorize]
[Route("logo")]
public class LogoController : AbpController
{
    private readonly IBlobContainer<LogoPictureContainer> _blobContainer;
    private readonly IVirtualFileProvider _virtualFileProvider;
    private readonly ISettingManager _settingManager;

    public LogoController(IBlobContainer<LogoPictureContainer> blobContainer,
        IVirtualFileProvider virtualFileProvider,
        ISettingManager settingManager)
    {
        _blobContainer = blobContainer;
        _virtualFileProvider = virtualFileProvider;
        _settingManager = settingManager;
    }
    
    [HttpPost]
    public async Task UploadLogo([FromForm] LogoViewModel model)
    {
        ValidateModel();
        await using var memoryStream = new MemoryStream();
        await model.Logo.CopyToAsync(memoryStream);
        memoryStream.Position = 0;
        var fileName = GenerateFileName(model.Logo.FileName);
        var lastLogo = await GetCurrentLogo();
        if (!lastLogo.IsNullOrEmpty())
        {
            await _blobContainer.DeleteAsync(lastLogo);
        }
        await _blobContainer.SaveAsync(fileName, memoryStream, overrideExisting: true);
        await memoryStream.DisposeAsync();
        if (CurrentTenant.IsAvailable)
        {
            await _settingManager.SetForCurrentTenantAsync(LogoSettingDefinitionProvider.LogoSettingName, fileName);
        }
        else
        {
            await _settingManager.SetGlobalAsync(LogoSettingDefinitionProvider.LogoSettingName, fileName);
        }
    }
    
    // [ResponseCache(Duration = 60*60*24)] // second minute hour
    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetApplicationLogo()
    {
        var logo = await GetCurrentLogo();
        if (string.IsNullOrEmpty(logo))
        {
            return NotFound();
        }
        var res = await _blobContainer.GetOrNullAsync(logo);
        if (res is null)
        {
            res = _virtualFileProvider.GetFileInfo("/Pages/Components/Screenshot_601.png").CreateReadStream();
        }
        return File(res, "image/*");
    }
    
    private async Task<string> GetCurrentLogo()
    {
        var logo = await _settingManager.GetOrNullGlobalAsync(LogoSettingDefinitionProvider.LogoSettingName);
        if (CurrentTenant.IsAvailable)
        {
            logo = await _settingManager.GetOrNullForCurrentTenantAsync(LogoSettingDefinitionProvider.LogoSettingName, false);
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
    public const string LogoSettingName = "Setting.LogoSettingName";
    public const int MaxLogoLogoFileSize = 1024 * 1024 * 1; // 1 mb
    public override void Define(ISettingDefinitionContext context)
    {
        context.Add(new SettingDefinition(LogoSettingName, LogoSettingName));
    }
}

public class LogoSettingPageContributor : ISettingPageContributor
{
    public async Task ConfigureAsync(SettingPageCreationContext context)
    {
        if (await CheckPermissionsAsync(context))
        {
            context.Groups.Add(new SettingPageGroup("LogoSettingId", 
                "Configuración de logo", 
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

[LocalizationResourceName("LogoResource")]
public class LogoResource
{
}

[BlobContainerName("logo-pictures")]
public class LogoPictureContainer
{
}



public class LogoViewModel
{
    [Required]
    [MaxFileSize(maxFileSize: LogoSettingDefinitionProvider.MaxLogoLogoFileSize)]
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