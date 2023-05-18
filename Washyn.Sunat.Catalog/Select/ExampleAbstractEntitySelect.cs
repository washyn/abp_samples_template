using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.AspNetCore.Mvc;
using Washyn.Abp.Select2;

namespace Washyn.Sunat.Catalog.Select
{
    [RemoteService(isEnabled: false)]
    public class ExampleAbstractEntitySelectAppService
    : AbstractEntitySelectAppService<string>
        , IExampleAbstractEntitySelectAppService
    {
        protected override Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
        {
            return Task.FromResult(TipoUnidadMedidaComercial.GetValues().Select(a => new LookupEntity<string>()
            {
                Id = a.Codigo,
                DisplayName = a.Descripcion,
            }));
        }
    }

    public interface IExampleAbstractEntitySelectAppService : ISelectAppService<string>
    {

    }

    [Route("api/app/example-abstract-entity-select")]
    public class ExampleAbstractEntitySelectController : AbpController, IExampleAbstractEntitySelectAppService
    {
        private readonly IExampleAbstractEntitySelectAppService _appService;

        public ExampleAbstractEntitySelectController(IExampleAbstractEntitySelectAppService appService)
        {
            _appService = appService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<LookupDto<string>> GetAsync(string id)
        {
            return await _appService.GetAsync(id);
        }
        [HttpGet]
        public async Task<PagedResultDto<LookupDto<string>>> GetListAsync(LookupRequestDto input)
        {
            return await _appService.GetListAsync(input);
        }
    }

    public class TipoUnidadMedidaComercial
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }

