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
        var boostrapContent = _virtualFileProvider.GetFileInfo("/Templates/bootstrap.css").ReadAsString();
        var result = await _templateRenderer.RenderAsync("Comprobante", model, globalContext: new Dictionary<string, object>()
        {
            {"bootstrap",boostrapContent}
        });
        var doc = PdfConfig.GetDefaut(result);
        return _converter.Convert(doc);
    }

}


// [DependsOn(typeof(AbpTextTemplatingScribanModule))]
[DependsOn(typeof(AbpTextTemplatingRazorModule))]
[DependsOn(typeof(Volo.Abp.UI.Navigation.AbpUiNavigationModule))]
public class ComprobantePdfModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpRazorTemplateCSharpCompilerOptions>(options =>
        {
            options.References.Add(MetadataReference.CreateFromFile(typeof(ComprobantePdfModule).Assembly.Location));
        });
        
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<ComprobantePdfModule>("Washyn.ComprobantePdf");
        });
        
        Configure<AbpNavigationOptions>(options =>
        {
            options.MenuContributors.Add(new ComprobantePdfMenuContributor());
        });
        
        context.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
    }
}

public class ComprobanteTemplateDefinitionProvider : TemplateDefinitionProvider
{
    public override void Define(ITemplateDefinitionContext context)
    {
        context.Add(
            new TemplateDefinition("Layout", isLayout: true)
                .WithRazorEngine()
                .WithVirtualFilePath(
                    "/Templates/Layout.cshtml",
                    isInlineLocalized: true
                )
                .WithRazorEngine()
        );
        
        context.Add(
            new TemplateDefinition(
                    name: "Comprobante",
                    layout: "Layout" 
                )
                .WithRazorEngine()
                .WithVirtualFilePath(
                    "/Templates/Comprobante.cshtml",
                    isInlineLocalized: true
                )
        );
        
    }
}

public class ComprobantePdfMenuContributor : IMenuContributor
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
        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                "Washyn.ComprobantePdf",
                "Comprobante Pdf",
                "~/ComprobantePdfSample"
            )
        );
    }
}

public static class PdfConfig
{
    // Styles not works
    public static HtmlToPdfDocument GetDefaut(string htmlContent, string cssPath = "")
    {
        var globalSettings = new GlobalSettings()
        {
            ColorMode = ColorMode.Color,
            Orientation = Orientation.Portrait,
            PaperSize = PaperKind.A4,
            Margins = new MarginSettings { Top = 5, Bottom = 10, Left = 5, Right = 5 }
        };
        var objSettings = new ObjectSettings()
        {
            PagesCount = true,
            HtmlContent = htmlContent,
            WebSettings = new WebSettings()
            {
                DefaultEncoding = System.Text.Encoding.UTF8.BodyName,
                UserStyleSheet = cssPath
            },
            // Page = "http://google.com/"
            // HeaderSettings = {FontSize = 9, Right = "Pagina [page] de [toPage]", Line = true, Spacing = 2.812}
        };
        
        var doc = new HtmlToPdfDocument()
        {
            GlobalSettings = globalSettings,
            Objects = { objSettings}
        };

        return doc;
    }
}