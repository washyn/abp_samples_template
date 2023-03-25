using EasyAbp.Abp.TagHelperPlus.EasySelector;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Acme.Samples.Pages;

public class IndexModel : AbpPageModel
{
    [EasySelector(
        getListedDataSourceUrl: "/api/app/audit-log-select",
        getSingleDataSourceUrl: "/api/app/audit-log-select/{id}",
        keyPropertyName: "id",
        textPropertyName: "displayName",
        itemListPropertyName: "items",
        hideSubText: false,
        runScriptOnWindowLoad: true)]
    public Guid EEntityId { get; set; } 
        = Guid.Parse("285cf911-8988-7c57-98d5-3a08fd68db24");
    
    // /api/app/example-abstract-entity-select
    [EasySelector(
        getListedDataSourceUrl: "/api/app/example-abstract-entity-select",
        getSingleDataSourceUrl: "/api/app/example-abstract-entity-select/{id}",
        keyPropertyName: "id",
        textPropertyName: "displayName",
        itemListPropertyName: "items",
        // alternativeTextPropertyName: "",
        hideSubText: false,
        runScriptOnWindowLoad: true)]
    public string TipoMedida { get; set; } = "ZZ";
    
    
    [EasySelector(
        getListedDataSourceUrl: "/api/app/example-select-orderable",
        getSingleDataSourceUrl: "/api/app/example-select-orderable/{id}",
        keyPropertyName: "id",
        textPropertyName: "displayName",
        itemListPropertyName: "items",
        // alternativeTextPropertyName: "",
        hideSubText: false,
        runScriptOnWindowLoad: true)]
    public string SelectOrderable { get; set; }


    public IndexModel()
    {
    }
}