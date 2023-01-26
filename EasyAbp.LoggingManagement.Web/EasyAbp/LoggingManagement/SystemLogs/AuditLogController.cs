using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace EasyAbp.LoggingManagement.Web.EasyAbp.LoggingManagement.SystemLogs;

[RemoteService(Name = LoggingManagementRemoteServiceConsts.RemoteServiceName)]
[Route("/api/logging-management/audit-log")]
public class AuditLogController : AbpController, IAuditLogAppService
{
    private readonly IAuditLogAppService _auditLogAppService;

    public AuditLogController(IAuditLogAppService auditLogAppService)
    {
        _auditLogAppService = auditLogAppService;
    }
    
    [HttpGet("{id}")]
    public Task<AuditLogDto> GetAsync(Guid id)
    {
        return _auditLogAppService.GetAsync(id);
    }
    
    [HttpGet]
    public Task<PagedResultDto<AuditLogDto>> GetListAsync(AuditLogFilterDto input)
    {
        return _auditLogAppService.GetListAsync(input);
    }
}
