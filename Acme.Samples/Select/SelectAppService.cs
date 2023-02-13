using System;
using System.Linq;
using System.Threading.Tasks;
using Acme.Samples.Select;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.AuditLogging;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

namespace Volo.Abp.Application.Services;

// public abstract class ReadOnlyAppService<TEntity, TEntityDto, TKey>
//     : ReadOnlyAppService<TEntity, TEntityDto, TEntityDto, TKey, PagedAndSortedResultRequestDto>
//     where TEntity : class, IEntity<TKey>
//     where TEntityDto : IEntityDto<TKey>
// {
//     protected ReadOnlyAppService(IReadOnlyRepository<TEntity, TKey> repository)
//         : base(repository)
//     {
//
//     }
// }
//
// public abstract class ReadOnlyAppService<TEntity, TEntityDto, TKey, TGetListInput>
//     : ReadOnlyAppService<TEntity, TEntityDto, TEntityDto, TKey, TGetListInput>
//     where TEntity : class, IEntity<TKey>
//     where TEntityDto : IEntityDto<TKey>
// {
//     protected ReadOnlyAppService(IReadOnlyRepository<TEntity, TKey> repository)
//         : base(repository)
//     {
//
//     }
// }

#region Original code

public abstract class ReadOnlyAppService<TEntity, TGetOutputDto, TGetListOutputDto, TKey, TGetListInput>
    : AbstractKeyReadOnlyAppService<TEntity, TGetOutputDto, TGetListOutputDto, TKey, TGetListInput>
    where TEntity : class, IEntity<TKey>
    where TGetOutputDto : IEntityDto<TKey>
    where TGetListOutputDto : IEntityDto<TKey>
{
    protected IReadOnlyRepository<TEntity, TKey> Repository { get; }

    protected ReadOnlyAppService(IReadOnlyRepository<TEntity, TKey> repository)
        : base(repository)
    {
        Repository = repository;
    }

    protected override async Task<TEntity> GetEntityByIdAsync(TKey id)
    {
        return await Repository.GetAsync(id);
    }

    protected override IQueryable<TEntity> ApplyDefaultSorting(IQueryable<TEntity> query)
    {
        if (typeof(TEntity).IsAssignableTo<ICreationAuditedObject>())
        {
            return query.OrderByDescending(e => ((ICreationAuditedObject)e).CreationTime);
        }
        else
        {
            return query.OrderByDescending(e => e.Id);
        }
    }
}

#endregion

// ninguno de los metodos que contiene esta clase sirve.
public abstract class SelectAppService<TEntity, TGetOutputDto, TGetListOutputDto, TKey, TGetListInput>
    : AbstractKeyReadOnlyAppService<TEntity, TGetOutputDto, TGetListOutputDto, TKey, TGetListInput>
    where TEntity : class, IEntity<TKey>
    where TGetOutputDto : IEntityDto<TKey>
    where TGetListOutputDto : IEntityDto<TKey>
{
    protected IReadOnlyRepository<TEntity, TKey> Repository { get; }

    protected SelectAppService(IReadOnlyRepository<TEntity, TKey> repository)
        : base(repository)
    {
        Repository = repository;
    }

    protected override async Task<TEntity> GetEntityByIdAsync(TKey id)
    {
        return await Repository.GetAsync(id);
    }

    protected override IQueryable<TEntity> ApplyDefaultSorting(IQueryable<TEntity> query)
    {
        if (typeof(TEntity).IsAssignableTo<ICreationAuditedObject>())
        {
            return query.OrderByDescending(e => ((ICreationAuditedObject)e).CreationTime);
        }
        else
        {
            return query.OrderByDescending(e => e.Id);
        }
    }
}




public abstract class CustomSelectAppService<TEntity, TKey>
    // : AbstractKeyCustomSelectAppService<TEntity, TKey>
    : ApplicationService
    , ICustomSelectAppService<TKey>
    where TEntity : class, IEntity<TKey>
{
    protected IReadOnlyRepository<TEntity, TKey> Repository { get; }
    
    protected CustomSelectAppService(IReadOnlyRepository<TEntity, TKey> repository)
    {
        Repository = repository;
    }

    public virtual async Task<LookupEntity<TKey>> GetAsync(TKey id)
    {
        throw new NotImplementedException();
        // var entity = await GetEntityByIdAsync(id);
        // return await MapToGetOutputDtoAsync(entity);
        // var query = await GetSelectQueryable();
        // return await GetSelectItemAsync(id);
    }
    
    public virtual async Task<LookupEntity<TKey>> GetSelectItemAsync(TKey id)
    {
        var query = await GetSelectQueryable();
        // return await query.FirstAsync(a => a.Id.Equals(id));
        // AsyncExecuter.FirstAsync()
        // return await query.Where(a => a.Id.Equals(id)).FirstAsync();
        var res = await AsyncExecuter.FirstAsync(query, entity => entity.Id.Equals(id));
        return res;
    }
    
    public virtual async Task<PagedResultDto<LookupEntity<TKey>>> GetListAsync(LookupRequestDto input)
    {
        var query = ApplyFilter(await GetSelectQueryable(), input.Filter);
        var totalCount = await AsyncExecuter.CountAsync(query);
        query = ApplyPaging(query, input);
        var entities = await AsyncExecuter.ToListAsync(query);
        return new PagedResultDto<LookupEntity<TKey>>(totalCount, entities);
    }
    
    protected async Task<TEntity> GetEntityByIdAsync(TKey id)
    {
        return await Repository.GetAsync(id);
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

    public virtual async Task<IQueryable<LookupEntity<TKey>>> GetSelectQueryable()
    {
        var queryAble = await Repository.GetQueryableAsync();
        return queryAble.Select(a => new LookupEntity<TKey>()
        {
            Id = a.Id,
            DisplayName = a.Id.ToString()
        }).AsNoTracking();
    }
    
    public virtual IQueryable<LookupEntity<TKey>> ApplyFilter(IQueryable<LookupEntity<TKey>> query, string filterText)
    {
        return query.WhereIf(!string.IsNullOrEmpty(filterText), entity => entity.DisplayName.Contains(filterText));
    }
    
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

#region Examples
public class CustomSelectEntityChange : CustomSelectAppService<EntityPropertyChange, Guid>, ICustomSelectEntityChange
{
    public CustomSelectEntityChange(IReadOnlyRepository<EntityPropertyChange, Guid> repository) : base(repository)
    {
    }
    // esto se deberia implementar si se quiere customizar el display name
    public override async Task<IQueryable<LookupEntity<Guid>>> GetSelectQueryable()
    {
        var temp = await Repository.GetQueryableAsync();
        return temp.Select(a => new LookupEntity<Guid>()
        {
            Id = a.Id,
            DisplayName = a.NewValue
        });
    }
}

public interface ICustomSelectEntityChange : ICustomSelectAppService<Guid>
{
}
#endregion