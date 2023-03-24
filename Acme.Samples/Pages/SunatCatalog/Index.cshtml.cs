using EasyAbp.Abp.TagHelperPlus.EasySelector;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;
using Volo.Abp.VirtualFileSystem;

namespace Acme.Samples.Pages.SunatCatalog;

public class Index : PageModel
{
    [Inject]
    public IVirtualFileProvider FileProvider { get; set; }

    public List<SunatCommonCatalogDto> List { get; set; }
    
    
    [EasySelector(
        getListedDataSourceUrl: "/api/app/tipo-documento-select",
        getSingleDataSourceUrl: "/api/app/tipo-documento-select/{id}",
        keyPropertyName: "id",
        textPropertyName: "displayName",
        itemListPropertyName: "items",
        hideSubText: false,
        runScriptOnWindowLoad: true)]
    public string TipoDocumento { get; set; }
    
    [EasySelector(
        getListedDataSourceUrl: "/api/app/unidad-medida-comercial-select",
        getSingleDataSourceUrl: "/api/app/unidad-medida-comercial-select/{id}",
        keyPropertyName: "id",
        textPropertyName: "displayName",
        itemListPropertyName: "items",
        hideSubText: false,
        runScriptOnWindowLoad: true)]
    public string UnidadMedida { get; set; }
    
    [EasySelector(
        getListedDataSourceUrl: "/api/app/tipo-tributo-select",
        getSingleDataSourceUrl: "/api/app/tipo-tributo-select/{id}",
        keyPropertyName: "id",
        textPropertyName: "displayName",
        itemListPropertyName: "items",
        hideSubText: false,
        runScriptOnWindowLoad: true)]
    public string TipoTributo { get; set; }
    
    public void OnGet()
    {
        var stream = FileProvider.GetFileInfo(FileNames.Catalog.TIPO_DE_DOCUMENTO_01).ReadAsString();
        var data = JsonConvert.DeserializeObject<List<SunatCommonCatalogDto>>(stream);
        List = new List<SunatCommonCatalogDto>();
        List.AddRange(data);
    }
}