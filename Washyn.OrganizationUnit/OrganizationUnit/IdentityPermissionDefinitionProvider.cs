// Decompiled with JetBrains decompiler
// Type: Volo.Abp.Identity.IdentityPermissionDefinitionProvider
// Assembly: Volo.Abp.Identity.Pro.Application.Contracts, Version=4.4.3.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C4B9C3F-FDFA-4370-99CE-83930B0F7EFD
// Assembly location: C:\Users\user\.nuget\packages\volo.abp.identity.pro.application.contracts\4.4.3\lib\netstandard2.0\Volo.Abp.Identity.Pro.Application.Contracts.dll
// XML documentation location: C:\Users\user\.nuget\packages\volo.abp.identity.pro.application.contracts\4.4.3\lib\netstandard2.0\Volo.Abp.Identity.Pro.Application.Contracts.xml

// using afkUfRYrbrZh4id17P;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Identity.Localization;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Identity;
// using VOx7WMMbK7xN2XluUo;

namespace Volo.Abp.Identity
{
  public class IdentityPermissionDefinitionProvider : PermissionDefinitionProvider
  {
    public override void Define(IPermissionDefinitionContext context)
    {
      var group = context.GetGroupOrNull(IdentityPermissions.GroupName);
      if (group != null)
      {
        var permisionDefinition = group.AddPermission(IdentityPermissions.OrganizationUnits.Default);
        permisionDefinition.AddChild(IdentityPermissions.OrganizationUnits.ManageOU);
        permisionDefinition.AddChild(IdentityPermissions.OrganizationUnits.ManageRoles);
        permisionDefinition.AddChild(IdentityPermissions.OrganizationUnits.ManageUsers);
      }
      // PermissionGroupDefinition permissionGroupDefinition = context.AddGroup(Gl25B4WjEWtG1dbKxj.sEBWxCGA2W(248), (ILocalizableString) IdentityPermissionDefinitionProvider.Qto4LltAS(Gl25B4WjEWtG1dbKxj.sEBWxCGA2W(274)));
      // PermissionDefinition permissionDefinition1 = permissionGroupDefinition.AddPermission(Gl25B4WjEWtG1dbKxj.sEBWxCGA2W(336), (ILocalizableString) IdentityPermissionDefinitionProvider.Qto4LltAS(Gl25B4WjEWtG1dbKxj.sEBWxCGA2W(374)));
      // permissionDefinition1.AddChild(Gl25B4WjEWtG1dbKxj.sEBWxCGA2W(428), (ILocalizableString) IdentityPermissionDefinitionProvider.Qto4LltAS(Gl25B4WjEWtG1dbKxj.sEBWxCGA2W(480)));
      // permissionDefinition1.AddChild(Gl25B4WjEWtG1dbKxj.sEBWxCGA2W(518), (ILocalizableString) IdentityPermissionDefinitionProvider.Qto4LltAS(Gl25B4WjEWtG1dbKxj.sEBWxCGA2W(570)));
      // permissionDefinition1.AddChild(Gl25B4WjEWtG1dbKxj.sEBWxCGA2W(604), (ILocalizableString) IdentityPermissionDefinitionProvider.Qto4LltAS(Gl25B4WjEWtG1dbKxj.sEBWxCGA2W(656)));
      // permissionDefinition1.AddChild(Gl25B4WjEWtG1dbKxj.sEBWxCGA2W(694), (ILocalizableString) IdentityPermissionDefinitionProvider.Qto4LltAS(Gl25B4WjEWtG1dbKxj.sEBWxCGA2W(768)));
      // permissionDefinition1.AddChild(Gl25B4WjEWtG1dbKxj.sEBWxCGA2W(828), (ILocalizableString) IdentityPermissionDefinitionProvider.Qto4LltAS(Gl25B4WjEWtG1dbKxj.sEBWxCGA2W(954)));
      // PermissionDefinition permissionDefinition2 = permissionGroupDefinition.AddPermission(Gl25B4WjEWtG1dbKxj.sEBWxCGA2W(1014), (ILocalizableString) IdentityPermissionDefinitionProvider.Qto4LltAS(Gl25B4WjEWtG1dbKxj.sEBWxCGA2W(1052)));
      // permissionDefinition2.AddChild(Gl25B4WjEWtG1dbKxj.sEBWxCGA2W(1106), (ILocalizableString) IdentityPermissionDefinitionProvider.Qto4LltAS(Gl25B4WjEWtG1dbKxj.sEBWxCGA2W(480)));
      // permissionDefinition2.AddChild(Gl25B4WjEWtG1dbKxj.sEBWxCGA2W(1158), (ILocalizableString) IdentityPermissionDefinitionProvider.Qto4LltAS(Gl25B4WjEWtG1dbKxj.sEBWxCGA2W(570)));
      // permissionDefinition2.AddChild(Gl25B4WjEWtG1dbKxj.sEBWxCGA2W(1210), (ILocalizableString) IdentityPermissionDefinitionProvider.Qto4LltAS(Gl25B4WjEWtG1dbKxj.sEBWxCGA2W(656)));
      // permissionDefinition2.AddChild(Gl25B4WjEWtG1dbKxj.sEBWxCGA2W(1262), (ILocalizableString) IdentityPermissionDefinitionProvider.Qto4LltAS(Gl25B4WjEWtG1dbKxj.sEBWxCGA2W(768)));
      // permissionDefinition2.AddChild(Gl25B4WjEWtG1dbKxj.sEBWxCGA2W(1336), (ILocalizableString) IdentityPermissionDefinitionProvider.Qto4LltAS(Gl25B4WjEWtG1dbKxj.sEBWxCGA2W(954)));
      // PermissionDefinition permissionDefinition3 = permissionGroupDefinition.AddPermission(Gl25B4WjEWtG1dbKxj.sEBWxCGA2W(1462), (ILocalizableString) IdentityPermissionDefinitionProvider.Qto4LltAS(Gl25B4WjEWtG1dbKxj.sEBWxCGA2W(1524)));
      // permissionDefinition3.AddChild(Gl25B4WjEWtG1dbKxj.sEBWxCGA2W(1602), (ILocalizableString) IdentityPermissionDefinitionProvider.Qto4LltAS(Gl25B4WjEWtG1dbKxj.sEBWxCGA2W(1682)));
      // permissionDefinition3.AddChild(Gl25B4WjEWtG1dbKxj.sEBWxCGA2W(1724), (ILocalizableString) IdentityPermissionDefinitionProvider.Qto4LltAS(Gl25B4WjEWtG1dbKxj.sEBWxCGA2W(1810)));
      // permissionDefinition3.AddChild(Gl25B4WjEWtG1dbKxj.sEBWxCGA2W(1858), (ILocalizableString) IdentityPermissionDefinitionProvider.Qto4LltAS(Gl25B4WjEWtG1dbKxj.sEBWxCGA2W(1948)));
      // PermissionDefinition permissionDefinition4 = permissionGroupDefinition.AddPermission(Gl25B4WjEWtG1dbKxj.sEBWxCGA2W(1996), (ILocalizableString) IdentityPermissionDefinitionProvider.Qto4LltAS(Gl25B4WjEWtG1dbKxj.sEBWxCGA2W(2044)), MultiTenancySides.Host);
      // permissionDefinition4.AddChild(Gl25B4WjEWtG1dbKxj.sEBWxCGA2W(2100), (ILocalizableString) IdentityPermissionDefinitionProvider.Qto4LltAS(Gl25B4WjEWtG1dbKxj.sEBWxCGA2W(480)), MultiTenancySides.Host);
      // permissionDefinition4.AddChild(Gl25B4WjEWtG1dbKxj.sEBWxCGA2W(2162), (ILocalizableString) IdentityPermissionDefinitionProvider.Qto4LltAS(Gl25B4WjEWtG1dbKxj.sEBWxCGA2W(570)), MultiTenancySides.Host);
      // permissionDefinition4.AddChild(Gl25B4WjEWtG1dbKxj.sEBWxCGA2W(2224), (ILocalizableString) IdentityPermissionDefinitionProvider.Qto4LltAS(Gl25B4WjEWtG1dbKxj.sEBWxCGA2W(656)), MultiTenancySides.Host);
      // permissionGroupDefinition.AddPermission(Gl25B4WjEWtG1dbKxj.sEBWxCGA2W(2286), (ILocalizableString) IdentityPermissionDefinitionProvider.Qto4LltAS(Gl25B4WjEWtG1dbKxj.sEBWxCGA2W(2348)));
      // permissionGroupDefinition.AddPermission(Gl25B4WjEWtG1dbKxj.sEBWxCGA2W(2408), (ILocalizableString) IdentityPermissionDefinitionProvider.Qto4LltAS(Gl25B4WjEWtG1dbKxj.sEBWxCGA2W(2456))).WithProviders(Gl25B4WjEWtG1dbKxj.sEBWxCGA2W(2502));
      // permissionGroupDefinition.AddPermission(Gl25B4WjEWtG1dbKxj.sEBWxCGA2W(2508), (ILocalizableString) IdentityPermissionDefinitionProvider.Qto4LltAS(Gl25B4WjEWtG1dbKxj.sEBWxCGA2W(2560)));
    }

    // private static LocalizableString Qto4LltAS(string _param0) => LocalizableString.Create<IdentityResource>(_param0);

    public IdentityPermissionDefinitionProvider()
    {
      // Nvfxbjfj5Zt5ZTorHE.wt4YuNHSeVSsG();
      // ISSUE: explicit constructor call
      // base.\u002Ector();
    }
  }
}
