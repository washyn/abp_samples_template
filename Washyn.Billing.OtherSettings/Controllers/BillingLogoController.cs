using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.BlobStoring;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;
using Volo.Abp.SettingManagement;
using Volo.Abp.SettingManagement.Web.Pages.SettingManagement;
using Volo.Abp.Settings;
using Washyn.Billing.OtherSettings.Pages.Components.BillingLogoSetting;
using Washyn.Billing.OtherSettings.Pages.Components.CertificateSetting;

namespace Washyn.Billing.OtherSettings.Controllers;

[Authorize(BillingOthersPermissions.Section.Certificate)]
[Route("billing-certificate")]
public class BillingCertificateController : AbpController
{
    private readonly IBlobContainer<BillingCertificateContainer> _blobContainer;
    private readonly ISettingManager _settingManager;

    public BillingCertificateController(IBlobContainer<BillingCertificateContainer> blobContainer,
        ISettingManager settingManager)
    {
        _blobContainer = blobContainer;
        _settingManager = settingManager;
    }
    
    [Route("file")]
    [HttpPost]
    public async Task UploadCert([FromForm] BillingCertificateViewModel model)
    {
        ValidateModel();
        await using var memoryStream = new MemoryStream();
        await model.Certificate.CopyToAsync(memoryStream);
        memoryStream.Position = 0;
        var fileName = GenerateFileName(model.Certificate.FileName);
        var lastLogo = await GetCurrentCert();
        if (!lastLogo.IsNullOrEmpty())
        {
            await _blobContainer.DeleteAsync(lastLogo);
        }
        await _blobContainer.SaveAsync(fileName, memoryStream, overrideExisting: true);
        await memoryStream.DisposeAsync();
        if (CurrentTenant.IsAvailable)
        {
            await _settingManager.SetForCurrentTenantAsync(OtherSettingDefinitionProvider.BillingCertificateSettingName, fileName);
        }
        else
        {
            await _settingManager.SetGlobalAsync(OtherSettingDefinitionProvider.BillingCertificateSettingName, fileName);
        }
    }

    [Route("password")]
    [HttpPost]
    public async Task UpdatePassword([FromBody]CertificatePasswordViewModel model)
    {
        ValidateModel();
        if (CurrentTenant.IsAvailable)
        {
            await _settingManager.SetForCurrentTenantAsync(OtherSettingDefinitionProvider.BillingCertificatePasswordSettingName, model.Password);
        }
        else
        {
            await _settingManager.SetGlobalAsync(OtherSettingDefinitionProvider.BillingCertificatePasswordSettingName, model.Password);
        }
    }
    
