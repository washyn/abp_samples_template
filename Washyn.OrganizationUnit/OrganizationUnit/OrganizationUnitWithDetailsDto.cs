// Decompiled with JetBrains decompiler
// Type: Volo.Abp.Identity.OrganizationUnitWithDetailsDto
// Assembly: Volo.Abp.Identity.Pro.Application.Contracts, Version=4.4.3.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C4B9C3F-FDFA-4370-99CE-83930B0F7EFD
// Assembly location: C:\Users\user\.nuget\packages\volo.abp.identity.pro.application.contracts\4.4.3\lib\netstandard2.0\Volo.Abp.Identity.Pro.Application.Contracts.dll
// XML documentation location: C:\Users\user\.nuget\packages\volo.abp.identity.pro.application.contracts\4.4.3\lib\netstandard2.0\Volo.Abp.Identity.Pro.Application.Contracts.xml

using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;
// using VOx7WMMbK7xN2XluUo;

namespace Volo.Abp.Identity
{
    public class OrganizationUnitWithDetailsDto : ExtensibleFullAuditedEntityDto<Guid>
    {
        public Guid? ParentId { get; set; }

        public string Code { get; set; }

        public string DisplayName { get; set; }

        public List<IdentityRoleDto> Roles { get; set; }

        public OrganizationUnitWithDetailsDto()
        {
            // Nvfxbjfj5Zt5ZTorHE.wt4YuNHSeVSsG();
            // ISSUE: explicit constructor call
            // base.\u002Ector();
        }
    }
}