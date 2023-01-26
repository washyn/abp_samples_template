using Microsoft.AspNetCore.Mvc.RazorPages;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.Auditing;

namespace EasyAbp.LoggingManagement.Web.Pages.LoggingManagement.AuditLogs.EntityChanges;

[DisableAuditing]
public class Index : AbpPageModel
{
    public void OnGet()
    {
        
    }
}