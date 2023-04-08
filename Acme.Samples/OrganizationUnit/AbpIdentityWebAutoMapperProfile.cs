// Decompiled with JetBrains decompiler
// Type: Volo.Abp.Identity.Web.AbpIdentityWebAutoMapperProfile
// Assembly: Volo.Abp.Identity.Pro.Web, Version=4.4.3.0, Culture=neutral, PublicKeyToken=null
// MVID: E4C41AA3-0174-4C66-B88B-B6CE4068FD3E
// Assembly location: C:\Users\user\.nuget\packages\volo.abp.identity.pro.web\4.4.3\lib\net5.0\Volo.Abp.Identity.Pro.Web.dll
// XML documentation location: C:\Users\user\.nuget\packages\volo.abp.identity.pro.web\4.4.3\lib\net5.0\Volo.Abp.Identity.Pro.Web.xml

using AutoMapper;
// using fVCJkJkQwaNY4RUNnZ;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Volo.Abp.AutoMapper;
using Volo.Abp.Identity.Web.Pages.Identity.Users;
using Volo.Abp.Identity.Web;

namespace Volo.Abp.Identity.Web
{
  public class AbpIdentityWebAutoMapperProfile : Profile
  {
    public AbpIdentityWebAutoMapperProfile()
    {
      // fbWsbJn1PdrYD0ZTul.tc9fB3genUu3t();
      // ISSUE: explicit constructor call
      // base.\u002Ector();
      // this.CreateUserMappings();
      // this.CreateRoleMappings();
      // this.CreateClaimTypeMappings();
      this.CreateOrganizationUnitMappings();
    }

