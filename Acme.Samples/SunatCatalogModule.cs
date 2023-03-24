using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Acme.Samples;

[DependsOn(typeof(AbpVirtualFileSystemModule))]
public class SunatCatalogModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<SunatCatalogModule>();
        });
    }
}

#region Catalog Dtos

public class SunatCommonCatalogDto
{
    public string Codigo { get; set; }
    public string Descripcion { get; set; }
}

public class TipoTributoDto : SunatCommonCatalogDto
{
    [JsonProperty("codigo_internacional")]
    public string CodigoInternacional { get; set; }
    public string Nombre { get; set; }
}

#endregion


#region Services

public class TipoDocumentoSelectAppService : AbstractEntitySelectAppService<string>
{
    private readonly CatalogData _catalogData;

    public TipoDocumentoSelectAppService(CatalogData catalogData)
    {
        _catalogData = catalogData;
    }
    protected override Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var temp = _catalogData.GetDataTipoDocumento();
        return Task.FromResult(temp.Select(a => new LookupEntity<string>()
        {
            Id = a.Codigo,
            DisplayName = a.Descripcion
        }).AsQueryable());
    }
}

public class UnidadMedidaComercialSelectAppService : AbstractEntitySelectAppService<string>
{
    private readonly CatalogData _catalogData;

    public UnidadMedidaComercialSelectAppService(CatalogData catalogData)
    {
        _catalogData = catalogData;
    }
    protected override Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var temp = _catalogData.GetDataUnidadMedidaComercial();
        return Task.FromResult(temp.Select(a => new LookupEntity<string>()
        {
            Id = a.Codigo,
            DisplayName = a.Descripcion,
        }).AsQueryable());
    }
}

public class TipoTributoSelectAppService : AbstractEntitySelectAppService<string>
{
    private readonly CatalogData _catalogData;

    public TipoTributoSelectAppService(CatalogData catalogData)
    {
        _catalogData = catalogData;
    }
    protected override Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var temp = _catalogData.GetDataTipoTributo();
        return Task.FromResult(temp.Select(a => new LookupEntity<string>()
        {
            Id = a.Codigo,
            DisplayName = a.Descripcion,
            AlternativeText = a.CodigoInternacional
        }).AsQueryable());
    }
}

public class CatalogData : ISingletonDependency
{
    private readonly IVirtualFileProvider _fileProvider;

    public CatalogData(IVirtualFileProvider fileProvider)
    {
        _fileProvider = fileProvider;
    }

    public List<SunatCommonCatalogDto> GetDataTipoDocumento()
    {
        var strFile = _fileProvider.GetFileInfo(FileNames.Catalog.TIPO_DE_DOCUMENTO_01).ReadAsString();
        return JsonConvert.DeserializeObject<List<SunatCommonCatalogDto>>(strFile);
    }
    
    public List<SunatCommonCatalogDto> GetDataUnidadMedidaComercial()
    {
        var strFile = _fileProvider.GetFileInfo(FileNames.Catalog.TIPO_DE_UNIDAD_DE_MEDIDA_COMERCIAL_03).ReadAsString();
        return JsonConvert.DeserializeObject<List<SunatCommonCatalogDto>>(strFile);
    }
    
    public List<TipoTributoDto> GetDataTipoTributo()
    {
        var strFile = _fileProvider.GetFileInfo(FileNames.Catalog.CODIGO_DE_TIPOS_DE_TRIBUTOS_Y_OTROS_CONCEPTOS_05).ReadAsString();
        return JsonConvert.DeserializeObject<List<TipoTributoDto>>(strFile);
    }
}

#endregion


public class FileNames
{
    public const string Folder = "/SunatCatalogFiles/";
    public class Catalog
    {
        /// <summary>
        /// N° 01 - Tipo de documento
        /// </summary>
        public const string TIPO_DE_DOCUMENTO_01 = Folder + "01.json";
        /// <summary>
        /// 03 - Tipo de unidad de medida comercial
        /// </summary>
        public const string TIPO_DE_UNIDAD_DE_MEDIDA_COMERCIAL_03 = Folder + "03.json";
        /// <summary>
        /// N° 05 - Código de tipos de tributos y otros conceptos
        /// </summary>
        public const string CODIGO_DE_TIPOS_DE_TRIBUTOS_Y_OTROS_CONCEPTOS_05 = Folder + "05.json";
    }
}