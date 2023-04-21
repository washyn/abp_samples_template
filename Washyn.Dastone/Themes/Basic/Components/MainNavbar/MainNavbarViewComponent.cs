﻿using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Washyn.Dastone.Themes.Basic.Components.MainNavbar;

public class MainNavbarViewComponent : AbpViewComponent
{
    public virtual IViewComponentResult Invoke()
    {
        return View("~/Themes/Basic/Components/MainNavbar/Default.cshtml");
    }
}
