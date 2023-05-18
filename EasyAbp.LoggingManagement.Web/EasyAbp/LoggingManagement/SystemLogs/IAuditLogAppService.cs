using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;
using EasyAbp.LoggingManagement.Permissions;
using EasyAbp.LoggingManagement.SystemLogs.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Auditing;
using Volo.Abp.AuditLogging;
using Volo.Abp.Domain.Repositories;

namespace EasyAbp.LoggingManagement.Web.EasyAbp.LoggingManagement.SystemLogs;

public interface IAuditLogAppService : IReadOnlyAppService<AuditLogDto, Guid, AuditLogFilterDto>
{
    
}

[DisableAuditing]
[Authorize(LoggingManagementPermissions.SystemLog.Default)]
public class AuditLogAppService : ReadOnlyAppService<AuditLog, AuditLogDto, Guid, AuditLogFilterDto>, IAuditLogAppService
{
    private readonly IAuditLogRepository _auditLogRepository;

    public AuditLogAppService(IReadOnlyRepository<AuditLog, Guid> repository,
        IAuditLogRepository auditLogRepository) : base(repository)
    {
        _auditLogRepository = auditLogRepository;
    }

    public override async Task<AuditLogDto> GetAsync(Guid id)
    {
        return ObjectMapper.Map<AuditLog, AuditLogDto>(await _auditLogRepository.GetAsync(id));
    }

    public override async Task<PagedResultDto<AuditLogDto>> GetListAsync(AuditLogFilterDto input)
    {
        var count = await _auditLogRepository.GetCountAsync(
            startTime: input.StartTime,
            endTime: input.EndTime,
            userId: input.UserId,
            maxExecutionDuration: input.MaxExecutionDuration,
            minExecutionDuration: input.MinExecutionDuration,
            hasException: input.HasException
            );
        var items = await _auditLogRepository.GetListAsync(
            sorting: input.Sorting,
            maxResultCount: input.MaxResultCount,
            skipCount: input.SkipCount,
            startTime: input.StartTime,
            endTime: input.EndTime,
            userId: input.UserId,
            maxExecutionDuration: input.MaxExecutionDuration,
            minExecutionDuration: input.MinExecutionDuration,
            hasException: input.HasException);
        return new PagedResultDto<AuditLogDto>()
        {
            TotalCount = count,
            Items = ObjectMapper.Map<List<AuditLog>, List<AuditLogDto>>(items)
        };
    }
}


public class AuditLogFilterDto: PagedAndSortedResultRequestDto
{
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    // public string HttpMethod { get; set; }
    // public string Url { get; set; }
    public Guid? UserId { get; set; }
    // public string UserName { get; set; }
    // public string ApplicationName { get; set; }
    // public string ClientIpAddress { get; set; }
    // public string CorrelationId { get; set; }
    public int? MaxExecutionDuration { get; set; }
    public int? MinExecutionDuration { get; set; }
    public bool? HasException { get; set; }
    // public HttpStatusCode? HttpStatusCode { get; set; }
}


public class AuditLogFilterViewModel
{
    [DataType(DataType.Date)]
    public DateTime? StartTime { get; set; }
    
    [DataType(DataType.Date)]
    public DateTime? EndTime { get; set; }
    // public string HttpMethod { get; set; }
    // public string Url { get; set; }
    public Guid? UserId { get; set; }
    // public string UserName { get; set; }
    // public string ApplicationName { get; set; }
    // public string ClientIpAddress { get; set; }
    // public string CorrelationId { get; set; }
    public int? MaxExecutionDuration { get; set; }
    public int? MinExecutionDuration { get; set; }
    
    [Display(Name = "HasException")]
    public bool? HasException { get; set; }
    // public HttpStatusCode? HttpStatusCode { get; set; }
}

public class AuditLogDto: EntityDto<Guid>
{
    public Guid? TenantId { get; set; }

    public string ApplicationName { get; set; }

    // public string Identity { get; set; }

    // public string Action { get; set; }

    public Guid? UserId { get; set; }

    public string UserName { get; set; }

    public string TenantName { get; set; }

    public string ClientId { get; set; }

    public string CorrelationId { get; set; }

    public string ClientIpAddress { get; set; }

    public string BrowserInfo { get; set; }
    
    public string Exceptions { get; set; }

    // public DateTime? CreationTime { get; set; }

    // public ExtraProperties ExtraProperties { get; set; }
    
    public DateTime ExecutionTime { get; set; }

    public int ExecutionDuration { get; set; }
    
    public string Url { get; set; }
    
    public Guid Id { get; set; }
}