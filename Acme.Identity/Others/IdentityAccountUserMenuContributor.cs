using Acme.Identity.Pages.Components.UserLoginLink;
using Localization.Resources.AbpUi;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Toolbars;
using Volo.Abp.UI.Navigation;
using Volo.Abp.Users;

namespace Acme.Identity.Others
{
    public class IdentityAccountUserMenuContributor : IMenuContributor
    {
        public virtual Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name != StandardMenus.User)
            {
                return Task.CompletedTask;
            }
            var uiResource = context.GetLocalizer<AbpUiResource>();
            context.Menu.AddItem(new ApplicationMenuItem("Account.Logout", uiResource["Logout"], url: "~/Logout", icon: "fa fa-power-off", order: int.MaxValue - 1000));
            return Task.CompletedTask;
        }
    }
    
    public class AccountLoginToolbarContributor : IToolbarContributor
    {
        public virtual Task ConfigureToolbarAsync(IToolbarConfigurationContext context)
        {
            if (context.Toolbar.Name != StandardToolbars.Main)
            {
                return Task.CompletedTask;
            }
    
            if (!context.ServiceProvider.GetRequiredService<ICurrentUser>().IsAuthenticated)
            {
                context.Toolbar.Items.Add(new ToolbarItem(typeof(UserLoginLinkViewComponent)));
            }
    
            return Task.CompletedTask;
        }
    }
}