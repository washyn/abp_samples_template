using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Packages.ChartJs;
using Volo.Abp.AspNetCore.Mvc.UI.Widgets;
using Volo.Abp.Modularity;

namespace Washyn.Widgets.Pages.Components.UserStatisticWidget;

[Widget(AutoInitialize = true,ScriptTypes = new []{typeof(UserStatisticWidgetScriptContrib)})]
public class UserStatisticWidgetViewComponent : AbpViewComponent
{
    public IViewComponentResult Invoke(UserStatisticUpdateViewModel model)
    {
        return View("~/Pages/Components/UserStatisticWidget/Default.cshtml",model);
    }
}

[DependsOn(typeof(ChartjsScriptContributor))]
public class UserStatisticWidgetScriptContrib : BundleContributor
{
    public override void ConfigureBundle(BundleConfigurationContext context)
    {
        context.Files.Add("/Pages/Components/UserStatisticWidget/Default.js");
    }
}

public class UserStatisticUpdateViewModel
{
    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; }
    
    [DataType(DataType.Date)]
    public DateTime EndDate { get; set; }
}