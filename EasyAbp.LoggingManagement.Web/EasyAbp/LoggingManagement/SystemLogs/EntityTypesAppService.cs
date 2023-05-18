using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.AspNetCore.Mvc;

namespace EasyAbp.LoggingManagement.Web.EasyAbp.LoggingManagement.SystemLogs;
public interface IEntityTypesAppService : IApplicationService
{
    Task<ListResultDto<EntityDto>> GetListAsync(EntityTypeFilterDto input);
    // Task<EntityDto> GetAsync(string id); // add if use easy select
}

public class EntityTypesAppService : ApplicationService, IEntityTypesAppService
{
    private readonly IEntityChangeRepository _repository;

    public EntityTypesAppService(IEntityChangeRepository repository)
    {
        _repository = repository;
    }

    public async Task<ListResultDto<EntityDto>> GetListAsync(EntityTypeFilterDto input)
    {
        var temp = await _repository.GetQueryableAsync();
        var res = await temp.GroupBy(a => a.EntityTypeFullName)
            .Select(a => new EntityDto()
            {
                Name = a.Key
            })
            .WhereIf(!string.IsNullOrEmpty(input.Filter), dto => dto.Name.Contains(input.Filter))
            .ToListAsync();
        return new ListResultDto<EntityDto>()
        {
            Items = res
        };
    }
}

[RemoteService(Name = LoggingManagementRemoteServiceConsts.RemoteServiceName)]
[Route("/api/logging-management/entity-type")]
public class EntityTypeController: AbpController, IEntityTypesAppService
{
    private readonly IEntityTypesAppService _service;

    public EntityTypeController(IEntityTypesAppService service)
    {
        _service = service;
    }
    
    [HttpGet]
    public Task<ListResultDto<EntityDto>> GetListAsync(EntityTypeFilterDto input)
    {
        return _service.GetListAsync(input);
    }
}

public class EntityTypeFilterDto : PagedAndSortedResultRequestDto
{
    public string Filter { get; set; }
}

public class EntityDto
{
    public string Name { get; set; }
}