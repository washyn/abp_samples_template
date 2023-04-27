using Microsoft.CodeAnalysis;
using Microsoft.Extensions.FileProviders;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.TextTemplating;
using Volo.Abp.TextTemplating.Razor;
using Volo.Abp.UI.Navigation;
using Volo.Abp.VirtualFileSystem;
using Washyn.ComprobantePdf.Templates;
using WkHtmlToPdfDotNet;
using WkHtmlToPdfDotNet.Contracts;

namespace Washyn.ComprobantePdf;

public class ComprobanteService : ITransientDependency
{
    private readonly ITemplateRenderer _templateRenderer;
    private readonly ILogger<ComprobanteService> _logger;
    private readonly IVirtualFileProvider _virtualFileProvider;
    private readonly IConverter _converter;

    public ComprobanteService(ITemplateRenderer templateRenderer,
        ILogger<ComprobanteService> logger,
        IVirtualFileProvider virtualFileProvider,
        IConverter converter)
    {
        _templateRenderer = templateRenderer;
        _logger = logger;
        _virtualFileProvider = virtualFileProvider;
        _converter = converter;
    }

    public async Task<byte[]> Generate()
    {
        var model = new ComprobanteAndItems()
        {
            Details = new ComprobanteDetails()
            {
                Amount = 34,
                Date = DateTime.Now,
                Document = "test",
                Number = 45,
                FullName = "test full",
                ComprobanteId = Guid.NewGuid()
            },
            Items = new List<ComprobanteItems>()
            {
                new ComprobanteItems()
                {
                    Cantidad = 45,
                    Description = "test",
                    Price = 4566
                }
            }
        };
        // Improvement: Create service for send only Model and template name, styles by default add...
        // add pdf generator... and chache for return pdf, client cache one year ...
        var boostrapContent = _virtualFileProvider.GetFileInfo("/Templates/bootstrap.css").ReadAsString();
        var result = await _templateRenderer.RenderAsync("Comprobante", model, globalContext: new Dictionary<string, object>()
        {
            {"bootstrap",boostrapContent}
        });
        var doc = PdfConfig.GetDefaut(result);
        return _converter.Convert(doc);
    }
}