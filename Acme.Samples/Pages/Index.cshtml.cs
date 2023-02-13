using Acme.Samples.Select;
using EasyAbp.Abp.TagHelperPlus.EasySelector;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Acme.Samples.Pages;

public class IndexModel : AbpPageModel
{
    [EasySelector(
        getListedDataSourceUrl: "/api/app/custom-select-entity-change",
        getSingleDataSourceUrl: "/api/app/custom-select-entity-change/{id}",
        keyPropertyName: "id",
        textPropertyName: "displayName",
        itemListPropertyName: "items",
        hideSubText: false,
        runScriptOnWindowLoad: true)]
    public Guid EntityId { get; set; } 
        = Guid.Parse("285cf911-8988-7c57-98d5-3a08fd68db24");


    public IndexModel()
    {
    }
}