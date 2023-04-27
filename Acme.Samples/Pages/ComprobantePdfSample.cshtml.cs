using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Washyn.ComprobantePdf;

namespace Acme.Samples.Pages;

public class ComprobantePdfSample : PageModel
{
    [Inject]
    public ComprobanteService DemoComprobante { get; set; }
    public async Task<IActionResult> OnGetAsync()
    {
        var file = await DemoComprobante.Generate();
        return File(file, System.Net.Mime.MediaTypeNames.Application.Pdf, "sample.pdf");
    }
}