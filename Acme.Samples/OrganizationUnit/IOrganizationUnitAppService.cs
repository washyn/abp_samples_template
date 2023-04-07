// Decompiled with JetBrains decompiler
// Type: Volo.Abp.Identity.IOrganizationUnitAppService
// Assembly: Volo.Abp.Identity.Pro.Application.Contracts, Version=4.4.3.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C4B9C3F-FDFA-4370-99CE-83930B0F7EFD
// Assembly location: C:\Users\user\.nuget\packages\volo.abp.identity.pro.application.contracts\4.4.3\lib\netstandard2.0\Volo.Abp.Identity.Pro.Application.Contracts.dll
// XML documentation location: C:\Users\user\.nuget\packages\volo.abp.identity.pro.application.contracts\4.4.3\lib\netstandard2.0\Volo.Abp.Identity.Pro.Application.Contracts.xml

using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Volo.Abp.Identity
{
  public interface IOrganizationUnitAppService : IApplicationService, IRemoteService
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
}
