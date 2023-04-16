using System.Threading.Tasks;
using Localization.Resources.AbpUi;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace Volo.Abp.Identity
{
    public class AbpOuWebMainMenuContributor : IMenuContributor
    {
        public virtual Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name != StandardMenus.Main)
            {
                return Task.CompletedTask;
            }
        
            var l = context.GetLocalizer<AbpUiResource>();

            var menuItem = new ApplicationMenuItem(IdentityMenuNames.OrganizationUnits, l["Organization Units"], url: "~/Identity/OrganizationUnits").RequirePermissions(IdentityPermissions.OrganizationUnits.Default);
            var adminMenu = context.Menu.GetAdministration();
            if (adminMenu != null)
            {
                var item = adminMenu.GetMenuItemOrNull(IdentityMenuNames.GroupName);
                if (item != null)
                {
                    item.AddItem(menuItem);
                }
            }

            return Task.CompletedTask;
        }
    }
    public class IdentityMenuNames
    {
        public const string GroupName = "AbpIdentity";

        public const string OrganizationUnits = GroupName + ".OrganizationUnits";
    }
}