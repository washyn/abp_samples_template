using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EasyAbp.LoggingManagement.Web.Pages.LoggingManagement.AuditLogs.EntityChanges;

public class Index : PageModel
{
    public EntityChangeFilter Filter { get; set; }
    public void OnGet()
    {
        
    }
}


public class EntityChangeFilter
{
    public string EntityId { get; set; }
    public string EntityTypeFullName { get; set; }
}