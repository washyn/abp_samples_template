using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.Samples.Select;
// por default TKey es in en el tempalte se removio porque da error...
public interface ICustomSelectAppService<TKey>
    : IApplicationService
{
    Task<LookupEntity<TKey>> GetAsync(TKey id);

    Task<PagedResultDto<LookupEntity<TKey>>> GetListAsync(LookupRequestDto input);
}