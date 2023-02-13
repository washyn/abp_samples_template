using System.Threading.Tasks;
using Acme.Samples.Select;
using Volo.Abp.Application.Dtos;

namespace Volo.Abp.Application.Services;

#region Original code

public interface IReadOnlyAppService<TEntityDto, in TKey>
    : IReadOnlyAppService<TEntityDto, TEntityDto, TKey, PagedAndSortedResultRequestDto>
{

}

public interface IReadOnlyAppService<TEntityDto, in TKey, in TGetListInput>
    : IReadOnlyAppService<TEntityDto, TEntityDto, TKey, TGetListInput>
{

}

public interface IReadOnlyAppService<TGetOutputDto, TGetListOutputDto, in TKey, in TGetListInput>
    : IApplicationService
{
    Task<TGetOutputDto> GetAsync(TKey id);

    Task<PagedResultDto<TGetListOutputDto>> GetListAsync(TGetListInput input);
}


#endregion





// public interface ISelectAppService<TEntityDto, in TKey>
//     : ISelectAppService<TEntityDto, TEntityDto, TKey, PagedAndSortedResultRequestDto>
// {
//
// }
//
// public interface ISelectAppService<TEntityDto, in TKey, in TGetListInput>
//     : ISelectAppService<TEntityDto, TEntityDto, TKey, TGetListInput>
// {
//
// }

public interface ISelectAppService<TGetOutputDto, TGetListOutputDto, in TKey, in TGetListInput>
    : IApplicationService
{
    Task<TGetOutputDto> GetAsync(TKey id);

    Task<PagedResultDto<TGetListOutputDto>> GetListAsync(TGetListInput input);
}

// por default TKey es in en el tempalte se removio porque da error...
public interface ICustomSelectAppService<TKey>
    : IApplicationService
{
    Task<LookupEntity<TKey>> GetAsync(TKey id);

    Task<PagedResultDto<LookupEntity<TKey>>> GetListAsync(LookupRequestDto input);
}

//
// public async Task<PagedResultDto<LookupEntity<Guid>>> GetListAsync(LookupRequestDto input)
// {
//     var count = await _repo.GetCountSelectListAsync(input.Filter);
//     var data = await _repo.GetPagedSelectListAsync(input.Filter, input.SkipCount, input.MaxResultCount);
//     return new PagedResultDto<LookupEntity<Guid>>(count, data);
// }
//
// public Task<LookupEntity<Guid>> GetAsync(Guid id)