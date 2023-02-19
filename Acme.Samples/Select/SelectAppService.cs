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
    public string AlternativeText { get; set; }
}

public class LookupDto<TKey>
{
    public TKey Id { get; set; }
    public string DisplayName { get; set; }
    public string AlternativeText { get; set; }
}


public class LookupRequestDto : PagedResultRequestDto
{
    public string Filter { get; set; }
}

public interface IHasDisplayOrder<T>
{
    T DisplayOrder { get; set; }
}

#endregion

public interface ISelectAppService<TKey>
    : IApplicationService
{
    Task<LookupDto<TKey>> GetAsync(TKey id);

    Task<PagedResultDto<LookupDto<TKey>>> GetListAsync(LookupRequestDto input);
}


public abstract class AbstractEntitySelectAppService<TKey, TLookupEntity, TOrder>
    : ApplicationService
        , ISelectAppService<TKey>
    where TLookupEntity : LookupEntity<TKey>
{
    
    #region Publics
    public virtual async Task<LookupDto<TKey>> GetAsync(TKey id)
    {
        var entity = await GetEntityByIdAsync(id);
        return MapToGetOutputDto(entity);
    }
    public virtual async Task<PagedResultDto<LookupDto<TKey>>> GetListAsync(LookupRequestDto input)
    {
        var query = await CreateSelectQueryAsync();
        query = ApplyFilter(query, input);
        var totalCount = await AsyncExecuter.CountAsync(query);
        query = ApplySorting(query);
        query = ApplyPaging(query, input);
        var entities = await AsyncExecuter.ToListAsync(query);
        var entityDtos = await MapToGetListOutputDtosAsync(entities);
        return new PagedResultDto<LookupDto<TKey>>(totalCount, entityDtos);
    }
    
    #endregion

    #region Maps

    protected virtual LookupDto<TKey> MapToGetOutputDto(LookupEntity<TKey> entity)
    {
        return new LookupDto<TKey>()
        {
            Id = entity.Id,
            DisplayName = entity.DisplayName,
            AlternativeText = entity.AlternativeText,
        };
    }
    protected virtual async Task<List<LookupDto<TKey>>> MapToGetListOutputDtosAsync(List<TLookupEntity> entities)
    {
        return entities.Select(a => new LookupDto<TKey>()
        {
            Id = a.Id,
            DisplayName = a.DisplayName,
            AlternativeText = a.AlternativeText,
        }).ToList();
    }

    #endregion

    #region Select queriable
    
    protected virtual async Task<TLookupEntity> GetEntityByIdAsync(TKey id)
    {
        var query = await CreateSelectQueryAsync();
        return await AsyncExecuter.FirstAsync(query, entity => entity.Id.Equals(id));
    }
    
    protected virtual IQueryable<TLookupEntity> ApplyPaging(IQueryable<TLookupEntity> query, LookupRequestDto input)
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
    private IQueryable<TLookupEntity> ApplySorting(IQueryable<TLookupEntity> query)
    {
        if (typeof(TLookupEntity).IsAssignableTo<IHasDisplayOrder<TOrder>>())
        {
            return query.OrderByDescending(e => ((IHasDisplayOrder<TOrder>)e).DisplayOrder);
        }
        return query;
    }
    protected virtual IQueryable<TLookupEntity> ApplyFilter(IQueryable<TLookupEntity> query, LookupRequestDto input)
    {
        return query.WhereIf(!string.IsNullOrEmpty(input.Filter), 
            entity => entity.DisplayName.Contains(input.Filter)
                      || entity.Id.ToString().Contains(input.Filter));
    }
    protected virtual async Task<IQueryable<TLookupEntity>> CreateSelectQueryAsync()
    {
        throw new NotImplementedException();
    }
    
    #endregion
}

public abstract class AbstractEntitySelectAppService<TKey>
    : AbstractEntitySelectAppService<TKey, LookupEntity<TKey>>
{

}

public abstract class AbstractEntitySelectAppService<TKey, TLookupEntity>
    : AbstractEntitySelectAppService<TKey, TLookupEntity, TKey>
    where TLookupEntity : LookupEntity<TKey>
{

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
    /// Override this for customize display name.
    /// </summary>
    /// <returns></returns>
    protected override async Task<IQueryable<LookupEntity<TKey>>> CreateSelectQueryAsync()
    {
        var queryAble = await Repository.GetQueryableAsync();
        Logger.LogWarning("Select by default display name show Id.");
        return queryAble.Select(a => new LookupEntity<TKey>()
            {
                Id = a.Id,
                DisplayName = a.Id.ToString(),
            })
            .AsNoTracking();
    }
}