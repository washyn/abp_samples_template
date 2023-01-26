using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Auditing;
using Volo.Abp.AuditLogging;
using Volo.Abp.Domain.Repositories;

namespace EasyAbp.LoggingManagement.Web.EasyAbp.LoggingManagement.SystemLogs;

public interface IEntityChangeAppService : IReadOnlyAppService<EntityChangeDto, Guid, EntityChangeFilterDto>
{
    
}

public class EntityChangeAppService: ReadOnlyAppService<EntityChange, EntityChangeDto, Guid, EntityChangeFilterDto>, IEntityChangeAppService
{
    public EntityChangeAppService(IReadOnlyRepository<EntityChange, Guid> repository) : base(repository)
    {
    }
}

public class EntityChangeDto: EntityDto<Guid>
{
    public virtual Guid AuditLogId { get; protected set; }

    public virtual Guid? TenantId { get; protected set; }

    public virtual DateTime ChangeTime { get; protected set; }

    public virtual EntityChangeType ChangeType { get; protected set; }

    public virtual Guid? EntityTenantId { get; protected set; }

    public virtual string EntityId { get; protected set; }

    public virtual string EntityTypeFullName { get; protected set; }
}

public class EntityChangeFilterDto : PagedAndSortedResultRequestDto
{
    
}

[RemoteService(Name = LoggingManagementRemoteServiceConsts.RemoteServiceName)]
[Route("/api/logging-management/entity-change")]
public class EntityChangeController : AbpController, IEntityChangeAppService
{
    private readonly IEntityChangeAppService _entityChangesAppService;

    public EntityChangeController(IEntityChangeAppService entityChangesAppService)
    {
        _entityChangesAppService = entityChangesAppService;
    }
    
    [HttpGet("{id}")]
    public Task<EntityChangeDto> GetAsync(Guid id)
    {
        return _entityChangesAppService.GetAsync(id);
    }
    
    [HttpGet]
    public Task<PagedResultDto<EntityChangeDto>> GetListAsync(EntityChangeFilterDto input)
    {
        return _entityChangesAppService.GetListAsync(input);
    }
}