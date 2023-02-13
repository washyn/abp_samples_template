﻿using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Auditing;
using Volo.Abp.AuditLogging;
using Volo.Abp.Domain.Repositories;

namespace Acme.Samples.Select;

[RemoteService(isEnabled: false)]
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

[Route("api/app/audit-log-select")]
public class AuditLogSelectController : AbpController, IAuditLogSelectAppService
{
    private readonly IAuditLogSelectAppService _appService;

    public AuditLogSelectController(IAuditLogSelectAppService appService)
    {
        _appService = appService;
    }
    [Route("{id}")]
    [HttpGet]
    public async Task<LookupEntity<Guid>> GetAsync(Guid id)
    {
        return await _appService.GetAsync(id);
    }

    [HttpGet]
    public async Task<PagedResultDto<LookupEntity<Guid>>> GetListAsync(LookupRequestDto input)
    {
        return await _appService.GetListAsync(input);
    }
}