using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Validation;

namespace Acme.Samples;

[Authorize("AbpIdentity.OrganizationUnits")]
public class OrganizationUnitAppService :
    ApplicationService,
    IOrganizationUnitAppService
{
    protected OrganizationUnitManager OrganizationUnitManager { get; }
    protected IdentityUserManager UserManager { get; }
    protected IOrganizationUnitRepository OrganizationUnitRepository { get; }
    protected IIdentityUserRepository IdentityUserRepository { get; }
    protected IIdentityRoleRepository IdentityRoleRepository { get; }

    public OrganizationUnitAppService(
        OrganizationUnitManager organizationUnitManager,
        IdentityUserManager userManager,
        IOrganizationUnitRepository organizationUnitRepository,
        IIdentityUserRepository identityUserRepository,
        IIdentityRoleRepository identityRoleRepository)
    {
        this.OrganizationUnitManager = organizationUnitManager;
        this.UserManager = userManager;
        this.OrganizationUnitRepository = organizationUnitRepository;
        this.IdentityUserRepository = identityUserRepository;
        this.IdentityRoleRepository = identityRoleRepository;
    }

    #region Methods
    //
    // public virtual async Task<OrganizationUnitWithDetailsDto> GetAsync(Guid id) => await this.lgH3bLtgov(await this.OrganizationUnitRepository.GetAsync(id, true, new CancellationToken()).ConfigureAwait(false)).ConfigureAwait(false);
    //
    // public virtual async Task<PagedResultDto<OrganizationUnitWithDetailsDto>> GetListAsync(
    //     GetOrganizationUnitInput input)
    // {
    //     List<OrganizationUnit> organizationUnits = await this.OrganizationUnitRepository.GetListAsync(input.Sorting, input.MaxResultCount, input.SkipCount, true).ConfigureAwait(false);
    //     Dictionary<Guid, IdentityRole> roleLookup = await this.vQI351Uli3((IEnumerable<OrganizationUnit>) organizationUnits).ConfigureAwait(false);
    //     List<OrganizationUnitWithDetailsDto> ouDtos = new List<OrganizationUnitWithDetailsDto>();
    //     foreach (OrganizationUnit organizationUnit in organizationUnits)
    //     {
    //         List<OrganizationUnitWithDetailsDto> unitWithDetailsDtoList = ouDtos;
    //         unitWithDetailsDtoList.Add(await this.lO43vlOWvt(organizationUnit, roleLookup).ConfigureAwait(false));
    //         unitWithDetailsDtoList = (List<OrganizationUnitWithDetailsDto>) null;
    //     }
    //     PagedResultDto<OrganizationUnitWithDetailsDto> listAsync = new PagedResultDto<OrganizationUnitWithDetailsDto>(await this.OrganizationUnitRepository.GetCountAsync().ConfigureAwait(false), (IReadOnlyList<OrganizationUnitWithDetailsDto>) ouDtos);
    //     organizationUnits = (List<OrganizationUnit>) null;
    //     roleLookup = (Dictionary<Guid, IdentityRole>) null;
    //     ouDtos = (List<OrganizationUnitWithDetailsDto>) null;
    //     return listAsync;
    // }
    //
    // public virtual async Task<ListResultDto<OrganizationUnitWithDetailsDto>> GetListAllAsync()
    // {
    //     List<OrganizationUnit> organizationUnits = await this.OrganizationUnitRepository.GetListAsync((string) null, int.MaxValue, 0, true, new CancellationToken()).ConfigureAwait(false);
    //     Dictionary<Guid, IdentityRole> roleLookup = await this.vQI351Uli3((IEnumerable<OrganizationUnit>) organizationUnits).ConfigureAwait(false);
    //     List<OrganizationUnitWithDetailsDto> ouDtos = new List<OrganizationUnitWithDetailsDto>();
    //     foreach (OrganizationUnit organizationUnit in organizationUnits)
    //     {
    //         List<OrganizationUnitWithDetailsDto> unitWithDetailsDtoList = ouDtos;
    //         unitWithDetailsDtoList.Add(await this.lO43vlOWvt(organizationUnit, roleLookup).ConfigureAwait(false));
    //         unitWithDetailsDtoList = (List<OrganizationUnitWithDetailsDto>) null;
    //     }
    //     ListResultDto<OrganizationUnitWithDetailsDto> listAllAsync = new ListResultDto<OrganizationUnitWithDetailsDto>((IReadOnlyList<OrganizationUnitWithDetailsDto>) ouDtos);
    //     organizationUnits = (List<OrganizationUnit>) null;
    //     roleLookup = (Dictionary<Guid, IdentityRole>) null;
    //     ouDtos = (List<OrganizationUnitWithDetailsDto>) null;
    //     return listAllAsync;
    // }
    //
    // public virtual async Task<PagedResultDto<IdentityRoleDto>> GetRolesAsync(
    //     Guid id,
    //     PagedAndSortedResultRequestDto input)
    // {
    //     OrganizationUnitAppService organizationUnitAppService = this;
    //     OrganizationUnit ou = await organizationUnitAppService.OrganizationUnitRepository.GetAsync(id, true, new CancellationToken()).ConfigureAwait(false);
    //     List<IdentityRole> roles = await organizationUnitAppService.OrganizationUnitRepository.GetRolesAsync(ou, input.Sorting, input.MaxResultCount, input.SkipCount).ConfigureAwait(false);
    //     int num = await organizationUnitAppService.OrganizationUnitRepository.GetRolesCountAsync(ou).ConfigureAwait(false);
    //     PagedResultDto<IdentityRoleDto> pagedResultDto = new PagedResultDto<IdentityRoleDto>();
    //     pagedResultDto.Items = (IReadOnlyList<IdentityRoleDto>) organizationUnitAppService.ObjectMapper.Map<List<IdentityRole>, List<IdentityRoleDto>>(roles);
    //     pagedResultDto.TotalCount = (long) num;
    //     PagedResultDto<IdentityRoleDto> rolesAsync = pagedResultDto;
    //     ou = (OrganizationUnit) null;
    //     roles = (List<IdentityRole>) null;
    //     return rolesAsync;
    // }
    //
    // public virtual async Task<PagedResultDto<IdentityUserDto>> GetMembersAsync(
    //     Guid id,
    //     GetIdentityUsersInput input)
    // {
    //     OrganizationUnitAppService organizationUnitAppService = this;
    //     OrganizationUnit ou = await organizationUnitAppService.OrganizationUnitRepository.GetAsync(id, true, new CancellationToken()).ConfigureAwait(false);
    //     int count = await organizationUnitAppService.OrganizationUnitRepository.GetMembersCountAsync(ou, input.Filter).ConfigureAwait(false);
    //     List<IdentityUser> source = await organizationUnitAppService.OrganizationUnitRepository.GetMembersAsync(ou, input.Sorting, input.MaxResultCount, input.SkipCount, input.Filter).ConfigureAwait(false);
    //     PagedResultDto<IdentityUserDto> pagedResultDto = new PagedResultDto<IdentityUserDto>();
    //     pagedResultDto.Items = (IReadOnlyList<IdentityUserDto>) organizationUnitAppService.ObjectMapper.Map<List<IdentityUser>, List<IdentityUserDto>>(source);
    //     pagedResultDto.TotalCount = (long) count;
    //     PagedResultDto<IdentityUserDto> membersAsync = pagedResultDto;
    //     ou = (OrganizationUnit) null;
    //     return membersAsync;
    // }
    //
    // [Authorize("AbpIdentity.OrganizationUnits.ManageOU")]
    // public virtual async Task<OrganizationUnitWithDetailsDto> CreateAsync(
    //     OrganizationUnitCreateDto input)
    // {
    //     OrganizationUnitAppService organizationUnitAppService = this;
    //     OrganizationUnit organizationUnit = new OrganizationUnit(organizationUnitAppService.GuidGenerator.Create(), input.DisplayName, input.ParentId, organizationUnitAppService.CurrentTenant.Id);
    //     input.MapExtraPropertiesTo<OrganizationUnitCreateDto, OrganizationUnit>(organizationUnit);
    //     await organizationUnitAppService.OrganizationUnitManager.CreateAsync(organizationUnit).ConfigureAwait(false);
    //     OrganizationUnitWithDetailsDto async = await organizationUnitAppService.lgH3bLtgov(organizationUnit).ConfigureAwait(false);
    //     organizationUnit = (OrganizationUnit) null;
    //     return async;
    // }
    //
    // [Authorize("AbpIdentity.OrganizationUnits.ManageOU")]
    // public virtual async Task DeleteAsync(Guid id)
    // {
    //     if (await this.OrganizationUnitRepository.FindAsync(id).ConfigureAwait(false) == null)
    //         return;
    //     await this.OrganizationUnitManager.DeleteAsync(id).ConfigureAwait(false);
    // }
    //
    // [Authorize("AbpIdentity.OrganizationUnits.ManageOU")]
    // public virtual async Task<OrganizationUnitWithDetailsDto> UpdateAsync(
    //     Guid id,
    //     OrganizationUnitUpdateDto input)
    // {
    //     OrganizationUnitAppService organizationUnitAppService = this;
    //     OrganizationUnit organizationUnit = await organizationUnitAppService.OrganizationUnitRepository.GetAsync(id, true, new CancellationToken()).ConfigureAwait(false);
    //     organizationUnit.DisplayName = input.DisplayName;
    //     input.MapExtraPropertiesTo<OrganizationUnitUpdateDto, OrganizationUnit>(organizationUnit);
    //     await organizationUnitAppService.OrganizationUnitManager.UpdateAsync(organizationUnit).ConfigureAwait(false);
    //     await organizationUnitAppService.CurrentUnitOfWork.SaveChangesAsync().ConfigureAwait(false);
    //     OrganizationUnitWithDetailsDto unitWithDetailsDto = await organizationUnitAppService.lgH3bLtgov(organizationUnit).ConfigureAwait(false);
    //     organizationUnit = (OrganizationUnit) null;
    //     return unitWithDetailsDto;
    // }
    //
    // [Authorize("AbpIdentity.OrganizationUnits.ManageRoles")]
    // public virtual async Task AddRolesAsync(Guid id, OrganizationUnitRoleInput input)
    // {
    //     foreach (Guid roleId in input.RoleIds)
    //         await this.OrganizationUnitManager.AddRoleToOrganizationUnitAsync(roleId, id).ConfigureAwait(false);
    // }
    //
    // [Authorize("AbpIdentity.OrganizationUnits.ManageMembers")]
    // public virtual async Task AddMembersAsync(Guid id, OrganizationUnitUserInput input)
    // {
    //     foreach (Guid userId in input.UserIds)
    //         await this.UserManager.AddToOrganizationUnitAsync(userId, id).ConfigureAwait(false);
    // }
    //
    // [Authorize("AbpIdentity.OrganizationUnits.ManageOU")]
    // public virtual async Task MoveAsync(Guid id, OrganizationUnitMoveInput input) => await this.OrganizationUnitManager.MoveAsync(id, input.NewParentId).ConfigureAwait(false);
    //
    // [Authorize("AbpIdentity.OrganizationUnits.ManageMembers")]
    // public virtual async Task RemoveMemberAsync(Guid id, Guid memberId) => await this.UserManager.RemoveFromOrganizationUnitAsync(memberId, id).ConfigureAwait(false);
    //
    // [Authorize("AbpIdentity.OrganizationUnits.ManageRoles")]
    // public virtual async Task RemoveRoleAsync(Guid id, Guid roleId) => await this.OrganizationUnitManager.RemoveRoleFromOrganizationUnitAsync(roleId, id).ConfigureAwait(false);
    //
    // public virtual async Task<PagedResultDto<IdentityUserDto>> GetAvailableUsersAsync(
    //     GetAvailableUsersInput input)
    // {
    //     OrganizationUnitAppService organizationUnitAppService = this;
    //     OrganizationUnit ou = await organizationUnitAppService.OrganizationUnitRepository.GetAsync(input.Id, true, new CancellationToken()).ConfigureAwait(false);
    //     int count = await organizationUnitAppService.OrganizationUnitRepository.GetUnaddedUsersCountAsync(ou, input.Filter).ConfigureAwait(false);
    //     List<IdentityUser> source = await organizationUnitAppService.OrganizationUnitRepository.GetUnaddedUsersAsync(ou, input.Sorting, input.MaxResultCount, input.SkipCount, input.Filter).ConfigureAwait(false);
    //     PagedResultDto<IdentityUserDto> pagedResultDto = new PagedResultDto<IdentityUserDto>();
    //     pagedResultDto.Items = (IReadOnlyList<IdentityUserDto>) organizationUnitAppService.ObjectMapper.Map<List<IdentityUser>, List<IdentityUserDto>>(source);
    //     pagedResultDto.TotalCount = (long) count;
    //     PagedResultDto<IdentityUserDto> availableUsersAsync = pagedResultDto;
    //     ou = (OrganizationUnit) null;
    //     return availableUsersAsync;
    // }
    //
    // public virtual async Task<PagedResultDto<IdentityRoleDto>> GetAvailableRolesAsync(
    //     GetAvailableRolesInput input)
    // {
    //     OrganizationUnitAppService organizationUnitAppService = this;
    //     OrganizationUnit ou = await organizationUnitAppService.OrganizationUnitRepository.GetAsync(input.Id, true, new CancellationToken()).ConfigureAwait(false);
    //     int count = await organizationUnitAppService.OrganizationUnitRepository.GetUnaddedRolesCountAsync(ou, input.Filter).ConfigureAwait(false);
    //     List<IdentityRole> source = await organizationUnitAppService.OrganizationUnitRepository.GetUnaddedRolesAsync(ou, input.Sorting, input.MaxResultCount, input.SkipCount, input.Filter).ConfigureAwait(false);
    //     PagedResultDto<IdentityRoleDto> pagedResultDto = new PagedResultDto<IdentityRoleDto>();
    //     pagedResultDto.Items = (IReadOnlyList<IdentityRoleDto>) organizationUnitAppService.ObjectMapper.Map<List<IdentityRole>, List<IdentityRoleDto>>(source);
    //     pagedResultDto.TotalCount = (long) count;
    //     PagedResultDto<IdentityRoleDto> availableRolesAsync = pagedResultDto;
    //     ou = (OrganizationUnit) null;
    //     return availableRolesAsync;
    // }
    //
    // private async Task<OrganizationUnitWithDetailsDto> lgH3bLtgov(OrganizationUnit _param1)
    // {
    //     OrganizationUnitAppService organizationUnitAppService = this;
    //     OrganizationUnit organizationUnit = _param1;
    //     Dictionary<Guid, IdentityRole> dictionary = await organizationUnitAppService.vQI351Uli3((IEnumerable<OrganizationUnit>) new OrganizationUnit[1]
    //     {
    //         _param1
    //     }).ConfigureAwait(false);
    //     OrganizationUnitWithDetailsDto unitWithDetailsDto = await organizationUnitAppService.lO43vlOWvt(organizationUnit, dictionary).ConfigureAwait(false);
    //     organizationUnit = (OrganizationUnit) null;
    //     return unitWithDetailsDto;
    // }
    //
    // private async Task<OrganizationUnitWithDetailsDto> lO43vlOWvt(
    //     OrganizationUnit _param1,
    //     Dictionary<Guid, IdentityRole> _param2)
    // {
    //     OrganizationUnitAppService organizationUnitAppService = this;
    //     OrganizationUnitWithDetailsDto result = organizationUnitAppService.ObjectMapper.Map<OrganizationUnit, OrganizationUnitWithDetailsDto>(_param1);
    //     result.Roles = new List<IdentityRoleDto>();
    //     foreach (OrganizationUnitRole role in (IEnumerable<OrganizationUnitRole>) _param1.Roles)
    //     {
    //         IdentityRole orDefault = _param2.GetOrDefault<Guid, IdentityRole>(role.RoleId);
    //         if (orDefault != null)
    //             result.Roles.Add(organizationUnitAppService.ObjectMapper.Map<IdentityRole, IdentityRoleDto>(orDefault));
    //     }
    //     return await Task.FromResult<OrganizationUnitWithDetailsDto>(result).ConfigureAwait(false);
    // }
    //
    // private async Task<Dictionary<Guid, IdentityRole>> vQI351Uli3(
    //     IEnumerable<OrganizationUnit> _param1)
    // {
    //     return (await this.IdentityRoleRepository.GetListAsync((IEnumerable<Guid>) _param1.SelectMany<OrganizationUnit, OrganizationUnitRole>((Func<OrganizationUnit, IEnumerable<OrganizationUnitRole>>) (q => (IEnumerable<OrganizationUnitRole>) q.Roles)).Select<OrganizationUnitRole, Guid>((Func<OrganizationUnitRole, Guid>) (t => t.RoleId)).Distinct<Guid>().ToArray<Guid>()).ConfigureAwait(false)).ToDictionary<IdentityRole, Guid, IdentityRole>((Func<IdentityRole, Guid>) (u => u.Id), (Func<IdentityRole, IdentityRole>) (u => u));
    // }

    #endregion

    public Task<OrganizationUnitWithDetailsDto> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<PagedResultDto<OrganizationUnitWithDetailsDto>> GetListAsync(GetOrganizationUnitInput input)
    {
        throw new NotImplementedException();
    }

    public Task<ListResultDto<OrganizationUnitWithDetailsDto>> GetListAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<PagedResultDto<IdentityUserDto>> GetMembersAsync(Guid id, GetIdentityUsersInput input)
    {
        throw new NotImplementedException();
    }

    public Task RemoveMemberAsync(Guid id, Guid memberId)
    {
        throw new NotImplementedException();
    }

    public Task<PagedResultDto<IdentityRoleDto>> GetRolesAsync(Guid id, PagedAndSortedResultRequestDto input)
    {
        throw new NotImplementedException();
    }

    public Task RemoveRoleAsync(Guid id, Guid roleId)
    {
        throw new NotImplementedException();
    }
    
    public Task<OrganizationUnitWithDetailsDto> CreateAsync(OrganizationUnitCreateDto input)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<OrganizationUnitWithDetailsDto> UpdateAsync(Guid id, OrganizationUnitUpdateDto input)
    {
        throw new NotImplementedException();
    }

    public Task AddRolesAsync(Guid id, OrganizationUnitRoleInput input)
    {
        throw new NotImplementedException();
    }

    public Task AddMembersAsync(Guid id, OrganizationUnitUserInput input)
    {
        throw new NotImplementedException();
    }

    public Task MoveAsync(Guid id, OrganizationUnitMoveInput input)
    {
        throw new NotImplementedException();
    }

    public Task<PagedResultDto<IdentityUserDto>> GetAvailableUsersAsync(GetAvailableUsersInput input)
    {
        throw new NotImplementedException();
    }

    public Task<PagedResultDto<IdentityRoleDto>> GetAvailableRolesAsync(GetAvailableRolesInput input)
    {
        throw new NotImplementedException();
    }
}

