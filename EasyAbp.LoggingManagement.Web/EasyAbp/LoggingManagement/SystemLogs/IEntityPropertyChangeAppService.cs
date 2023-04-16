using EasyAbp.LoggingManagement.Permissions;
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

public interface IEntityPropertyChangeAppService: IReadOnlyAppService<EntityPropertyChangeDto, Guid, EntityPropertyChangeFilterDto>
{
    
}

[DisableAuditing]
[Authorize(LoggingManagementPermissions.SystemLog.Default)]
public class EntityPropertyChangeAppService: ReadOnlyAppService<EntityPropertyChange, EntityPropertyChangeDto, Guid, EntityPropertyChangeFilterDto> , IEntityPropertyChangeAppService
{
    public EntityPropertyChangeAppService(IReadOnlyRepository<EntityPropertyChange, Guid> repository) : base(repository)
    {
    }
}

public class EntityPropertyChangeFilterDto : PagedAndSortedResultRequestDto
{
    
}

public class EntityPropertyChangeDto: EntityDto<Guid>
{
    public virtual Guid? TenantId { get; protected set; }

    public virtual Guid EntityChangeId { get; protected set; }

    public virtual string NewValue { get; protected set; }

    public virtual string OriginalValue { get; protected set; }

    public virtual string PropertyName { get; protected set; }

    public virtual string PropertyTypeFullName { get; protected set; }
}

[DisableAuditing]
[RemoteService(Name = LoggingManagementRemoteServiceConsts.RemoteServiceName)]
[Route("/api/logging-management/entity-property-change")]
public class EntityPropertyChangeController : AbpController, IEntityPropertyChangeAppService
{
    private readonly EntityPropertyChangeAppService _propertyChangeAppService;

    public EntityPropertyChangeController(EntityPropertyChangeAppService propertyChangeAppService)
    {
        _propertyChangeAppService = propertyChangeAppService;
    }
    [HttpGet("{id}")]
    public Task<EntityPropertyChangeDto> GetAsync(Guid id)
    {
        return _propertyChangeAppService.GetAsync(id);
    }
    [HttpGet()]
    public Task<PagedResultDto<EntityPropertyChangeDto>> GetListAsync(EntityPropertyChangeFilterDto input)
    {
        return _propertyChangeAppService.GetListAsync(input);
    }
}