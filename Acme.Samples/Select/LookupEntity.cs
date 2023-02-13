using Volo.Abp.Application.Dtos;
namespace Volo.Abp.Application.Services;

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
public interface IHasOrder
{
    int Order { get; }
}