public interface IOrganizationUnitAppService : IApplicationService
{
    Task<OrganizationUnitWithDetailsDto> GetAsync(Guid id);

    Task<PagedResultDto<OrganizationUnitWithDetailsDto>> GetListAsync(GetOrganizationUnitInput input);

    Task<ListResultDto<OrganizationUnitWithDetailsDto>> GetListAllAsync();

    Task<PagedResultDto<IdentityUserDto>> GetMembersAsync(Guid id, GetIdentityUsersInput input);

    Task RemoveMemberAsync(Guid id, Guid memberId);

    Task<PagedResultDto<IdentityRoleDto>> GetRolesAsync(
        Guid id,
        PagedAndSortedResultRequestDto input);

    Task RemoveRoleAsync(Guid id, Guid roleId);

    Task<OrganizationUnitWithDetailsDto> CreateAsync(OrganizationUnitCreateDto input);

    Task DeleteAsync(Guid id);

    Task<OrganizationUnitWithDetailsDto> UpdateAsync(Guid id, OrganizationUnitUpdateDto input);

    Task AddRolesAsync(Guid id, OrganizationUnitRoleInput input);

    Task AddMembersAsync(Guid id, OrganizationUnitUserInput input);

    Task MoveAsync(Guid id, OrganizationUnitMoveInput input);

