// Decompiled with JetBrains decompiler
// Type: Volo.Abp.Identity.AbpIdentityApplicationModuleAutoMapperProfile
// Assembly: Volo.Abp.Identity.Pro.Application, Version=4.4.3.0, Culture=neutral, PublicKeyToken=null
// MVID: 694E6915-024D-4A0E-B473-9A0886C7ED47
// Assembly location: C:\Users\user\.nuget\packages\volo.abp.identity.pro.application\4.4.3\lib\netstandard2.0\Volo.Abp.Identity.Pro.Application.dll
// XML documentation location: C:\Users\user\.nuget\packages\volo.abp.identity.pro.application\4.4.3\lib\netstandard2.0\Volo.Abp.Identity.Pro.Application.xml

using AutoMapper;
using EGadPK1ol4gX3WNAr3;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Volo.Abp.AutoMapper;

namespace Volo.Abp.Identity
{
  public class AbpIdentityApplicationModuleAutoMapperProfile : Profile
  {
    public AbpIdentityApplicationModuleAutoMapperProfile()
    {
      Fxv2nITsk1hSWPF0up.KROIQ43VbLYVb();
      // ISSUE: explicit constructor call
      base.\u002Ector();
      this.CreateMap<IdentityUser, IdentityUserDto>().MapExtraProperties<IdentityUser, IdentityUserDto>().Ignore<IdentityUser, IdentityUserDto, bool>((Expression<Func<IdentityUserDto, bool>>) (identityUserDto => identityUserDto.IsLockedOut)).Ignore<IdentityUser, IdentityUserDto, bool>((Expression<Func<IdentityUserDto, bool>>) (identityUserDto => identityUserDto.SupportTwoFactor));
      this.CreateMap<IdentityRole, IdentityRoleDto>().MapExtraProperties<IdentityRole, IdentityRoleDto>();
      this.CreateMap<IdentityClaimType, ClaimTypeDto>().MapExtraProperties<IdentityClaimType, ClaimTypeDto>().Ignore<IdentityClaimType, ClaimTypeDto, string>((Expression<Func<ClaimTypeDto, string>>) (claimTypeDto => claimTypeDto.ValueTypeAsString));
      this.CreateMap<IdentityUserClaim, IdentityUserClaimDto>();
      this.CreateMap<IdentityUserClaimDto, IdentityUserClaim>().Ignore<IdentityUserClaimDto, IdentityUserClaim, Guid?>((Expression<Func<IdentityUserClaim, Guid?>>) (identityUserClaim => identityUserClaim.TenantId)).Ignore<IdentityUserClaimDto, IdentityUserClaim, Guid>((Expression<Func<IdentityUserClaim, Guid>>) (identityUserClaim => identityUserClaim.Id));
      this.CreateMap<IdentityRoleClaim, IdentityRoleClaimDto>();
      this.CreateMap<IdentityRoleClaimDto, IdentityRoleClaim>().Ignore<IdentityRoleClaimDto, IdentityRoleClaim, Guid?>((Expression<Func<IdentityRoleClaim, Guid?>>) (identityRoleClaim => identityRoleClaim.TenantId)).Ignore<IdentityRoleClaimDto, IdentityRoleClaim, Guid>((Expression<Func<IdentityRoleClaim, Guid>>) (identityRoleClaim => identityRoleClaim.Id));
      this.CreateMap<CreateClaimTypeDto, IdentityClaimType>().MapExtraProperties<CreateClaimTypeDto, IdentityClaimType>().Ignore<CreateClaimTypeDto, IdentityClaimType, bool>((Expression<Func<IdentityClaimType, bool>>) (identityClaimType => identityClaimType.IsStatic)).Ignore<CreateClaimTypeDto, IdentityClaimType, Guid>((Expression<Func<IdentityClaimType, Guid>>) (identityClaimType => identityClaimType.Id));
      this.CreateMap<UpdateClaimTypeDto, IdentityClaimType>().MapExtraProperties<UpdateClaimTypeDto, IdentityClaimType>().Ignore<UpdateClaimTypeDto, IdentityClaimType, bool>((Expression<Func<IdentityClaimType, bool>>) (identityClaimType => identityClaimType.IsStatic)).Ignore<UpdateClaimTypeDto, IdentityClaimType, Guid>((Expression<Func<IdentityClaimType, Guid>>) (identityClaimType => identityClaimType.Id));
      this.CreateMap<IdentityUser, ProfileDto>().ForMember<bool>((Expression<Func<ProfileDto, bool>>) (profileDto => profileDto.HasPassword), (Action<IMemberConfigurationExpression<IdentityUser, ProfileDto, bool>>) (op => op.MapFrom<bool>((Expression<Func<IdentityUser, bool>>) (identityUser => identityUser.PasswordHash != default (string))))).MapExtraProperties<IdentityUser, ProfileDto>();
      this.CreateMap<OrganizationUnit, OrganizationUnitDto>().MapExtraProperties<OrganizationUnit, OrganizationUnitDto>();
      this.CreateMap<OrganizationUnitRole, OrganizationUnitRoleDto>();
      this.CreateMap<OrganizationUnit, OrganizationUnitWithDetailsDto>().MapExtraProperties<OrganizationUnit, OrganizationUnitWithDetailsDto>().Ignore<OrganizationUnit, OrganizationUnitWithDetailsDto, List<IdentityRoleDto>>((Expression<Func<OrganizationUnitWithDetailsDto, List<IdentityRoleDto>>>) (unitWithDetailsDto => unitWithDetailsDto.Roles));
      this.CreateMap<IdentityRole, OrganizationUnitRoleDto>().ForMember<Guid>((Expression<Func<OrganizationUnitRoleDto, Guid>>) (organizationUnitRoleDto => organizationUnitRoleDto.RoleId), (Action<IMemberConfigurationExpression<IdentityRole, OrganizationUnitRoleDto, Guid>>) (src => src.MapFrom<Guid>((Expression<Func<IdentityRole, Guid>>) (identityRole => identityRole.Id))));
      this.CreateMap<IdentitySecurityLog, IdentitySecurityLogDto>();
    }
  }
}
