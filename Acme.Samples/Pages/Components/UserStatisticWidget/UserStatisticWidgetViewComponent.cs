using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Services;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Packages.ChartJs;
using Volo.Abp.AspNetCore.Mvc.UI.Widgets;
using Volo.Abp.AuditLogging;
using Volo.Abp.Modularity;

namespace Acme.Samples.Pages.Components.UserStatisticWidget;

public class UserStatisticWidgetInputDto
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}

public class UserStatisticResultDto
{
    public Dictionary<DateTime, double> Data { get; set; }
}

public class UserStatisticAppService : ApplicationService
{
    private readonly IAuditLogRepository _repository;

    public UserStatisticAppService(IAuditLogRepository repository)
    {
        _repository = repository;
    }

    public async Task<UserStatisticResultDto> GetUserStatisticWidgetAsync(UserStatisticWidgetInputDto input)
    {
        var tempRes = await _repository.GetAverageExecutionDurationPerDayAsync(input.StartDate, input.EndDate);
        return new UserStatisticResultDto()
        {
            Data = tempRes
        };
    }
}

[Widget(AutoInitialize = true,ScriptTypes = new []{typeof(UserStatisticWidgetScriptContrib)})]
public class UserStatisticWidgetViewComponent : AbpViewComponent
{
    public IViewComponentResult Invoke(UserStatisticUpdateViewModel model)
    {
        return View(model);
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
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}