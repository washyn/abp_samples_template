using System.ComponentModel.DataAnnotations;
using System.Drawing;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Content;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Http;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;
using Volo.Abp.SettingManagement;
using Volo.Abp.Settings;
using Volo.Abp.Threading;
using Volo.Abp.Ui.Branding;

namespace Acme.Samples.Controllers;

[Route("logo")]
public class LogoController : AbpController
{
    private readonly ILogger<LogoController> _logger;
    private readonly LogoAppService _logoAppService;

    public LogoController(ILogger<LogoController> logger,
        LogoAppService logoAppService)
    {
        _logger = logger;
        _logoAppService = logoAppService;
    }

    [RequestSizeLimit(LogoSettingDefinitionProvider.MaxLogoLogoFileSize)]
    [Route("upload")]
    [HttpPost]
    public async Task UploadLogo([FromForm] LogoViewModel model)
    {
        var hasFile = !string.IsNullOrEmpty(model.Logo?.FileName);
        _logger.LogDebug("hasFile");
        _logger.LogDebug(hasFile.ToString());
        var obj = new UpdateLogoSettingDto();
        await using var memoryStream = new MemoryStream();
        if (model.Logo != null && model.Logo.Length > 0)
        {
            await model.Logo.CopyToAsync(memoryStream);
            memoryStream.Position = 0;
            
            obj.LogoContent = new RemoteStreamContent(memoryStream, fileName: model.Logo.FileName, contentType: model.Logo.ContentType);
        }
        await _logoAppService.UpdateLogoAsync(obj);
        await memoryStream.DisposeAsync();
    }
}


public class LogoSettingDefinitionProvider : SettingDefinitionProvider
{
    public const string LogoSettingName = "LogoSettingName";
    public const int MaxLogoLogoFileSize = 1024 * 1024 * 5;
    public override void Define(ISettingDefinitionContext context)
    {
        context.Add(new SettingDefinition(LogoSettingName, 
            string.Empty)
        );
    }
}


[RemoteService(IsEnabled = false)]
public class LogoAppService : ApplicationService
{
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly ISettingProvider _settingProvider;
    private readonly ISettingManager _settingManager;
    private const string LogoFoler = "logos";
    public LogoAppService(IWebHostEnvironment webHostEnvironment, 
        ISettingProvider settingProvider,
        ISettingManager settingManager)
    {
        _webHostEnvironment = webHostEnvironment;
        _settingProvider = settingProvider;
        _settingManager = settingManager;
    }

    public async Task<LogoSettingDto> GetAsync()
    {
        var settingsDto = new LogoSettingDto
        {
            LogoUrl = await SettingProvider.GetOrNullAsync(LogoSettingDefinitionProvider.LogoSettingName),
        };

        if (CurrentTenant.IsAvailable)
        {
            settingsDto.LogoUrl = await _settingManager.GetOrNullForTenantAsync(LogoSettingDefinitionProvider.LogoSettingName, CurrentTenant.GetId(), false);
        }

        return settingsDto;
    }

    public async Task UpdateLogoAsync(UpdateLogoSettingDto updateLogoSettingDto)
    {
        var fullPath = Path.Combine(_webHostEnvironment.WebRootPath, LogoFoler);
        Directory.CreateDirectory(fullPath);
        var ext = Path.GetExtension(updateLogoSettingDto.LogoContent.FileName);
        // var fileName = Path.Combine(GuidGenerator.Create() + ext);
        var fileName = updateLogoSettingDto.LogoContent.FileName;
        var fullLogoPath = "/" + LogoFoler +"/"+ fileName;
        using (var sw = File.Create(Path.Combine(fullPath, fileName)))
        {
            await updateLogoSettingDto.LogoContent.GetStream().CopyToAsync(sw);
            await _settingManager.SetForTenantOrGlobalAsync(CurrentTenant.Id,
                LogoSettingDefinitionProvider.LogoSettingName, fullLogoPath);
        }
    }
}


public class LogoSettingDto
{
    public string LogoUrl { get; set; }
}


[Dependency(ReplaceServices = true)]
public class ExampleBrandingProvider : DefaultBrandingProvider
{
    private readonly LogoAppService _logoAppService;
    public override string AppName => "";
    public override string LogoUrl  => GetLogoUrl();

    public ExampleBrandingProvider(LogoAppService logoAppService)
    {
        _logoAppService = logoAppService;
    }

    public string GetLogoUrl()
    {
        return _logoAppService.GetAsync().GetAwaiter().GetResult().LogoUrl;
    }
}

public class UpdateLogoSettingDto
{
    [Required]
    public RemoteStreamContent LogoContent { get; set; }
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