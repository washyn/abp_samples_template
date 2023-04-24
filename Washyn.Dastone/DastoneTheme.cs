using Volo.Abp.AspNetCore.Mvc.UI.Theming;
using Volo.Abp.DependencyInjection;

namespace Washyn.Dastone;

[ThemeName(Name)]
public class DastoneTheme : ITheme, ITransientDependency
{
    public const string Name = "Dastone";

    public virtual string GetLayout(string name, bool fallbackToDefault = true)
    {
        switch (name)
        {
            case StandardLayouts.Application:
                return "~/Themes/Dastone/Layouts/App.cshtml";
            case StandardLayouts.Account:
                return "~/Themes/Dastone/Layouts/Auth.cshtml";
            case StandardLayouts.Empty:
                return "~/Themes/Dastone/Layouts/Empty.cshtml";
            default:
                return fallbackToDefault ? "~/Themes/Dastone/Layouts/App.cshtml" : null;
        }
    }
}
