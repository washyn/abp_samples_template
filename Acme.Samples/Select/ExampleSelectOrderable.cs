using Volo.Abp.Application.Services;

namespace Acme.Samples.Select;

public class SunatCatalogEntity : LookupEntity<string>, IHasDisplayOrder
{
    public int DisplayOrder { get; set; }
}

// typing for display order
public class ExampleSelectOrderable : AbstractEntitySelectAppService<string, SunatCatalogEntity>, IExampleSelectOrderable
{
    protected override Task<IQueryable<SunatCatalogEntity>> CreateSelectQueryAsync()
    {
        var data = TipoTributoOrderable.GetValues().Select(a => new SunatCatalogEntity()
        {
            Id = a.Codigo,
            DisplayName = a.Descripcion,
            DisplayOrder = a.DisplayOrder, 
        });
        return Task.FromResult(data.AsQueryable());
    }
}

public interface IExampleSelectOrderable : ISelectAppService<string>
{
    
}

public class TipoTributoOrderable : IHasDisplayOrder
{
    public string Codigo { get; set; }
    public string Descripcion { get; set; }
    public string Nombre { get; set; }
    public string CodigoInternacional { get; set; }
        
    public static List<TipoTributoOrderable> GetValues()
    {
        return new List<TipoTributoOrderable>()
        {
            new TipoTributoOrderable
            {
                DisplayOrder = 12,
                Codigo = "1000",
                Descripcion = "IGV Impuesto General a las Ventas",
                CodigoInternacional = "VAT",
                Nombre = "IGV"
            },
            new TipoTributoOrderable
            {
                Codigo = "1016",
                Descripcion = "Impuesto a la Venta Arroz Pilado",
                CodigoInternacional = "VAT",
                Nombre = "IVAP"
            },
            new TipoTributoOrderable
            {
                DisplayOrder = 11,
                Codigo = "2000",
                Descripcion = "ISC Impuesto Selectivo al Consumo",
                CodigoInternacional = "EXC",
                Nombre = "ISC"
            },
            new TipoTributoOrderable
            {
                DisplayOrder = 10,
                Codigo = "3000",
                Descripcion = "Impuesto a la Renta",
                CodigoInternacional = "TOX",
                Nombre = "IR"
            },
            new TipoTributoOrderable
            {
                DisplayOrder = 9,
                Codigo = "7152",
                Descripcion = "Impuesto a la bolsa plastica",
                CodigoInternacional = "OTH",
                Nombre = "ICBPER"
            },
            new TipoTributoOrderable
            {
                Codigo = "9995",
                Descripcion = "Exportación",
                CodigoInternacional = "FRE",
                Nombre = "EXP"
            },
            new TipoTributoOrderable
            {
                Codigo = "9996",
                Descripcion = "Gratuito",
                CodigoInternacional = "FRE",
                Nombre = "GRA"
            },
            new TipoTributoOrderable
            {
                DisplayOrder = 8,
                Codigo = "9997",
                Descripcion = "Exonerado",
                CodigoInternacional = "VAT",
                Nombre = "EXO"
            },
            new TipoTributoOrderable
            {
                DisplayOrder = 7,
                Codigo = "9998",
                Descripcion = "Inafecto",
                CodigoInternacional = "FRE",
                Nombre = "INA"
            },
            new TipoTributoOrderable
            {
                DisplayOrder = 5,
                Codigo = "9999",
                Descripcion = "Otros tributos",
                CodigoInternacional = "OTH",
                Nombre = "OTROS"
            }
        };
    }

    public int DisplayOrder { get; set; }
}