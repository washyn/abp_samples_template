using System.Diagnostics;
using Acme.Samples.Data;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.AuditLogging;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Identity;

namespace Acme.Samples.Select;

#region Common request response objs

public class LookupEntity<TKey>
{
    public TKey Id { get; set; }
    public string DisplayName { get; set; }
}

public class LookupRequestDto : PagedResultRequestDto
{
    public string Filter { get; set; }
}

#endregion

// una clase a la cual se le pueda, especificar el tipo de key y entidad y con eso que se genere automaticamente el select...
// como mejora que se le pueda especificar el nombre del field a buscar en contains

#region Methods for role

public class SelectRoleAppService : ApplicationService
{
    private readonly RolRepo _repo;

    public SelectRoleAppService(RolRepo repo)
    {
        _repo = repo;
    }
    public async Task<PagedResultDto<LookupEntity<Guid>>> GetListAsync(LookupRequestDto input)
    {
        var count = await _repo.GetCountSelectListAsync(input.Filter);
        var data = await _repo.GetPagedSelectListAsync(input.Filter, input.SkipCount, input.MaxResultCount);
        return new PagedResultDto<LookupEntity<Guid>>(count, data);
    }

    public Task<LookupEntity<Guid>> GetAsync(Guid id)
    {
        return _repo.GetSelectItemAsync(id);
    }
}


public class RolRepo : EfCoreRepository<SamplesDbContext,IdentityRole, Guid>, ITransientDependency
{
    public RolRepo(IDbContextProvider<SamplesDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
    
    #region Select, loockup

    public async Task<List<LookupEntity<Guid>>> GetPagedSelectListAsync(
        string filter,
        int skipCount = 0,
        int maxResultCount = 10,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var queryableSelect = await GetSelectQueryable();
        var query = ApplyFilter(queryableSelect, filter);
        return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken: cancellationToken);
    }
        
    public async Task<long> GetCountSelectListAsync(string filter,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var queryableSelect = await GetSelectQueryable();
        var query = ApplyFilter(queryableSelect, filter);
        return await query.LongCountAsync();
    }

    #endregion
    
    IQueryable<LookupEntity<Guid>> ApplyFilter(IQueryable<LookupEntity<Guid>> query, string filterText)
    {
        return query.WhereIf(!string.IsNullOrEmpty(filterText), entity => entity.DisplayName.Contains(filterText));
    }
    public async Task<LookupEntity<Guid>> GetSelectItemAsync(Guid id)
    {
        var queryable = await GetSelectQueryable();
        var res = await queryable.FirstAsync(a => a.Id == id);
        return res;
    }
    public async Task<IQueryable<LookupEntity<Guid>>> GetSelectQueryable()
    {
        var queryAble = await this.GetDbSetAsync();
        return queryAble.Select(a => new LookupEntity<Guid>()
        {
            Id = a.Id,
            DisplayName = a.Name
        });
    }
}

#endregion



#region Methods for AbpEntityPropertyChanges

public class SelectEntytiPropChange : ApplicationService
{
    private readonly EntityRepo _repo;

    public SelectEntytiPropChange(EntityRepo repo)
    {
        _repo = repo;
    }
    
    public async Task<PagedResultDto<LookupEntity<Guid>>> GetListAsync(LookupRequestDto input)
    {
        var count = await _repo.GetCountSelectListAsync(input.Filter);
        var data = await _repo.GetPagedSelectListAsync(input.Filter, input.SkipCount, input.MaxResultCount);
        return new PagedResultDto<LookupEntity<Guid>>(count, data);
    }

    public Task<LookupEntity<Guid>> GetAsync(Guid id)
    {
        return _repo.GetSelectItemAsync(id);
    }
}


public class EntityRepo : EfCoreRepository<SamplesDbContext, EntityPropertyChange, Guid>, ITransientDependency
{
    public EntityRepo(IDbContextProvider<SamplesDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
    
    #region Select, loockup

    public async Task<List<LookupEntity<Guid>>> GetPagedSelectListAsync(
        string filter,
        int skipCount = 0,
        int maxResultCount = Int32.MaxValue,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var queryableSelect = await GetSelectQueryable();
        var query = ApplyFilter(queryableSelect, filter);
        return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken: cancellationToken);
    }
        
    public async Task<long> GetCountSelectListAsync(string filter,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var queryableSelect = await GetSelectQueryable();
        var query = ApplyFilter(queryableSelect, filter);
        return await query.LongCountAsync();
    }

    #endregion
    
    IQueryable<LookupEntity<Guid>> ApplyFilter(IQueryable<LookupEntity<Guid>> query, string filterText)
    {
        return query.WhereIf(!string.IsNullOrEmpty(filterText), entity => entity.DisplayName.Contains(filterText));
    }
    public async Task<LookupEntity<Guid>> GetSelectItemAsync(Guid id)
    {
        var queryable = await GetSelectQueryable();
        var res = await queryable.FirstAsync(a => a.Id == id);
        return res;
    }
    public async Task<IQueryable<LookupEntity<Guid>>> GetSelectQueryable()
    {
        var queryAble = await this.GetDbSetAsync();
        return queryAble.Select(a => new LookupEntity<Guid>()
        {
            Id = a.Id,
            DisplayName = a.NewValue
        });
    }
}

#endregion