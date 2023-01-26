using EasyAbp.LoggingManagement.Web.EasyAbp.LoggingManagement.SystemLogs;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.AuditLogging;
using Volo.Abp.Domain.Repositories;

namespace EasyAbp.LoggingManagement.Web.Pages.LoggingManagement.AuditLogs;

public class Detail : AbpPageModel
{
    [Inject]
    public IAuditLogAppService AppService { get; set; }
        
    [Inject]
    public IRepository<AuditLogAction, Guid> LogActionRepository { get; set; }
    public AuditLogDto AuditLog { get; set; }
    public List<AuditLogAction> LogActions { get; set; } = new List<AuditLogAction>();

    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    public async Task OnGetAsync()
    {
        var queryable = await LogActionRepository.GetQueryableAsync();
        var res = await queryable.Where(a => a.AuditLogId == Id).ToListAsync();
        LogActions = res;
        AuditLog = await AppService.GetAsync(Id);
    }
}