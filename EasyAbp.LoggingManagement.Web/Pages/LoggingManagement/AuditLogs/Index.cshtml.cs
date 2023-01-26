using EasyAbp.LoggingManagement.Web.EasyAbp.LoggingManagement.SystemLogs;
using EasyAbp.LoggingManagement.Web.Pages.LoggingManagement.SystemLogs.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Auditing;

namespace EasyAbp.LoggingManagement.Web.Pages.LoggingManagement.AuditLogs
{
    [DisableAuditing]
    public class IndexModel : LoggingManagementPageModel
    {
        [BindProperty(SupportsGet = true)]
        public AuditLogFilterViewModel QueryModel { get; set; } 

        public async Task OnGetAsync()
        {
            await Task.CompletedTask;
        }
    }
}
