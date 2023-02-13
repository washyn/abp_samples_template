using Acme.Samples.Select;
using EasyAbp.Abp.TagHelperPlus.EasySelector;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Acme.Samples.Pages;

public class IndexModel : AbpPageModel
{
    private readonly ICustomSelectEntityChange _change;
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
        // = Guid.Parse("3bf3cf48-5b05-80d3-1281-3a02aae229bb");
    public Guid Ations { get; set; }

    public IndexModel(ICustomSelectEntityChange change)
    {
        _change = change;
    }
}