    Task<PagedResultDto<IdentityUserDto>> GetAvailableUsersAsync(GetAvailableUsersInput input);

    Task<PagedResultDto<IdentityRoleDto>> GetAvailableRolesAsync(GetAvailableRolesInput input);
}


#region Dtos

public class GetAvailableRolesInput: PagedAndSortedResultRequestDto
{
    public string Filter { get; set; }

    public Guid Id { get; set; }
}

public class GetAvailableUsersInput: PagedAndSortedResultRequestDto
{
    public string Filter { get; set; }

    public Guid Id { get; set; }
}

public class OrganizationUnitMoveInput
{
    public Guid? NewParentId { get; set; }
}

public class OrganizationUnitUserInput
{
    public List<Guid> UserIds { get; set; }
}

public class OrganizationUnitRoleInput
{
    public List<Guid> RoleIds { get; set; }
}

public class OrganizationUnitUpdateDto: OrganizationUnitCreateOrUpdateDtoBase
{
}

public abstract class OrganizationUnitCreateOrUpdateDtoBase : ExtensibleObject
{
    [Required]
    [DynamicStringLength(typeof (OrganizationUnitConsts), "MaxDisplayNameLength", null)]
    public string DisplayName { get; set; }
}

public class OrganizationUnitCreateDto: OrganizationUnitCreateOrUpdateDtoBase
{
    public Guid? ParentId { get; set; }
}

public class GetOrganizationUnitInput: PagedAndSortedResultRequestDto
{
    public string Filter { get; set; }
}

public class OrganizationUnitWithDetailsDto: ExtensibleFullAuditedEntityDto<Guid>
{
    public Guid? ParentId { get; set; }

    public string Code { get; set; }

    public string DisplayName { get; set; }

    public List<IdentityRoleDto> Roles { get; set; }
}

#endregion

public class OrganizationUnitModule : AbpModule
{
    
}