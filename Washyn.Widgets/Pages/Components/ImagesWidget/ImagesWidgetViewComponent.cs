using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Widgets;

namespace Washyn.Widgets.Pages.Components.ImagesWidget
{

    [Widget(AutoInitialize = true,
        ScriptFiles = new[] { "/Pages/Components/ImagesWidget/Default.js" },
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
            return View("~/Pages/Components/ImagesWidget/Default.cshtml", model);
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
    public static class Data
    {
        public static List<FileModel> ViewData = new List<FileModel>();
    }
}