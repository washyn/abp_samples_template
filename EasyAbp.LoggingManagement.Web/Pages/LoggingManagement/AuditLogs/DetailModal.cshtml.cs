using EasyAbp.LoggingManagement.Web.EasyAbp.LoggingManagement.SystemLogs;
using EasyAbp.LoggingManagement.Web.Pages.LoggingManagement.SystemLogs.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AuditLogging;

namespace EasyAbp.LoggingManagement.Web.Pages.LoggingManagement.AuditLogs
{
    public class DetailModalModel : LoggingManagementPageModel
    {
        [Inject]
        public IAuditLogAppService AppService { get; set; }
        public AuditLogDto Model { get; set; }

        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }
        
        public async Task OnGetAsync()
        {
            Model = await AppService.GetAsync(Id);
        }
    }
}