// Decompiled with JetBrains decompiler
// Type: Volo.Abp.Identity.IdentityPermissions
// Assembly: Volo.Abp.Identity.Pro.Application.Contracts, Version=4.4.3.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C4B9C3F-FDFA-4370-99CE-83930B0F7EFD
// Assembly location: C:\Users\user\.nuget\packages\volo.abp.identity.pro.application.contracts\4.4.3\lib\netstandard2.0\Volo.Abp.Identity.Pro.Application.Contracts.dll
// XML documentation location: C:\Users\user\.nuget\packages\volo.abp.identity.pro.application.contracts\4.4.3\lib\netstandard2.0\Volo.Abp.Identity.Pro.Application.Contracts.xml

using Volo.Abp.Reflection;

namespace Volo.Abp.Identity
{
  public static class IdentityPermissions
  {
    public const string GroupName = "AbpIdentity";
    public const string SettingManagement = "AbpIdentity.SettingManagement";

    public static string[] GetAll() => ReflectionHelper.GetPublicConstantsRecursively(typeof (IdentityPermissions));

    public static class Roles
    {
      public const string Default = "AbpIdentity.Roles";
      public const string Create = "AbpIdentity.Roles.Create";
      public const string Update = "AbpIdentity.Roles.Update";
      public const string Delete = "AbpIdentity.Roles.Delete";
      public const string ManagePermissions = "AbpIdentity.Roles.ManagePermissions";
      public const string ViewChangeHistory = "AuditLogging.ViewChangeHistory:Volo.Abp.Identity.IdentityRole";
    }

    public static class Users
    {
      public const string Default = "AbpIdentity.Users";
      public const string Create = "AbpIdentity.Users.Create";
      public const string Update = "AbpIdentity.Users.Update";
      public const string Delete = "AbpIdentity.Users.Delete";
      public const string ManagePermissions = "AbpIdentity.Users.ManagePermissions";
      public const string ViewChangeHistory = "AuditLogging.ViewChangeHistory:Volo.Abp.Identity.IdentityUser";
    }

    public static class ClaimTypes
    {
      public const string Default = "AbpIdentity.ClaimTypes";
      public const string Create = "AbpIdentity.ClaimTypes.Create";
      public const string Update = "AbpIdentity.ClaimTypes.Update";
      public const string Delete = "AbpIdentity.ClaimTypes.Delete";
    }

    public static class UserLookup
    {
      public const string Default = "AbpIdentity.UserLookup";
    }

    public static class OrganizationUnits
    {
      public const string Default = "AbpIdentity.OrganizationUnits";
      public const string ManageOU = "AbpIdentity.OrganizationUnits.ManageOU";
      public const string ManageRoles = "AbpIdentity.OrganizationUnits.ManageRoles";
      public const string ManageUsers = "AbpIdentity.OrganizationUnits.ManageMembers";
    }

    public static class SecurityLogs
    {
      public const string Default = "AbpIdentity.SecurityLogs";
    }
  }
}
