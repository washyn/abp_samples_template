﻿using Acme.Samples.Menus;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.UI.Navigation;

namespace Acme.Samples.Themes.Sb.Components.PublicNavBar.PublicMenu;

public class PublicMenuViewComponent : AbpViewComponent
{
    private readonly IMenuManager _menuManager;

    public PublicMenuViewComponent(IMenuManager menuManager)
    {
        _menuManager = menuManager;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var menu = await _menuManager.GetAsync(PublicMenuContributor.PublicMenu);
        return View("~/Themes/Sb/Components/PublicNavBar/PublicMenu/Default.cshtml", menu);
    }
}