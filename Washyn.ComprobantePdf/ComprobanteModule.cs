using Microsoft.CodeAnalysis;
using Volo.Abp.Modularity;
using Volo.Abp.TextTemplating;
using Volo.Abp.TextTemplating.Razor;
using Volo.Abp.UI.Navigation;
using Volo.Abp.VirtualFileSystem;
using WkHtmlToPdfDotNet;
using WkHtmlToPdfDotNet.Contracts;

namespace Washyn.ComprobantePdf;

[DependsOn(typeof(AbpTextTemplatingRazorModule))]
[DependsOn(typeof(AbpUiNavigationModule))]
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
    public static HtmlToPdfDocument GetDefaut(string htmlContent)
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
                // UserStyleSheet = cssPath // styles not works
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