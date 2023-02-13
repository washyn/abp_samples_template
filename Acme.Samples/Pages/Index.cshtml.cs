using EasyAbp.Abp.TagHelperPlus.EasySelector;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Acme.Samples.Pages;

public class IndexModel : AbpPageModel
{
    public Guid RolId { get; set; }
    
    [EasySelector(
        getListedDataSourceUrl: "/api/app/custom-select-entity-change",
        getSingleDataSourceUrl: "/api/app/custom-select-entity-change/{id}",
        keyPropertyName: "id",
        textPropertyName: "displayName",
        itemListPropertyName: "items",
        hideSubText: false,
        runScriptOnWindowLoad: true)]
    public Guid EntityId { get; set; }
    public Guid Ations { get; set; }
}