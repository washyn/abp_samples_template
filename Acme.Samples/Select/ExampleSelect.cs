using Volo.Abp.Application.Services;
using Volo.Abp.Auditing;
using Volo.Abp.AuditLogging;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

namespace Acme.Samples.Select;

[DisableAuditing]
public class AuditLogSelectAppService : SelectAppService<AuditLog, Guid>
    , IAuditLogSelectAppService
{
    public AuditLogSelectAppService(IReadOnlyRepository<AuditLog, Guid> repository) : base(repository)
    {
    }

    protected override async Task<IQueryable<LookupEntity<Guid>>> GetSelectQueryable()
    {
        var temp = await Repository.GetQueryableAsync();
        return temp.Select(a => new LookupEntity<Guid>()
        {
            Id = a.Id,
            DisplayName = a.Url
        });
    }
}

public interface IAuditLogSelectAppService : ISelectAppService<Guid>
{
}

public class UserSelectAppService : SelectAppService<IdentityUser, Guid>
{
    public UserSelectAppService(IReadOnlyRepository<IdentityUser, Guid> repository) : base(repository)
    {
    }

    protected override async Task<IQueryable<LookupEntity<Guid>>> GetSelectQueryable()
    {
        var queryable = await Repository.GetQueryableAsync();
        return queryable.Select(a => new LookupEntity<Guid>()
        {
            Id = a.Id,
            DisplayName = a.Name + ' ' + a.Email
        });
    }
}