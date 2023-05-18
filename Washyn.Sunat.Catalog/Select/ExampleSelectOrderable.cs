using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Washyn.Abp.Select2;

namespace Washyn.Sunat.Catalog.Select
{

    public class SunatCatalogEntity : LookupEntity<string>, IHasDisplayOrder<int>
    {
        public int DisplayOrder { get; set; }
    }


    public class ExampleSelectOrderable : AbstractEntitySelectAppService<string, CatalogLookupEntity<string>, int>, IExampleSelectOrderable
    {
        protected override Task<IQueryable<CatalogLookupEntity<string>>> CreateSelectQueryAsync()
        {
            var data = TipoTributoOrderable.GetValues().Select(a => new CatalogLookupEntity<string>()
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

    public class TipoTributoOrderable : IHasDisplayOrder<int>
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
                DisplayOrder = 1,
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
                Codigo = "2000",
                Descripcion = "ISC Impuesto Selectivo al Consumo",
                CodigoInternacional = "EXC",
                Nombre = "ISC"
            },
            new TipoTributoOrderable
            {
                Codigo = "3000",
                Descripcion = "Impuesto a la Renta",
                CodigoInternacional = "TOX",
                Nombre = "IR"
            },
            new TipoTributoOrderable
            {
                DisplayOrder = 435,
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
                Codigo = "9997",
                Descripcion = "Exonerado",
                CodigoInternacional = "VAT",
                Nombre = "EXO"
            },
            new TipoTributoOrderable
            {
                Codigo = "9998",
                Descripcion = "Inafecto",
                CodigoInternacional = "FRE",
                Nombre = "INA"
            },
            new TipoTributoOrderable
            {
                Codigo = "9999",
                Descripcion = "Otros tributos",
                CodigoInternacional = "OTH",
                Nombre = "OTROS"
            }
        };
        }

        public int DisplayOrder { get; set; }
    }
}