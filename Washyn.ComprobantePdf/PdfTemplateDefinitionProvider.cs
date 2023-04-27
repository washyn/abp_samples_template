using Volo.Abp.TextTemplating;
using Volo.Abp.TextTemplating.Razor;

namespace Washyn.ComprobantePdf;

public class PdfTemplateDefinitionProvider : TemplateDefinitionProvider
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
