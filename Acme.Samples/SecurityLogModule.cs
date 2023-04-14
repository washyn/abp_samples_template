using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Localization.Resources.AbpUi;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Account.Localization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.Abp.SecurityLog;
using Volo.Abp.UI.Navigation;
using Volo.Abp.Users;

namespace Acme.Samples;

public class SecurityLogModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        // add ...
        Configure<AbpNavigationOptions>(options =>
        {
            options.MenuContributors.Add(new AccountSecurityLogUserMenuContributor());
        });
    }
}

public class AccountSecurityLogUserMenuContributor : IMenuContributor
{
    public virtual Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name != StandardMenus.User)
        {
            return Task.CompletedTask;
        }
        
        context.Menu.AddItem(new ApplicationMenuItem("Account.SecurityLogs","Intentos de iniciar sesión", url: "~/SecurityLog"));

        return Task.CompletedTask;
    }
}

[Authorize]
public class SecurityLogAppService : ApplicationService
{
    private readonly IIdentitySecurityLogRepository _securityLogRepository;
    private readonly ICurrentUser _currentUser;

    public SecurityLogAppService(IReadOnlyRepository<IdentitySecurityLog, Guid> repository,
        IIdentitySecurityLogRepository securityLogRepository,
        ICurrentUser currentUser)
    {
        _securityLogRepository = securityLogRepository;
        _currentUser = currentUser;
    }

    public async Task<PagedResultDto<IdentitySecurityLogDto>> GetListAsync(SecurityLogFilter input)
    {
        var totalCount = await _securityLogRepository.GetCountAsync(userId: _currentUser.Id);
        var items = await _securityLogRepository.GetListAsync(input.Sorting, input.MaxResultCount, input.SkipCount, userId: _currentUser.Id);
        return new PagedResultDto<IdentitySecurityLogDto>
        {
            TotalCount = totalCount,
            Items = ObjectMapper.Map<List<IdentitySecurityLog>, List<IdentitySecurityLogDto>>(items)
        };
    }
}

public class SecurityLogFilter : PagedAndSortedResultRequestDto
{
    public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (string.IsNullOrEmpty(Sorting))
        {
            Sorting = "creationTime desc";
        }
        return new List<ValidationResult>();
    }
}
// TODO: convert to module
public class SecurityLogProfile : Profile
{
    public SecurityLogProfile()
    {
        CreateMap<IdentitySecurityLog, IdentitySecurityLogDto>().ReverseMap();
    }
}

public class IdentitySecurityLogDto : EntityDto<Guid>
{
    public Guid? TenantId { get; set; }

    public string ApplicationName { get; set; }

    public string Identity { get; set; }

    public string Action { get; set; }

    public Guid? UserId { get; set; }

    public string UserName { get; set; }

    public string TenantName { get; set; }

    public string ClientId { get; set; }

    public string CorrelationId { get; set; }

    public string ClientIpAddress { get; set; }

    public string BrowserInfo { get; set; }

    public DateTime CreationTime { get; set; }
}