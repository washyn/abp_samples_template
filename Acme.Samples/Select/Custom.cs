using Volo.Abp.Application.Dtos;

namespace Acme.Samples.Select;


public class LookupEntity<TKey>
{
    public TKey Id { get; set; }
    public string DisplayName { get; set; }
}

public class LookupRequestDto : PagedResultRequestDto
{
    public string Filter { get; set; }
}