    private async Task<string> GetCurrentCert()
    {
        var logo = await _settingManager.GetOrNullGlobalAsync(OtherSettingDefinitionProvider.BillingCertificateSettingName);
        if (CurrentTenant.IsAvailable)
        {
            logo = await _settingManager.GetOrNullForTenantAsync(OtherSettingDefinitionProvider.BillingCertificateSettingName, CurrentTenant.GetId(), false);
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

[Authorize(BillingOthersPermissions.Section.Logo)]
[Route("billing-logo")]
public class BillingLogoController : AbpController
{
    private readonly IBlobContainer<BillingLogoContainer> _blobContainer;
    private readonly ISettingManager _settingManager;

    public BillingLogoController(IBlobContainer<BillingLogoContainer> blobContainer,
        ISettingManager settingManager)
    {
        _blobContainer = blobContainer;
        _settingManager = settingManager;
    }
    
    [HttpPost]
    public async Task UploadLogo([FromForm] BillingLogoViewModel model)
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
            await _settingManager.SetForCurrentTenantAsync(OtherSettingDefinitionProvider.BillingLogoSettingName, fileName);   
        }
        else
        {
            await _settingManager.SetGlobalAsync(OtherSettingDefinitionProvider.BillingLogoSettingName, fileName);   
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
            return NotFound();
        }
        return File(res, "image/*");
    }
    
    private async Task<string> GetCurrentLogo()
    {
        var logo = await _settingManager.GetOrNullGlobalAsync(OtherSettingDefinitionProvider.BillingLogoSettingName);
        if (CurrentTenant.IsAvailable)
        {
            logo = await _settingManager.GetOrNullForTenantAsync(OtherSettingDefinitionProvider.BillingLogoSettingName, CurrentTenant.GetId(), false);
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

public class OtherSettingDefinitionProvider : SettingDefinitionProvider
{
    public const string BillingLogoSettingName = "Setting.BillingLogoSettingName";
    public const string BillingCertificateSettingName = "Setting.BillingCertificateSettingName";
    public const string BillingCertificatePasswordSettingName = "Setting.BillingCertificatePasswordSettingName";
    public const int MaxLogoFileSize = 1024 * 1024 * 1; // 1 mb
    public const int MaxCertificateFileSize = 1024 * 1024 * 1; // 1 mb
    public override void Define(ISettingDefinitionContext context)
    {
        context.Add(new SettingDefinition(BillingLogoSettingName, string.Empty));
        context.Add(new SettingDefinition(BillingCertificateSettingName, string.Empty));
        context.Add(new SettingDefinition(BillingCertificatePasswordSettingName, string.Empty, isEncrypted: true));
    }
}

public class BillingLogoSettingPageContributor : ISettingPageContributor
{
    public async Task ConfigureAsync(SettingPageCreationContext context)
    {
        if (await CheckPermissionsAsync(context))
        {
            context.Groups.Add(new SettingPageGroup("BillingLogoSettingId", 
                "Configuración de logotipo de comprobante", 
                typeof(BillingLogoSettingViewComponent)));
        }
    }

    public async Task<bool> CheckPermissionsAsync(SettingPageCreationContext context)
    {
        var authorizationService = context.ServiceProvider.GetRequiredService<IAuthorizationService>();
        return await authorizationService.IsGrantedAsync(BillingOthersPermissions.Section.Logo);
    }
}

public class BillingCetificateSettingPageContributor : ISettingPageContributor
{
    public async Task ConfigureAsync(SettingPageCreationContext context)
    {
        if (await CheckPermissionsAsync(context))
        {
            context.Groups.Add(new SettingPageGroup("BillingCetificateSettingId", 
                "Configuración de certificado", 
                typeof(BillingCertificateSettingViewComponent)));
        }
    }

    public async Task<bool> CheckPermissionsAsync(SettingPageCreationContext context)
    {
        var authorizationService = context.ServiceProvider.GetRequiredService<IAuthorizationService>();
        return await authorizationService.IsGrantedAsync(BillingOthersPermissions.Section.Certificate);
    }
}

public static class BillingOthersPermissions
{
    public const string BillingLogoGroupName = "BillingLogo";
    public const string CertificateGroupName = "GroupNameCertificate";
    public static class Section
    {
        public const string Logo = BillingLogoGroupName + ".Logo";
        public const string Certificate = BillingLogoGroupName + ".Certificate";
    }
}

public class BillingLogoPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var eventHubGroup = context.AddGroup(BillingOthersPermissions.BillingLogoGroupName, L("Configuración de logo de comprobante"));
        var logoPermissions = eventHubGroup.AddPermission(BillingOthersPermissions.Section.Logo, L("Permiso para cambiar de logo de comprobante"));
        
        var groupCert = context.AddGroup(BillingOthersPermissions.CertificateGroupName, L("Configuración de certificado"));
        groupCert.AddPermission(BillingOthersPermissions.Section.Certificate, L("Permiso para cambiar certificado"));
    }
    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<BillingOtherSettingResource>(name);
    }
}

[LocalizationResourceName("BillingLogoResource")]
public class BillingOtherSettingResource
{
}

[BlobContainerName("billing-logo-pictures")]
public class BillingLogoContainer
{
}

[BlobContainerName("billing-certificate")]
public class BillingCertificateContainer
{
}



public class BillingLogoViewModel
{
    [Required]
    [MaxFileSize(maxFileSize: OtherSettingDefinitionProvider.MaxLogoFileSize)]
    public IFormFile Logo { get; set; }
}

public class BillingCertificateViewModel
{
    [Required]
    [MaxFileSize(maxFileSize: OtherSettingDefinitionProvider.MaxCertificateFileSize)]
    public IFormFile Certificate { get; set; }
}

public class CertificatePasswordViewModel
{
    [DataType(DataType.Password)]
    [Display(Name = "Contraseña")]
    [Required]
    public string Password { get; set; }
    
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

#endregion