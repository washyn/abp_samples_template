using Acme.Identity.Others;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.UI.Navigation;

namespace Acme.Identity
{
    public class IdentityAppMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
        }
        
        private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            var currentUser = context.ServiceProvider.GetRequiredService<IExtraPropCurrentUser>();
            if (currentUser.IsAdmin())
            {
                context.Menu.AddItem(new ApplicationMenuItem("MENU", "Usuarios", "/Users"));
            }
        }
    }
}