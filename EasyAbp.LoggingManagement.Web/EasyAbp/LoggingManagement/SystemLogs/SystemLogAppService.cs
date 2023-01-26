using System.Threading.Tasks;
using EasyAbp.LoggingManagement.Permissions;
using EasyAbp.LoggingManagement.SystemLogs.Dtos;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.AuditLogging;

namespace EasyAbp.LoggingManagement.SystemLogs
{
    [Authorize(LoggingManagementPermissions.SystemLog.Default)]
    public class SystemLogAppService : ApplicationService, ISystemLogAppService
    {
        private readonly IAspNetCoreLogProvider _aspNetCoreLogProvider;
        private readonly IAuditLogRepository _repository;

        public SystemLogAppService(IAspNetCoreLogProvider aspNetCoreLogProvider, IAuditLogRepository repository)
        {
            _aspNetCoreLogProvider = aspNetCoreLogProvider;
            _repository = repository;
        }
        
        public virtual async Task<PagedResultDto<SystemLogDto>> GetListAsync(GetSystemLogListInput input)
        {
            var count = await _repository.GetCountAsync();
            var data = await _repository.GetListAsync();
            
            return new PagedResultDto<SystemLogDto>()
            {
                TotalCount = count,
                Items = ObjectMapper.Map<List<AuditLog>, List<SystemLogDto>>(data)
            };
            // return await _aspNetCoreLogProvider.GetListAsync(input.QueryString, input.StartTime, input.EndTime,
            //     input.MaxResultCount, input.SkipCount);
        }
    }
}