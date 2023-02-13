using System;
using System.Linq;
using System.Threading.Tasks;
using Acme.Samples.Select;
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
    : AbstractKeyCustomSelectAppService<TEntity, TKey>
    where TEntity : class, IEntity<TKey>
    // where TGetOutputDto : IEntityDto<TKey>
    // where TGetListOutputDto : IEntityDto<TKey>
{
    protected IReadOnlyRepository<TEntity, TKey> Repository { get; }
    
    protected CustomSelectAppService(IReadOnlyRepository<TEntity, TKey> repository)
        : base(repository)
    {
        Repository = repository;
    }

    // protected override async Task<TEntity> GetEntityByIdAsync(TKey id)
    // {
    //     return await Repository.GetAsync(id);
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


// public class SelectTestRoleAppService : CustomSelectAppService<EntityPropertyChange, Guid>
// {
//     public SelectTestRoleAppService(IReadOnlyRepository<EntityPropertyChange, Guid> repository) : base(repository)
//     {
//     }
//
//     protected override async Task<EntityPropertyChange> GetEntityByIdAsync(Guid id)
//     {
//         throw new NotImplementedException();
//     }
//
//     protected override async Task<IQueryable<LookupEntity<Guid>>> CreateFilteredQueryAsync(LookupRequestDto input)
//     {
//         var temp = await Repository.GetQueryableAsync();
//         var queryable = temp.Select(a => new LookupEntity<Guid>()
//         {
//             Id = a.Id,
//             DisplayName = a.NewValue
//         });
//         return queryable;
//     }
// }