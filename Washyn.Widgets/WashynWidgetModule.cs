using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Services;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AuditLogging;
using Volo.Abp.BlobStoring;
using Volo.Abp.Http;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;
using Volo.Abp.VirtualFileSystem;
using Washyn.Widgets.Pages.Components.ImagesWidget;

namespace Washyn.Widgets;

[DependsOn(typeof(AbpBlobStoringModule))]
[DependsOn(typeof(AbpAspNetCoreMvcModule))]
[DependsOn(typeof(AbpAuditLoggingDomainModule))]
[DependsOn(typeof(AbpVirtualFileSystemModule))]
public class WashynWidgetModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var host = context.Services.GetHostingEnvironment();
        
        Configure<AbpNavigationOptions>(options =>
        {
            options.MenuContributors.Add(new WidgetsMenuContributor());
        });
        
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<WashynWidgetModule>("Washyn.Widgets");
        });
        
        Configure<AbpAspNetCoreMvcOptions>(options =>
        {
            options.ConventionalControllers.Create(typeof(WashynWidgetModule).Assembly);
        });
    }
}

[Route("Widgets")]
public class WidgetsController : AbpController
{
    [HttpGet]
    [Route("Files")]
    public IActionResult Files()
    {
        return ViewComponent(typeof(ImagesWidgetViewComponent));
    }
}

[Route("files")]
public class FilesController : AbpController
{
    private readonly IBlobContainer<PictureContainer> _container;

    public FilesController(IBlobContainer<PictureContainer> container)
    {
        _container = container;
    }

    [HttpPost]
    public async Task Upload([FromForm] UploadViewModel model)
    {
        Data.ViewData.Add(new FileModel()
        {
            Id = new Random().Next(),
            Description = model.Description,
            FileName = model.File.FileName,
            CanBeDelete = true,
            CanBeDownload = true,
        });
        await _container.SaveAsync(model.File.FileName, model.File.OpenReadStream(), true);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Download(int id)
    {
        var fileRef = Data.ViewData.First(a => a.Id == id);
        var file = await _container.GetAsync(fileRef.FileName);
        return File(file, MimeTypes.Application.OctetStream, fileRef.FileName);
    }

    [HttpDelete("{id}")]
    public async Task Remove(int id)
    {
        var fileRef = Data.ViewData.First(a => a.Id == id);
        Data.ViewData.Remove(fileRef);
    }
}

public class UploadViewModel
{
    [Required] public string Description { get; set; }
    [Required] public IFormFile File { get; set; }
}

[BlobContainerName("pictures")]
public class PictureContainer
{
}

public class UserStatisticWidgetInputDto
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}

public class UserStatisticResultDto
{
    public Dictionary<DateTime, double> Data { get; set; }
}


public class UserStatisticAppService : ApplicationService
{
    private readonly IAuditLogRepository _repository;

    public UserStatisticAppService(IAuditLogRepository repository)
    {
        _repository = repository;
    }

    public async Task<UserStatisticResultDto> GetUserStatisticWidgetAsync(UserStatisticWidgetInputDto input)
    {
        var tempRes = await _repository.GetAverageExecutionDurationPerDayAsync(input.StartDate, input.EndDate);
        return new UserStatisticResultDto() { Data = tempRes };
    }
}


public class WidgetsMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        // var administration = context.Menu.GetAdministration();
        // var l = context.GetLocalizer<BillingResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                "Washyn.Widgets",
                "Widget samples",
                "~/WidgetSamples"
            )
        );
    }
}