using EasyAbp.Abp.TagHelperPlus.EasySelector;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Acme.Samples.Pages;

public class ModalSample : PageModel
{
    [EasySelector(
        getListedDataSourceUrl: "/api/app/audit-log-select",
        getSingleDataSourceUrl: "/api/app/audit-log-select/{id}",
        keyPropertyName: "id",
        textPropertyName: "displayName",
        itemListPropertyName: "items",
        hideSubText: false,
        runScriptOnWindowLoad: false)]
    public Guid EntityId { get; set; }
    public void OnGet()
    {
        
    }
}