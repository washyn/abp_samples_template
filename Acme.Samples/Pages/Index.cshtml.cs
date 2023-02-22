using Volo.Abp.AspNetCore.Mvc.UI.Alerts;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Acme.Samples.Pages;

public class IndexModel : AbpPageModel
{
    public void OnGet()
    {
        Alerts.Add(new AlertMessage(AlertType.Primary, "Lorem ipsum es el texto que se usa habitualmente en diseño gráfico en demostraciones de tipografías o de borradores de diseño para probar el diseño visual antes de insertar el texto final.", dismissible: true));
        Alerts.Add(new AlertMessage(AlertType.Danger, "Lorem ipsum es el texto que se usa habitualmente en diseño gráfico en demostraciones de tipografías o de borradores de diseño para probar el diseño visual antes de insertar el texto final.", dismissible: true));
        Alerts.Add(new AlertMessage(AlertType.Secondary, "Lorem ipsum es el texto que se usa habitualmente en diseño gráfico en demostraciones de tipografías o de borradores de diseño para probar el diseño visual antes de insertar el texto final.", dismissible: true));
        Alerts.Add(new AlertMessage(AlertType.Dark, "Lorem ipsum es el texto que se usa habitualmente en diseño gráfico en demostraciones de tipografías o de borradores de diseño para probar el diseño visual antes de insertar el texto final.", dismissible: true));
        Alerts.Add(new AlertMessage(AlertType.Info, "Lorem ipsum es el texto que se usa habitualmente en diseño gráfico en demostraciones de tipografías o de borradores de diseño para probar el diseño visual antes de insertar el texto final.", dismissible: true));
        Alerts.Add(new AlertMessage(AlertType.Light, "Lorem ipsum es el texto que se usa habitualmente en diseño gráfico en demostraciones de tipografías o de borradores de diseño para probar el diseño visual antes de insertar el texto final.", dismissible: true));
        Alerts.Add(new AlertMessage(AlertType.Success, "Lorem ipsum es el texto que se usa habitualmente en diseño gráfico en demostraciones de tipografías o de borradores de diseño para probar el diseño visual antes de insertar el texto final.", dismissible: true));
        Alerts.Add(new AlertMessage(AlertType.Warning, "Lorem ipsum es el texto que se usa habitualmente en diseño gráfico en demostraciones de tipografías o de borradores de diseño para probar el diseño visual antes de insertar el texto final.", dismissible: true));
        Alerts.Add(new AlertMessage(AlertType.Primary, "Lorem ipsum es el texto que se usa habitualmente en diseño gráfico en demostraciones de tipografías o de borradores de diseño para probar el diseño visual antes de insertar el texto final.", dismissible: true));
    }
}