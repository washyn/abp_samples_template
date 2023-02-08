using System.ComponentModel.DataAnnotations;
using Acme.Samples.Pages.Components.UserStatisticWidget;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Widgets;
using Volo.Abp.BlobStoring;
using Volo.Abp.BlobStoring.FileSystem;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Acme.Samples.Pages.Components.ImagesWidget;

[Widget(AutoInitialize = true, ScriptFiles = new []{"/Pages/Components/ImagesWidget/Default.js"})]
public class ImagesWidgetViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        var model = new FilesViewModel()
        {
            CanBeAdd = true,
            Files = new List<FileModel>()
            {
               new FileModel()
               {
                   FileName = "test.jpg",
                   CanBeDelete = true,
                   CanBeDownload = true,
                   Description = "Prueba...."
               }
            }
        };
        return View(model);
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
        await _container.SaveAsync(model.File.FileName, model.File.OpenReadStream(), true);
    }
}

public class FilesViewModel
{
    public bool CanBeAdd { get; set; }
    public List<FileModel> Files { get; set; }
}

public class FileModel
{
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