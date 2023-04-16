using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using EasyAbp.LoggingManagement.Permissions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Auditing;
using Volo.Abp.AuditLogging;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.LoggingManagement.Web.EasyAbp.LoggingManagement.SystemLogs;

public interface IEntityChangeAppService : IApplicationService
{
    Task<EntityChangeDto> GetAsync(Guid id);
    Task<PagedResultDto<EntityChangeListItem>> GetListAsync(EntityChangeFilterDto input);
}

[DisableAuditing]
[Authorize(LoggingManagementPermissions.SystemLog.Default)]
public class EntityChangeAppService: ApplicationService, IEntityChangeAppService
{
    private readonly IEntityChangeRepository _repository;

    public EntityChangeAppService(IEntityChangeRepository repository)
    {
        _repository = repository;
    }
    public Task<EntityChangeDto> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<PagedResultDto<EntityChangeListItem>> GetListAsync(EntityChangeFilterDto input)
    {
        var items = await _repository.GetListAsync(input.MaxResultCount, input.SkipCount, input.EntityId, input.EntityTypeFullName);
        var totalCount = await _repository.GetCountAsync(input.EntityId, input.EntityTypeFullName);
        return new PagedResultDto<EntityChangeListItem>()
        {
            TotalCount = totalCount,
            Items = items
        };
    }
}

public class EntityChangeRepository : EfCoreRepository<IAuditLoggingDbContext, EntityChange, Guid>, IEntityChangeRepository
{
    public EntityChangeRepository(IDbContextProvider<IAuditLoggingDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
    
    public async Task<List<EntityChangeListItem>> GetListAsync(
        int maxResultCount = 50, int skipCount = 0, 
        string entityId = null,
        string entityTypeFullName = null, 
        CancellationToken cancellationToken = default)
    {
        var query = await GetQueryListAsync(entityId, entityTypeFullName);
        // query = query.OrderBy(sorting.IsNullOrWhiteSpace() ? (nameof(EntityChange.ChangeTime) + " DESC") : sorting);
        query = query.PageBy(skipCount, maxResultCount);
        return await query.ToListAsync();
    }
    
    // var result = from change in AbpEntityChanges
    //     where change.EntityId == "11065"
    //     group change by new { change.EntityTypeFullName, change.EntityId } into changesGroup
    //     select new
    //     {
    //         Id = changesGroup.First().Id,
    //         ChangeTime = changesGroup.First().ChangeTime,
    //         ChangeType = changesGroup.First().ChangeType,
    //         EntityId = changesGroup.Key.EntityId,
    //         EntityTypeFullName = changesGroup.Key.EntityTypeFullName,
    //         CountChanges = changesGroup.Count()
    //     };

    // var result = from change in AbpEntityChanges
    //     where change.EntityId == "11065"
    //     group change by new { change.EntityTypeFullName, change.EntityId } into changesGroup
    //     orderby changesGroup.Max(x => x.ChangeTime) descending
    //     select new
    //     {
    //         Id = changesGroup.First().Id,
    //         ChangeTime = changesGroup.First().ChangeTime,
    //         EntityId = changesGroup.Key.EntityId,
    //         EntityTypeFullName = changesGroup.Key.EntityTypeFullName,
    //         CountChanges = changesGroup.Count()
    //     };
    
    public async Task<IQueryable<EntityChangeListItem>> GetQueryListAsync(
        string entityId = null,
        string entityTypeFullName = null, 
        CancellationToken cancellationToken = default)
    {
        var tempres = (await GetQueryableAsync())
            
            .GroupBy(a => new { a.EntityId, a.EntityTypeFullName })
            .Select(a => new EntityChangeListItem()
            {
                Id = a.First().Id,
                EntityTypeFullName = a.Key.EntityTypeFullName,
                EntityId = a.Key.EntityId,
                CantidadCambios = a.Count(),
                ChangeTime = a.OrderByDescending(b => b.ChangeTime).First().ChangeTime
            })
            .WhereIf(!string.IsNullOrEmpty(entityId), a=> a.EntityId == entityId)
            .WhereIf(!string.IsNullOrEmpty(entityTypeFullName), a=> a.EntityTypeFullName == entityTypeFullName);  
        
        return tempres;
    }
    

    public async Task<long> GetCountAsync(string entityId = null, string entityTypeFullName = null,
        CancellationToken cancellationToken = default)
    {
        var query = await GetQueryListAsync(entityId, entityTypeFullName);
        return await query.LongCountAsync();
    }
}

public class EntityChangeListItem
{
    public Guid Id { get; set; }
    public long CantidadCambios { get; set; }
    public DateTime ChangeTime { get; set; }
    public string EntityId { get; set; }
    public string EntityTypeFullName { get; set; }
}

public interface IEntityChangeRepository : IRepository<EntityChange, Guid>
{
    Task<List<EntityChangeListItem>> GetListAsync(
        int maxResultCount = 50,
        int skipCount = 0,
        string entityId = null,
        string entityTypeFullName = null,
        CancellationToken cancellationToken = default);

    Task<long> GetCountAsync(
        string entityId = null,
        string entityTypeFullName = null,
        CancellationToken cancellationToken = default);
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

public class EntityChangeFilterDto : PagedResultRequestDto
{
    public string EntityId { get; set; }
    public string EntityTypeFullName { get; set; }
}

[DisableAuditing]
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
    public Task<PagedResultDto<EntityChangeListItem>> GetListAsync(EntityChangeFilterDto input)
    {
        return _entityChangesAppService.GetListAsync(input);
    }
}