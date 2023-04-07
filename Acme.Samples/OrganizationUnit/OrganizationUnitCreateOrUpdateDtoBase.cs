// Decompiled with JetBrains decompiler
// Type: Volo.Abp.Identity.OrganizationUnitCreateOrUpdateDtoBase
// Assembly: Volo.Abp.Identity.Pro.Application.Contracts, Version=4.4.3.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C4B9C3F-FDFA-4370-99CE-83930B0F7EFD
// Assembly location: C:\Users\user\.nuget\packages\volo.abp.identity.pro.application.contracts\4.4.3\lib\netstandard2.0\Volo.Abp.Identity.Pro.Application.Contracts.dll
// XML documentation location: C:\Users\user\.nuget\packages\volo.abp.identity.pro.application.contracts\4.4.3\lib\netstandard2.0\Volo.Abp.Identity.Pro.Application.Contracts.xml

using System.ComponentModel.DataAnnotations;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Validation;
// using VOx7WMMbK7xN2XluUo;

namespace Volo.Abp.Identity
{
    public abstract class OrganizationUnitCreateOrUpdateDtoBase : ExtensibleObject
    {
        [Required]
        [DynamicStringLength(typeof (OrganizationUnitConsts), "MaxDisplayNameLength", null)]
        public string DisplayName { get; set; }

        protected OrganizationUnitCreateOrUpdateDtoBase()
        {
            // Nvfxbjfj5Zt5ZTorHE.wt4YuNHSeVSsG();
            // ISSUE: explicit constructor call
            // base.\u002Ector(false);
        }
    }
}