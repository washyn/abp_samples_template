using Microsoft.EntityFrameworkCore;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
namespace Volo.Abp.Application.Services;

#region Entities

public class LookupEntity<TKey>
{
    public TKey Id { get; set; }
    public string DisplayName { get; set; }
}

public class LookupRequestDto : PagedResultRequestDto
{
    public string Filter { get; set; }
}

// improve: if entity implements tris aply sorting
// TODO: improve for use store, and independent of repository
public interface IHasOrder
{
    int DisplayOrder { get; }
}

#endregion

public interface ISelectAppService<TKey>
    : IApplicationService
{
    Task<LookupEntity<TKey>> GetAsync(TKey id);

    Task<PagedResultDto<LookupEntity<TKey>>> GetListAsync(LookupRequestDto input);
}

public abstract class AbstractEntitySelectAppService<TKey>
: ApplicationService
,ISelectAppService<TKey>
{
    public virtual async Task<LookupEntity<TKey>> GetAsync(TKey id)
    {
        return await GetSelectItemAsync(id);
    }

    public virtual async Task<PagedResultDto<LookupEntity<TKey>>> GetListAsync(LookupRequestDto input)
    {
        var query = ApplyFilter(await GetSelectQueryable(), input.Filter);
        var totalCount = await AsyncExecuter.CountAsync(query);
        // query = ApplyOrderSorting(query);
        query = ApplyPaging(query, input);
        var entities = await AsyncExecuter.ToListAsync(query);
        return new PagedResultDto<LookupEntity<TKey>>(totalCount, entities);
    }
    
    protected virtual async Task<LookupEntity<TKey>> GetSelectItemAsync(TKey id)
    {
        var query = await GetSelectQueryable();
        return await AsyncExecuter.FirstAsync(query, entity => entity.Id.Equals(id));
    }
    
    /// <summary>
    /// Should apply paging if needed.
    /// </summary>
    /// <param name="query">The query.</param>
    /// <param name="input">The input.</param>
    protected virtual IQueryable<LookupEntity<TKey>> ApplyPaging(IQueryable<LookupEntity<TKey>> query, LookupRequestDto input)
    {
        //Try to use paging if available
        if (input is IPagedResultRequest pagedInput)
        {
            return query.PageBy(pagedInput);
        }

        //Try to limit query result if available
        if (input is ILimitedResultRequest limitedInput)
        {
            return query.Take(limitedInput.MaxResultCount);
        }

        //No paging
        return query;
    }
    
    protected virtual async Task<IQueryable<LookupEntity<TKey>>> GetSelectQueryable()
    {
        throw new NotImplementedException();
    }

    protected virtual IQueryable<LookupEntity<TKey>> ApplyFilter(IQueryable<LookupEntity<TKey>> query, string filterText)
    {
        return query.WhereIf(!string.IsNullOrEmpty(filterText), 
            entity => entity.DisplayName.ToLowerInvariant().Contains(filterText)
                      || entity.Id.ToString().ToLowerInvariant().Contains(filterText));
    }
}

public abstract class SelectAppService<TEntity, TKey>
    : AbstractEntitySelectAppService<TKey>
    where TEntity : class, IEntity<TKey>
{
    protected IReadOnlyRepository<TEntity, TKey> Repository { get; }

    protected SelectAppService(IReadOnlyRepository<TEntity, TKey> repository)
    {
        Repository = repository;
    }
    
    /// <summary>
    /// Override this for customize display name
    /// </summary>
    /// <returns></returns>
    protected override async Task<IQueryable<LookupEntity<TKey>>> GetSelectQueryable()
    {
        var queryAble = await Repository.GetQueryableAsync();
        Logger.LogWarning("Select by default display name show Id.");
        return queryAble.Select(a => new LookupEntity<TKey>()
            {
                Id = a.Id,
                DisplayName = a.Id.ToString()
            })
            .AsNoTracking();
    }
    
    // protected virtual IQueryable<TEntity> ApplyOrderSorting(IQueryable<TEntity> query)
    // {
    //     if (typeof(TEntity).IsAssignableTo<IHasOrder>())
    //     {
    //         return query.OrderByDescending(e => ((IHasOrder)e).DisplayOrder);
    //     }
    //
    //     return query;
    // }
    //
    // protected virtual IQueryable<LookupEntity<TKey>> ApplyOrderSorting(IQueryable<LookupEntity<TKey>> query)
    // {
    //     if (typeof(LookupEntity<TKey>).IsAssignableTo<IHasOrder>())
    //     {
    //         return query.OrderByDescending(e => ((IHasOrder)e).Order);
    //     }
    //
    //     return query;
    // }
    //
    // protected override IQueryable<TEntity> ApplyDefaultSorting(IQueryable<TEntity> query)
    // {
    //     if (typeof(TEntity).IsAssignableTo<ICreationAuditedObject>())
    //     {
    //         return query.OrderByDescending(e => ((ICreationAuditedObject)e).CreationTime);
    //     }
    //     else
    //     {
    //         return query.OrderByDescending(e => e.Id);
    //     }
    // }
}