        public static IQueryable<TipoUnidadMedidaComercial> GetValues()
        {
            var a = new List<TipoUnidadMedidaComercial>()
        {
            new TipoUnidadMedidaComercial()
            {
                Codigo = "BJ",
                Descripcion = "BALDE"
            },
            new TipoUnidadMedidaComercial()
            {
                Codigo = "BLL",
                Descripcion = "BARRILES"
            },
            new TipoUnidadMedidaComercial()
            {
                Codigo = "4A",
                Descripcion = "BOBINAS"
            },
            new TipoUnidadMedidaComercial()
            {
                Codigo = "BG",
                Descripcion = "BOLSA"
            },
            new TipoUnidadMedidaComercial()
            {
                Codigo = "BO",
                Descripcion = "BOTELLAS"
            },
            new TipoUnidadMedidaComercial()
            {
                Codigo = "BX",
                Descripcion = "CAJAS"
            },
            new TipoUnidadMedidaComercial()
            {
                Codigo = "CT",
                Descripcion = "CARTONES"
            },
            new TipoUnidadMedidaComercial()
            {
                Codigo = "CMK",
                Descripcion = "CENTIMETRO CUADRADO"
            },
            new TipoUnidadMedidaComercial()
            {
                Codigo = "CMQ",
                Descripcion = "CENTIMETRO CUBICO"
            },
            new TipoUnidadMedidaComercial()
            {
                Codigo = "CMT",
                Descripcion = "CENTIMETRO LINEAL"
            },
            new TipoUnidadMedidaComercial()
            {
                Codigo = "CEN",
                Descripcion = "CIENTO DE UNIDADES"
            },
            new TipoUnidadMedidaComercial()
            {
                Codigo = "CY",
                Descripcion = "CILINDRO"
            },
            new TipoUnidadMedidaComercial()
            {
                Codigo = "CJ",
                Descripcion = "CONOS"
            },
            new TipoUnidadMedidaComercial()
            {
                Codigo = "DZN",
                Descripcion = "DOCENA"
            },
            new TipoUnidadMedidaComercial()
            {
                Codigo = "DZP",
                Descripcion = "DOCENA POR 10**6"
            },
            new TipoUnidadMedidaComercial()
            {
                Codigo = "BE",
                Descripcion = "FARDO"
            },
            new TipoUnidadMedidaComercial()
            {
                Codigo = "GLI",
                Descripcion = "GALON INGLES (4,545956L)"
            },
            new TipoUnidadMedidaComercial()
            {
                Codigo = "GRM",
                Descripcion = "GRAMO"
            },
            new TipoUnidadMedidaComercial()
            {
                Codigo = "GRO",
                Descripcion = "GRUESA"
            },
            new TipoUnidadMedidaComercial()
            {
                Codigo = "HLT",
                Descripcion = "HELECTROLITO"
            },
            new TipoUnidadMedidaComercial()
            {
                Codigo = "LEF",
                Descripcion = "HOJA"
            },
            new TipoUnidadMedidaComercial()
            {
                Codigo = "SET",
                Descripcion = "JUEGO"
            },
            new TipoUnidadMedidaComercial()
            {
                Codigo = "KGM",
                Descripcion = "KILOGRAMO"
            },
            new TipoUnidadMedidaComercial()
            {
                Codigo = "KTM",
                Descripcion = "KILOMETRO"
            },
            new TipoUnidadMedidaComercial()
            {
                Codigo = "KWH",
                Descripcion = "KILOVATIO HORA"
            },
            new TipoUnidadMedidaComercial()
            {
                Codigo = "KT",
                Descripcion = "KIT"
            },
            new TipoUnidadMedidaComercial()
            {
                Codigo = "CA",
                Descripcion = "LATAS"
            },
            new TipoUnidadMedidaComercial()
            {
                Codigo = "LBR",
                Descripcion = "LIBRAS"
            },
            new TipoUnidadMedidaComercial()
            {
                Codigo = "LTR",
                Descripcion = "LITROS"
            },
            new TipoUnidadMedidaComercial()
            {
                Codigo = "MWH",
                Descripcion = "MEGAWHAT HORA"
            },
            new TipoUnidadMedidaComercial()
            {
                Codigo = "MTR",
                Descripcion = "METRO"
            },
            new TipoUnidadMedidaComercial()
            {
                Codigo = "MTK",
                Descripcion = "METRO CUADRADO"
            },
            new TipoUnidadMedidaComercial()
            {
                Codigo = "MTQ",
                Descripcion = "METRO CUBICO"
            },
            new TipoUnidadMedidaComercial()
            {
                Codigo = "MGM",
                Descripcion = "MILIGRAMOS"
            },
            new TipoUnidadMedidaComercial()
            {
                Codigo = "MLT",
                Descripcion = "MILILITRO"
            },
            new TipoUnidadMedidaComercial()
            {
                Codigo = "MMT",
                Descripcion = "MILIMETRO"
            },
            new TipoUnidadMedidaComercial()
            {
                Codigo = "MMK",
                Descripcion = "MILIMETRO CUADRADO"
            },
            new TipoUnidadMedidaComercial()
            {
                Codigo = "MMQ",
                Descripcion = "MILIMETRO CUBICO"
            },
            new TipoUnidadMedidaComercial()
            {
                Codigo = "MLL",
                Descripcion = "MILLARES"
            },
            new TipoUnidadMedidaComercial()
            {
                Codigo = "MU",
                Descripcion = "MILLON DE UNIDADES"
            },
            new TipoUnidadMedidaComercial()
            {
                Codigo = "ONZ",
                Descripcion = "ONZAS"
            },
            new TipoUnidadMedidaComercial()
            {
                Codigo = "PF",
                Descripcion = "PALETAS"
            },
            new TipoUnidadMedidaComercial()
            {
                Codigo = "PK",
                Descripcion = "PAQUETE"
            },
            new TipoUnidadMedidaComercial()
            {
                Codigo = "PR",
                Descripcion = "PAR"
            },
            new TipoUnidadMedidaComercial()
            {
                Codigo = "FOT",
                Descripcion = "PIES"
            },
            new TipoUnidadMedidaComercial()
            {
                Codigo = "FTK",
                Descripcion = "PIES CUADRADOS"
            },
            new TipoUnidadMedidaComercial()
            {
                Codigo = "FTQ",
                Descripcion = "PIES CUBICOS"
            },
            new TipoUnidadMedidaComercial()
            {
                Codigo = "C62",
                Descripcion = "PIEZAS"
            },
            new TipoUnidadMedidaComercial()
            {
                Codigo = "PG",
                Descripcion = "PLACAS"
            },
            new TipoUnidadMedidaComercial()
            {
                Codigo = "ST",
                Descripcion = "PLIEGO"
            },
            new TipoUnidadMedidaComercial()
            {
                Codigo = "INH",
                Descripcion = "PULGADAS"
            },
            new TipoUnidadMedidaComercial()
            {
                Codigo = "RM",
                Descripcion = "RESMA"
            },
            new TipoUnidadMedidaComercial()
            {
                Codigo = "DR",
                Descripcion = "TAMBOR"
            },
            new TipoUnidadMedidaComercial()
            {
                Codigo = "STN",
                Descripcion = "TONELADA CORTA"
            },
            new TipoUnidadMedidaComercial()
            {
                Codigo = "LTN",
                Descripcion = "TONELADA LARGA"
            },
            new TipoUnidadMedidaComercial()
            {
                Codigo = "TNE",
                Descripcion = "TONELADAS"
            },
            new TipoUnidadMedidaComercial()
            {
                Codigo = "TU",
                Descripcion = "TUBOS"
            },
            new TipoUnidadMedidaComercial()
            {
                Codigo = "NIU",
                Descripcion = "UNIDAD (BIENES)"
            },
            new TipoUnidadMedidaComercial()
            {
                Codigo = "ZZ",
                Descripcion = "UNIDAD (SERVICIOS) "
            },
            new TipoUnidadMedidaComercial()
            {
                Codigo = "GLL",
                Descripcion = "US GALON (3,7843 L)"
            },
            new TipoUnidadMedidaComercial()
            {
                Codigo = "YRD",
                Descripcion = "YARDA"
            },
            new TipoUnidadMedidaComercial()
            {
                Codigo = "YDK",
                Descripcion = "YARDA CUADRADA"
            }
        };
            return a.AsQueryable();
        }
    }

    public class TipoTributo
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Nombre { get; set; }
        public string CodigoInternacional { get; set; }

        public static List<TipoTributo> GetValues()
        {
            // [
            // {
            //     "codigo": "1000",
            //     "descripcion": "IGV Impuesto General a las Ventas",
            //     "codigo_internacional": "VAT",
            //     "nombre": "IGV"
            // },
            // {
            //     "codigo": "1016",
            //     "descripcion": "Impuesto a la Venta Arroz Pilado",
            //     "codigo_internacional": "VAT",
            //     "nombre": "IVAP"
            // },
            // {
            //     "codigo": "2000",
            //     "descripcion": "ISC Impuesto Selectivo al Consumo",
            //     "codigo_internacional": "EXC",
            //     "nombre": "ISC"
            // },
            // {
            //     "codigo": "3000",
            //     "descripcion": "Impuesto a la Renta",
            //     "codigo_internacional": "TOX",
            //     "nombre": "IR"
            // },
            // {
            //     "codigo": "7152",
            //     "descripcion": "Impuesto a la bolsa plastica",
            //     "codigo_internacional": "OTH",
            //     "nombre": "ICBPER"
            // },
            // {
            //     "codigo": "9995",
            //     "descripcion": "Exportación",
            //     "codigo_internacional": "FRE",
            //     "nombre": "EXP"
            // },
            // {
            //     "codigo": "9996",
            //     "descripcion": "Gratuito",
            //     "codigo_internacional": "FRE",
            //     "nombre": "GRA"
            // },
            // {
            //     "codigo": "9997",
            //     "descripcion": "Exonerado",
            //     "codigo_internacional": "VAT",
            //     "nombre": "EXO"
            // },
            // {
            //     "codigo": "9998",
            //     "descripcion": "Inafecto",
            //     "codigo_internacional": "FRE",
            //     "nombre": "INA"
            // },
            // {
            //     "codigo": "9999",
            //     "descripcion": "Otros tributos",
            //     "codigo_internacional": "OTH",
            //     "nombre": "OTROS"
            // }
            // ]

            return new List<TipoTributo>()
        {
            new TipoTributo
            {
                Codigo = "1000",
                Descripcion = "IGV Impuesto General a las Ventas",
                CodigoInternacional = "VAT",
                Nombre = "IGV"
            },
            new TipoTributo
            {
                Codigo = "1016",
                Descripcion = "Impuesto a la Venta Arroz Pilado",
                CodigoInternacional = "VAT",
                Nombre = "IVAP"
            },
            new TipoTributo
            {
                Codigo = "2000",
                Descripcion = "ISC Impuesto Selectivo al Consumo",
                CodigoInternacional = "EXC",
                Nombre = "ISC"
            },
            new TipoTributo
            {
                Codigo = "3000",
                Descripcion = "Impuesto a la Renta",
                CodigoInternacional = "TOX",
                Nombre = "IR"
            },
            new TipoTributo
            {
                Codigo = "7152",
                Descripcion = "Impuesto a la bolsa plastica",
                CodigoInternacional = "OTH",
                Nombre = "ICBPER"
            },
            new TipoTributo
            {
                Codigo = "9995",
                Descripcion = "Exportación",
                CodigoInternacional = "FRE",
                Nombre = "EXP"
            },
            new TipoTributo
            {
                Codigo = "9996",
                Descripcion = "Gratuito",
                CodigoInternacional = "FRE",
                Nombre = "GRA"
            },
            new TipoTributo
            {
                Codigo = "9997",
                Descripcion = "Exonerado",
                CodigoInternacional = "VAT",
                Nombre = "EXO"
            },
            new TipoTributo
            {
                Codigo = "9998",
                Descripcion = "Inafecto",
                CodigoInternacional = "FRE",
                Nombre = "INA"
            },
            new TipoTributo
            {
                Codigo = "9999",
                Descripcion = "Otros tributos",
                CodigoInternacional = "OTH",
                Nombre = "OTROS"
            }
        };
        }
    }
}