using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EasyAbp.LoggingManagement.Web.Pages.LoggingManagement.AuditLogs.EntityChanges;

public class Details : PageModel
{
    [BindProperty(SupportsGet = true)]
    public string EntityId { get; set; }
    [BindProperty(SupportsGet = true)]
    public string EntityTypeFullName { get; set; }
    public void OnGet()
    {
        
    }
}