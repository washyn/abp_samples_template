using System.ComponentModel.DataAnnotations;
using Acme.Samples.Pages.Components.UserStatisticWidget;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Widgets;
using Volo.Abp.BlobStoring;
using Volo.Abp.BlobStoring.FileSystem;
using Volo.Abp.Http;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Acme.Samples.Pages.Components.ImagesWidget;

[Widget(AutoInitialize = true, 
    ScriptFiles = new []{"/Pages/Components/ImagesWidget/Default.js"},
    RefreshUrl = "Widgets/Files"
    )]
public class ImagesWidgetViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        var model = new FilesViewModel()
        {
            CanBeAdd = true,
            Files = Data.ViewData
        };
        return View("~/Pages/Components/ImagesWidget/Default.cshtml",model);
    }
}

public static class Data
{
    public static List<FileModel> ViewData = new List<FileModel>();
}


// Widget refresh controller...
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
    public async Task Upload([FromForm]UploadViewModel model)
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

public class FilesViewModel
{
    public bool CanBeAdd { get; set; }
    public List<FileModel> Files { get; set; }
}

public class FileModel
{
    public int Id { get; set; }
    public string FileName { get; set; }
    public string Description { get; set; }
    public bool CanBeDelete { get; set; }
    public bool CanBeDownload { get; set; }
}

public class UploadViewModel
{
    [Required]
    public string Description { get; set; }
    [Required]
    public IFormFile File { get; set; }
}

[BlobContainerName("pictures")]
public class PictureContainer
{
        
}

[DependsOn(typeof(AbpBlobStoringFileSystemModule))]
public class ExampleWidgetModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var host = context.Services.GetHostingEnvironment();
        Configure<AbpBlobStoringOptions>(options =>
        {
            options.Containers.ConfigureDefault(container =>
            {
                container.UseFileSystem(fileSystem =>
                {
                    fileSystem.BasePath = host.WebRootPath;
                });
            });
        });
    }
}