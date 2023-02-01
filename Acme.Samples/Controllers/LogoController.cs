using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Content;
using Volo.Abp.Http;

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

    [RequestSizeLimit(1024 * 1024)]
    [Route("upload")]
    [HttpPost]
    public async Task UploadLogo([FromForm] LogoViewModel model)
    {
        var hasFile = !string.IsNullOrEmpty(model.Logo?.FileName);
        _logger.LogDebug("hasFile");
        _logger.LogDebug(hasFile.ToString());
        var obj = new LogoDto();
        await using var memoryStream = new MemoryStream();
        if (model.Logo != null && model.Logo.Length > 0)
        {
            await model.Logo.CopyToAsync(memoryStream);
            memoryStream.Position = 0;
                    
            obj.LogoContent = new RemoteStreamContent(memoryStream, fileName: model.Logo.FileName, contentType: model.Logo.ContentType);
        }
        await _logoAppService.CreateLogoAsync(obj);
        await memoryStream.DisposeAsync();
    }
}

[RemoteService(IsEnabled = false)]
public class LogoAppService : ApplicationService
{
    private readonly IWebHostEnvironment _webHostEnvironment;
    private const string LogoFoler = "logos";
    public LogoAppService(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }
    
    public async Task CreateLogoAsync(LogoDto logoDto)
    {
        var fullPath = Path.Combine(_webHostEnvironment.WebRootPath, LogoFoler);
        Directory.CreateDirectory(fullPath);
        // using (var sw = File.Create(Path.Combine(fullPath, logoDto.LogoContent.FileName)))
        // {
        //     await logoDto.LogoContent.GetStream().CopyToAsync(sw);
        // }

        var ext = Path.GetExtension(logoDto.LogoContent.FileName);
        using (var sw = File.Create(Path.Combine(fullPath, Path.Combine(GuidGenerator.Create() + ext))))
        {
            await logoDto.LogoContent.GetStream().CopyToAsync(sw);
        }
    }
}


public class LogoDto
{
    [Required]
    public RemoteStreamContent LogoContent { get; set; }
}

public class LogoViewModel
{
    [Required]
    [MaxFileSize(maxFileSize: 1 * 1024 * 1024)]
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