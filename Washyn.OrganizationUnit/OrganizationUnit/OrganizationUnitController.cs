// Decompiled with JetBrains decompiler
// Type: Volo.Abp.Identity.OrganizationUnitController
// Assembly: Volo.Abp.Identity.Pro.HttpApi, Version=4.4.3.0, Culture=neutral, PublicKeyToken=null
// MVID: 492F61DD-B5E9-4FDA-8D88-6399891B2CFA
// Assembly location: C:\Users\user\.nuget\packages\volo.abp.identity.pro.httpapi\4.4.3\lib\net5.0\Volo.Abp.Identity.Pro.HttpApi.dll
// XML documentation location: C:\Users\user\.nuget\packages\volo.abp.identity.pro.httpapi\4.4.3\lib\net5.0\Volo.Abp.Identity.Pro.HttpApi.xml

// using ehjejjRYAj34ViDvGj;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.AspNetCore.Mvc;

namespace Volo.Abp.Identity
{
  [Area("identity")]
  [RemoteService(true, Name = "AbpIdentity")]
  [ControllerName("OrganizationUnit")]
  [Route("api/identity/organization-units")]
  public class OrganizationUnitController : 
    AbpController,
    IOrganizationUnitAppService,
    IApplicationService,
    IRemoteService
  {
    protected IOrganizationUnitAppService OrganizationUnitAppService { get; }

    public OrganizationUnitController(
      IOrganizationUnitAppService organizationUnitAppService)
    {
      // HAX3EZUlfXotIQ9OFd.UYQRQGMwAkptG();
      // ISSUE: explicit constructor call
      // base.\u002Ector();
      this.OrganizationUnitAppService = organizationUnitAppService;
    }

    [Route("{id}/roles")]
    [HttpPut]
    public virtual Task AddRolesAsync(Guid id, OrganizationUnitRoleInput input) => this.OrganizationUnitAppService.AddRolesAsync(id, input);

    [Route("{id}/members")]
    [HttpPut]
    public virtual Task AddMembersAsync(Guid id, OrganizationUnitUserInput input) => this.OrganizationUnitAppService.AddMembersAsync(id, input);

    [HttpPost]
    public virtual Task<OrganizationUnitWithDetailsDto> CreateAsync(OrganizationUnitCreateDto input) => this.OrganizationUnitAppService.CreateAsync(input);

    [HttpDelete]
    public virtual Task DeleteAsync(Guid id) => this.OrganizationUnitAppService.DeleteAsync(id);

    [Route("{id}")]
    [HttpGet]
    public virtual Task<OrganizationUnitWithDetailsDto> GetAsync(Guid id) => this.OrganizationUnitAppService.GetAsync(id);

    [HttpGet]
    public virtual Task<PagedResultDto<OrganizationUnitWithDetailsDto>> GetListAsync(
      GetOrganizationUnitInput input)
    {
      return this.OrganizationUnitAppService.GetListAsync(input);
    }

    [HttpGet]
    [Route("all")]
    public virtual Task<ListResultDto<OrganizationUnitWithDetailsDto>> GetListAllAsync() => this.OrganizationUnitAppService.GetListAllAsync();

    [HttpGet]
    [Route("{id}/roles")]
    public virtual Task<PagedResultDto<IdentityRoleDto>> GetRolesAsync(
      Guid id,
      PagedAndSortedResultRequestDto input)
    {
      return this.OrganizationUnitAppService.GetRolesAsync(id, input);
    }

    [Route("{id}/members")]
    [HttpGet]
    public virtual Task<PagedResultDto<IdentityUserDto>> GetMembersAsync(
      Guid id,
      GetIdentityUsersInput input)
    {
      return this.OrganizationUnitAppService.GetMembersAsync(id, input);
    }

    [Route("{id}/move")]
    [HttpPut]
    public virtual Task MoveAsync(Guid id, OrganizationUnitMoveInput input) => this.OrganizationUnitAppService.MoveAsync(id, input);

    [Route("available-users")]
    [HttpGet]
    public Task<PagedResultDto<IdentityUserDto>> GetAvailableUsersAsync(GetAvailableUsersInput input) => this.OrganizationUnitAppService.GetAvailableUsersAsync(input);

    [Route("available-roles")]
    [HttpGet]
    public Task<PagedResultDto<IdentityRoleDto>> GetAvailableRolesAsync(GetAvailableRolesInput input) => this.OrganizationUnitAppService.GetAvailableRolesAsync(input);

    [HttpPut]
    [Route("{id}")]
    public virtual Task<OrganizationUnitWithDetailsDto> UpdateAsync(
      Guid id,
      OrganizationUnitUpdateDto input)
    {
      return this.OrganizationUnitAppService.UpdateAsync(id, input);
    }

    [Route("{id}/members/{memberId}")]
    [HttpDelete]
    public virtual Task RemoveMemberAsync(Guid id, Guid memberId) => this.OrganizationUnitAppService.RemoveMemberAsync(id, memberId);

    [HttpDelete]
    [Route("{id}/roles/{roleId}")]
    public virtual Task RemoveRoleAsync(Guid id, Guid roleId) => this.OrganizationUnitAppService.RemoveRoleAsync(id, roleId);
  }
}