    // protected virtual void CreateUserMappings()
    // {
    //   this.CreateMap<IdentityUserDto, Volo.Abp.Identity.Web.Pages.Identity.Users.EditModalModel.UserInfoViewModel>().MapExtraProperties<IdentityUserDto, Volo.Abp.Identity.Web.Pages.Identity.Users.EditModalModel.UserInfoViewModel>();
    //   this.CreateMap<Volo.Abp.Identity.Web.Pages.Identity.Users.CreateModalModel.UserInfoViewModel, IdentityUserCreateDto>().MapExtraProperties<Volo.Abp.Identity.Web.Pages.Identity.Users.CreateModalModel.UserInfoViewModel, IdentityUserCreateDto>().Ignore<Volo.Abp.Identity.Web.Pages.Identity.Users.CreateModalModel.UserInfoViewModel, IdentityUserCreateDto, string[]>((Expression<Func<IdentityUserCreateDto, string[]>>) (identityUserCreateDto => identityUserCreateDto.RoleNames)).Ignore<Volo.Abp.Identity.Web.Pages.Identity.Users.CreateModalModel.UserInfoViewModel, IdentityUserCreateDto, Guid[]>((Expression<Func<IdentityUserCreateDto, Guid[]>>) (identityUserCreateDto => identityUserCreateDto.OrganizationUnitIds));
    //   this.CreateMap<IdentityRoleDto, Volo.Abp.Identity.Web.Pages.Identity.Users.CreateModalModel.AssignedRoleViewModel>().Ignore<IdentityRoleDto, Volo.Abp.Identity.Web.Pages.Identity.Users.CreateModalModel.AssignedRoleViewModel, bool>((Expression<Func<Volo.Abp.Identity.Web.Pages.Identity.Users.CreateModalModel.AssignedRoleViewModel, bool>>) (assignedRoleViewModel => assignedRoleViewModel.IsAssigned));
    //   this.CreateMap<OrganizationUnitWithDetailsDto, IdentityUserModalPageModel.AssignedOrganizationUnitViewModel>().Ignore<OrganizationUnitWithDetailsDto, IdentityUserModalPageModel.AssignedOrganizationUnitViewModel, bool>((Expression<Func<IdentityUserModalPageModel.AssignedOrganizationUnitViewModel, bool>>) (organizationUnitViewModel => organizationUnitViewModel.IsAssigned));
    //   this.CreateMap<Volo.Abp.Identity.Web.Pages.Identity.Users.EditModalModel.UserInfoViewModel, IdentityUserUpdateDto>().MapExtraProperties<Volo.Abp.Identity.Web.Pages.Identity.Users.EditModalModel.UserInfoViewModel, IdentityUserUpdateDto>().Ignore<Volo.Abp.Identity.Web.Pages.Identity.Users.EditModalModel.UserInfoViewModel, IdentityUserUpdateDto, string[]>((Expression<Func<IdentityUserUpdateDto, string[]>>) (identityUserUpdateDto => identityUserUpdateDto.RoleNames)).Ignore<Volo.Abp.Identity.Web.Pages.Identity.Users.EditModalModel.UserInfoViewModel, IdentityUserUpdateDto, Guid[]>((Expression<Func<IdentityUserUpdateDto, Guid[]>>) (identityUserUpdateDto => identityUserUpdateDto.OrganizationUnitIds));
    //   this.CreateMap<IdentityRoleDto, Volo.Abp.Identity.Web.Pages.Identity.Users.EditModalModel.AssignedRoleViewModel>().Ignore<IdentityRoleDto, Volo.Abp.Identity.Web.Pages.Identity.Users.EditModalModel.AssignedRoleViewModel, bool>((Expression<Func<Volo.Abp.Identity.Web.Pages.Identity.Users.EditModalModel.AssignedRoleViewModel, bool>>) (assignedRoleViewModel => assignedRoleViewModel.IsAssigned)).Ignore<IdentityRoleDto, Volo.Abp.Identity.Web.Pages.Identity.Users.EditModalModel.AssignedRoleViewModel, bool>((Expression<Func<Volo.Abp.Identity.Web.Pages.Identity.Users.EditModalModel.AssignedRoleViewModel, bool>>) (assignedRoleViewModel => assignedRoleViewModel.IsInheritedFromOu));
    // }
    //
    // protected virtual void CreateClaimTypeMappings()
    // {
    //   this.CreateMap<ClaimTypeDto, Volo.Abp.Identity.Web.Pages.Identity.ClaimTypes.EditModalModel.ClaimTypeInfoModel>().MapExtraProperties<ClaimTypeDto, Volo.Abp.Identity.Web.Pages.Identity.ClaimTypes.EditModalModel.ClaimTypeInfoModel>();
    //   this.CreateMap<ClaimTypeDto, Volo.Abp.Identity.Web.Pages.Identity.Users.ClaimTypeEditModalModel.ClaimsViewModel>().Ignore<ClaimTypeDto, Volo.Abp.Identity.Web.Pages.Identity.Users.ClaimTypeEditModalModel.ClaimsViewModel, List<string>>((Expression<Func<Volo.Abp.Identity.Web.Pages.Identity.Users.ClaimTypeEditModalModel.ClaimsViewModel, List<string>>>) (claimsViewModel => claimsViewModel.Value));
    //   this.CreateMap<ClaimTypeDto, Volo.Abp.Identity.Web.Pages.Identity.Roles.ClaimTypeEditModalModel.ClaimsViewModel>().Ignore<ClaimTypeDto, Volo.Abp.Identity.Web.Pages.Identity.Roles.ClaimTypeEditModalModel.ClaimsViewModel, List<string>>((Expression<Func<Volo.Abp.Identity.Web.Pages.Identity.Roles.ClaimTypeEditModalModel.ClaimsViewModel, List<string>>>) (claimsViewModel => claimsViewModel.Value));
    //   this.CreateMap<Volo.Abp.Identity.Web.Pages.Identity.ClaimTypes.EditModalModel.ClaimTypeInfoModel, UpdateClaimTypeDto>().MapExtraProperties<Volo.Abp.Identity.Web.Pages.Identity.ClaimTypes.EditModalModel.ClaimTypeInfoModel, UpdateClaimTypeDto>();
    //   this.CreateMap<Volo.Abp.Identity.Web.Pages.Identity.ClaimTypes.CreateModalModel.ClaimTypeInfoModel, CreateClaimTypeDto>().MapExtraProperties<Volo.Abp.Identity.Web.Pages.Identity.ClaimTypes.CreateModalModel.ClaimTypeInfoModel, CreateClaimTypeDto>();
    // }
    //
    // protected virtual void CreateRoleMappings()
    // {
    //   this.CreateMap<IdentityRoleDto, Volo.Abp.Identity.Web.Pages.Identity.Roles.EditModalModel.RoleInfoModel>().MapExtraProperties<IdentityRoleDto, Volo.Abp.Identity.Web.Pages.Identity.Roles.EditModalModel.RoleInfoModel>();
    //   this.CreateMap<Volo.Abp.Identity.Web.Pages.Identity.Roles.CreateModalModel.RoleInfoModel, IdentityRoleCreateDto>().MapExtraProperties<Volo.Abp.Identity.Web.Pages.Identity.Roles.CreateModalModel.RoleInfoModel, IdentityRoleCreateDto>();
    //   this.CreateMap<Volo.Abp.Identity.Web.Pages.Identity.Roles.EditModalModel.RoleInfoModel, IdentityRoleUpdateDto>().MapExtraProperties<Volo.Abp.Identity.Web.Pages.Identity.Roles.EditModalModel.RoleInfoModel, IdentityRoleUpdateDto>();
    // }
    //
    // protected virtual void CreateOrganizationUnitMappings()
    // {
    //   this.CreateMap<Volo.Abp.Identity.Web.Pages.Identity.OrganizationUnits.CreateModalModel.OrganizationUnitInfoModel, OrganizationUnitCreateDto>().MapExtraProperties<Volo.Abp.Identity.Web.Pages.Identity.OrganizationUnits.CreateModalModel.OrganizationUnitInfoModel, OrganizationUnitCreateDto>();
    //   this.CreateMap<OrganizationUnitWithDetailsDto, Volo.Abp.Identity.Web.Pages.Identity.OrganizationUnits.EditModalModel.OrganizationUnitInfoModel>();
    //   this.CreateMap<Volo.Abp.Identity.Web.Pages.Identity.OrganizationUnits.EditModalModel.OrganizationUnitInfoModel, OrganizationUnitUpdateDto>().MapExtraProperties<Volo.Abp.Identity.Web.Pages.Identity.OrganizationUnits.EditModalModel.OrganizationUnitInfoModel, OrganizationUnitUpdateDto>();
    // }
    //
    protected virtual void CreateOrganizationUnitMappings()
    {
      this.CreateMap<Acme.Samples.Pages.Identity.OrganizationUnits.CreateModal.OrganizationUnitInfoModel, OrganizationUnitCreateDto>().MapExtraProperties<Acme.Samples.Pages.Identity.OrganizationUnits.CreateModal.OrganizationUnitInfoModel, OrganizationUnitCreateDto>();
      this.CreateMap<OrganizationUnitWithDetailsDto, Acme.Samples.Pages.Identity.OrganizationUnits.EditModal.OrganizationUnitInfoModel>();
      this.CreateMap<Acme.Samples.Pages.Identity.OrganizationUnits.EditModal.OrganizationUnitInfoModel, OrganizationUnitUpdateDto>().MapExtraProperties<Acme.Samples.Pages.Identity.OrganizationUnits.EditModal.OrganizationUnitInfoModel, OrganizationUnitUpdateDto>();
    }
  }
}
