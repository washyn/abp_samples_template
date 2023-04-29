using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;
using Volo.Abp.DependencyInjection;
using Volo.Abp.VirtualFileSystem;
using Washyn.Abp.Select2;

namespace Washyn.Sunat.Catalog;


#region Select app services

// crear controllers directamente y no app service para agregarle cache, y desarctivar el remote service en esto app services...
// 60*60*24*30*12
public class C01AppService : SunatCatalogBase, IC01AppService
{
    public C01AppService(CatalogData catalogData) : base(catalogData)
    {
    }
    protected override async Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var tempData = _catalogData.GetDataC01();
        return tempData.Select(a => new LookupEntity<string>()
        {
            Id = a.Codigo,
            DisplayName = a.Descripcion,
        }).AsQueryable();
    }
}

public class C02AppService : SunatCatalogBase, IC02AppService
{
    public C02AppService(CatalogData catalogData) : base(catalogData)
    {
    }
    protected override async Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var tempData = _catalogData.GetDataC02();
        return tempData.Select(a => new LookupEntity<string>()
        {
            Id = a.Currency,
            DisplayName = a.CountryName,
        }).AsQueryable();
    }
}

public class C03AppService : SunatCatalogBase, IC03AppService
{
    public C03AppService(CatalogData catalogData) : base(catalogData)
    {
    }
    protected override async Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var tempData = _catalogData.GetDataC03();
        return tempData.Select(a => new LookupEntity<string>()
        {
            Id = a.Codigo,
            DisplayName = a.Descripcion,
        }).AsQueryable();
    }
}

public class C04AppService : SunatCatalogBase, IC04AppService
{
    public C04AppService(CatalogData catalogData) : base(catalogData)
    {
    }
    protected override async Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var tempData = _catalogData.GetDataC04();
        return tempData.Select(a => new LookupEntity<string>()
        {
            Id = a.A2,
            DisplayName = a.Country,
        }).AsQueryable();
    }
}

public class C05AppService : SunatCatalogBase, IC05AppService
{
    public C05AppService(CatalogData catalogData) : base(catalogData)
    {
    }
    protected override async Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var tempData = _catalogData.GetDataC05();
        return tempData.Select(a => new LookupEntity<string>()
        {
            Id = a.Codigo,
            DisplayName = a.Descripcion,
        }).AsQueryable();
    }
}

public class C06AppService : SunatCatalogBase, IC06AppService
{
    public C06AppService(CatalogData catalogData) : base(catalogData)
    {
    }
    protected override async Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var tempData = _catalogData.GetDataC06();
        return tempData.Select(a => new LookupEntity<string>()
        {
            Id = a.Codigo,
            DisplayName = a.Descripcion,
        }).AsQueryable();
    }
}

public class C07AppService : SunatCatalogBase, IC07AppService
{
    public C07AppService(CatalogData catalogData) : base(catalogData)
    {
    }
    protected override async Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var tempData = _catalogData.GetDataC07();
        return tempData.Select(a => new LookupEntity<string>()
        {
            Id = a.Codigo,
            DisplayName = a.Descripcion,
        }).AsQueryable();
    }
}

public class C08AppService : SunatCatalogBase, IC08AppService
{
    public C08AppService(CatalogData catalogData) : base(catalogData)
    {
    }
    protected override async Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var tempData = _catalogData.GetDataC08();
        return tempData.Select(a => new LookupEntity<string>()
        {
            Id = a.Codigo,
            DisplayName = a.Descripcion,
        }).AsQueryable();
    }
}

public class C09AppService : SunatCatalogBase, IC09AppService
{
    public C09AppService(CatalogData catalogData) : base(catalogData)
    {
    }
    protected override async Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var tempData = _catalogData.GetDataC09();
        return tempData.Select(a => new LookupEntity<string>()
        {
            Id = a.Codigo,
            DisplayName = a.Descripcion,
        }).AsQueryable();
    }
}

public class C10AppService : SunatCatalogBase, IC10AppService
{
    public C10AppService(CatalogData catalogData) : base(catalogData)
    {
    }
    protected override async Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var tempData = _catalogData.GetDataC10();
        return tempData.Select(a => new LookupEntity<string>()
        {
            Id = a.Codigo,
            DisplayName = a.Descripcion,
        }).AsQueryable();
    }
}

public class C11AppService : SunatCatalogBase, IC11AppService
{
    public C11AppService(CatalogData catalogData) : base(catalogData)
    {
    }
    protected override async Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var tempData = _catalogData.GetDataC11();
        return tempData.Select(a => new LookupEntity<string>()
        {
            Id = a.Codigo,
            DisplayName = a.Descripcion,
        }).AsQueryable();
    }
}

public class C12AppService : SunatCatalogBase, IC12AppService
{
    public C12AppService(CatalogData catalogData) : base(catalogData)
    {
    }
    protected override async Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var tempData = _catalogData.GetDataC12();
        return tempData.Select(a => new LookupEntity<string>()
        {
            Id = a.Codigo,
            DisplayName = a.Descripcion,
        }).AsQueryable();
    }
}

public class C14AppService : SunatCatalogBase, IC14AppService
{
    public C14AppService(CatalogData catalogData) : base(catalogData)
    {
    }
    protected override async Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var tempData = _catalogData.GetDataC14();
        return tempData.Select(a => new LookupEntity<string>()
        {
            Id = a.Codigo,
            DisplayName = a.Descripcion,
        }).AsQueryable();
    }
}

public class C15AppService : SunatCatalogBase, IC15AppService
{
    public C15AppService(CatalogData catalogData) : base(catalogData)
    {
    }
    protected override async Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var tempData = _catalogData.GetDataC15();
        return tempData.Select(a => new LookupEntity<string>()
        {
            Id = a.Codigo,
            DisplayName = a.Descripcion,
        }).AsQueryable();
    }
}

public class C16AppService : SunatCatalogBase, IC16AppService
{
    public C16AppService(CatalogData catalogData) : base(catalogData)
    {
    }
    protected override async Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var tempData = _catalogData.GetDataC16();
        return tempData.Select(a => new LookupEntity<string>()
        {
            Id = a.Codigo,
            DisplayName = a.Descripcion,
        }).AsQueryable();
    }
}

public class C17AppService : SunatCatalogBase, IC17AppService
{
    public C17AppService(CatalogData catalogData) : base(catalogData)
    {
    }
    protected override async Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var tempData = _catalogData.GetDataC17();
        return tempData.Select(a => new LookupEntity<string>()
        {
            Id = a.Codigo,
            DisplayName = a.Descripcion,
        }).AsQueryable();
    }
}

public class C18AppService : SunatCatalogBase, IC18AppService
{
    public C18AppService(CatalogData catalogData) : base(catalogData)
    {
    }
    protected override async Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var tempData = _catalogData.GetDataC18();
        return tempData.Select(a => new LookupEntity<string>()
        {
            Id = a.Codigo,
            DisplayName = a.Descripcion,
        }).AsQueryable();
    }
}

public class C19AppService : SunatCatalogBase, IC19AppService
{
    public C19AppService(CatalogData catalogData) : base(catalogData)
    {
    }
    protected override async Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var tempData = _catalogData.GetDataC19();
        return tempData.Select(a => new LookupEntity<string>()
        {
            Id = a.Codigo,
            DisplayName = a.Descripcion,
        }).AsQueryable();
    }
}

public class C20AppService : SunatCatalogBase, IC20AppService
{
    public C20AppService(CatalogData catalogData) : base(catalogData)
    {
    }
    protected override async Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var tempData = _catalogData.GetDataC20();
        return tempData.Select(a => new LookupEntity<string>()
        {
            Id = a.Codigo,
            DisplayName = a.Descripcion,
        }).AsQueryable();
    }
}

public class C21AppService : SunatCatalogBase, IC21AppService
{
    public C21AppService(CatalogData catalogData) : base(catalogData)
    {
    }
    protected override async Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var tempData = _catalogData.GetDataC21();
        return tempData.Select(a => new LookupEntity<string>()
        {
            Id = a.Codigo,
            DisplayName = a.Descripcion,
        }).AsQueryable();
    }
}

public class C22AppService : SunatCatalogBase, IC22AppService
{
    public C22AppService(CatalogData catalogData) : base(catalogData)
    {
    }
    protected override async Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var tempData = _catalogData.GetDataC22();
        return tempData.Select(a => new LookupEntity<string>()
        {
            Id = a.Codigo,
            DisplayName = a.Descripcion,
        }).AsQueryable();
    }
}

public class C23AppService : SunatCatalogBase, IC23AppService
{
    public C23AppService(CatalogData catalogData) : base(catalogData)
    {
    }
    protected override async Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var tempData = _catalogData.GetDataC23();
        return tempData.Select(a => new LookupEntity<string>()
        {
            Id = a.Codigo,
            DisplayName = a.Descripcion,
        }).AsQueryable();
    }
}

public class C24AppService : SunatCatalogBase, IC24AppService
{
    public C24AppService(CatalogData catalogData) : base(catalogData)
    {
    }
    protected override async Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var tempData = _catalogData.GetDataC24();
        return tempData.Select(a => new LookupEntity<string>()
        {
            Id = a.Codigo,
            DisplayName = a.Descripcion,
        }).AsQueryable();
    }
}

public class C26AppService : SunatCatalogBase, IC26AppService
{
    public C26AppService(CatalogData catalogData) : base(catalogData)
    {
    }
    protected override async Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var tempData = _catalogData.GetDataC26();
        return tempData.Select(a => new LookupEntity<string>()
        {
            Id = a.Codigo,
            DisplayName = a.Descripcion,
        }).AsQueryable();
    }
}

public class C27AppService : SunatCatalogBase, IC27AppService
{
    public C27AppService(CatalogData catalogData) : base(catalogData)
    {
    }
    protected override async Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var tempData = _catalogData.GetDataC27();
        return tempData.Select(a => new LookupEntity<string>()
        {
            Id = a.Codigo,
            DisplayName = a.Descripcion,
        }).AsQueryable();
    }
}

public class C51AppService : SunatCatalogBase, IC51AppService
{
    public C51AppService(CatalogData catalogData) : base(catalogData)
    {
    }
    protected override async Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var tempData = _catalogData.GetDataC51();
        return tempData.Select(a => new LookupEntity<string>()
        {
            Id = a.Codigo,
            DisplayName = a.Descripcion,
        }).AsQueryable();
    }
}

public class C52AppService : SunatCatalogBase, IC52AppService
{
    public C52AppService(CatalogData catalogData) : base(catalogData)
    {
    }
    protected override async Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var tempData = _catalogData.GetDataC52();
        return tempData.Select(a => new LookupEntity<string>()
        {
            Id = a.Codigo,
            DisplayName = a.Descripcion,
        }).AsQueryable();
    }
}

public class C53AppService : SunatCatalogBase, IC53AppService
{
    public C53AppService(CatalogData catalogData) : base(catalogData)
    {
    }
    protected override async Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var tempData = _catalogData.GetDataC53();
        return tempData.Select(a => new LookupEntity<string>()
        {
            Id = a.Codigo,
            DisplayName = a.Descripcion,
        }).AsQueryable();
    }
}

public class C54AppService : SunatCatalogBase, IC54AppService
{
    public C54AppService(CatalogData catalogData) : base(catalogData)
    {
    }
    protected override async Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var tempData = _catalogData.GetDataC54();
        return tempData.Select(a => new LookupEntity<string>()
        {
            Id = a.Codigo,
            DisplayName = a.Descripcion,
        }).AsQueryable();
    }
}

public class C55AppService : SunatCatalogBase, IC55AppService
{
    public C55AppService(CatalogData catalogData) : base(catalogData)
    {
    }
    protected override async Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var tempData = _catalogData.GetDataC55();
        return tempData.Select(a => new LookupEntity<string>()
        {
            Id = a.Codigo,
            DisplayName = a.Descripcion,
        }).AsQueryable();
    }
}

public class C56AppService : SunatCatalogBase, IC56AppService
{
    public C56AppService(CatalogData catalogData) : base(catalogData)
    {
    }
    protected override async Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var tempData = _catalogData.GetDataC56();
        return tempData.Select(a => new LookupEntity<string>()
        {
            Id = a.Codigo,
            DisplayName = a.Descripcion,
        }).AsQueryable();
    }
}

public class C57AppService : SunatCatalogBase, IC57AppService
{
    public C57AppService(CatalogData catalogData) : base(catalogData)
    {
    }
    protected override async Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var tempData = _catalogData.GetDataC57();
        return tempData.Select(a => new LookupEntity<string>()
        {
            Id = a.Codigo,
            DisplayName = a.Descripcion,
        }).AsQueryable();
    }
}

public class C58AppService : SunatCatalogBase, IC58AppService
{
    public C58AppService(CatalogData catalogData) : base(catalogData)
    {
    }
    protected override async Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var tempData = _catalogData.GetDataC58();
        return tempData.Select(a => new LookupEntity<string>()
        {
            Id = a.Codigo,
            DisplayName = a.Descripcion,
        }).AsQueryable();
    }
}

public class C59AppService : SunatCatalogBase, IC59AppService
{
    public C59AppService(CatalogData catalogData) : base(catalogData)
    {
    }
    protected override async Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var tempData = _catalogData.GetDataC59();
        return tempData.Select(a => new LookupEntity<string>()
        {
            Id = a.Codigo,
            DisplayName = a.Descripcion,
        }).AsQueryable();
    }
}

public class C60AppService : SunatCatalogBase, IC60AppService
{
    public C60AppService(CatalogData catalogData) : base(catalogData)
    {
    }
    protected override async Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var tempData = _catalogData.GetDataC60();
        return tempData.Select(a => new LookupEntity<string>()
        {
            Id = a.Codigo,
            DisplayName = a.Descripcion,
        }).AsQueryable();
    }
}

#endregion



#region Services

// esto ya deberia haber injectado el 
// esto ya deberia haber injectado el 
public abstract class SunatCatalogBase : AbstractEntitySelectAppService<string>
{
    public readonly CatalogData _catalogData;

    public SunatCatalogBase(CatalogData catalogData)
    {
        _catalogData = catalogData;
    }
}

public class CatalogData : ISingletonDependency
{
    private readonly IVirtualFileProvider _fileProvider;

    public CatalogData(IVirtualFileProvider fileProvider)
    {
        _fileProvider = fileProvider;
    }
    
    #region Functions for list catalog data(read json files and parse).

    
    public IEnumerable<CatalogViewDataObjects.C01> GetDataC01()
    {
        var strFileContent = _fileProvider.GetFileInfo(CatalogViewDataObjects.C01.F01).ReadAsString();
        return JsonConvert.DeserializeObject<List<CatalogViewDataObjects.C01>>(strFileContent);
    }
    public IEnumerable<CatalogViewDataObjects.C02> GetDataC02()
    {
        var strFileContent = _fileProvider.GetFileInfo(CatalogViewDataObjects.C02.F02).ReadAsString();
        return JsonConvert.DeserializeObject<List<CatalogViewDataObjects.C02>>(strFileContent);
    }
    public IEnumerable<CatalogViewDataObjects.C03> GetDataC03()
    {
        var strFileContent = _fileProvider.GetFileInfo(CatalogViewDataObjects.C03.F03).ReadAsString();
        return JsonConvert.DeserializeObject<List<CatalogViewDataObjects.C03>>(strFileContent);
    }
    public IEnumerable<CatalogViewDataObjects.C04> GetDataC04()
    {
        var strFileContent = _fileProvider.GetFileInfo(CatalogViewDataObjects.C04.F04).ReadAsString();
        return JsonConvert.DeserializeObject<List<CatalogViewDataObjects.C04>>(strFileContent);
    }
    public IEnumerable<CatalogViewDataObjects.C05> GetDataC05()
    {
        var strFileContent = _fileProvider.GetFileInfo(CatalogViewDataObjects.C05.F05).ReadAsString();
        return JsonConvert.DeserializeObject<List<CatalogViewDataObjects.C05>>(strFileContent);
    }
    public IEnumerable<CatalogViewDataObjects.C06> GetDataC06()
    {
        var strFileContent = _fileProvider.GetFileInfo(CatalogViewDataObjects.C06.F06).ReadAsString();
        return JsonConvert.DeserializeObject<List<CatalogViewDataObjects.C06>>(strFileContent);
    }
    public IEnumerable<CatalogViewDataObjects.C07> GetDataC07()
    {
        var strFileContent = _fileProvider.GetFileInfo(CatalogViewDataObjects.C07.F07).ReadAsString();
        return JsonConvert.DeserializeObject<List<CatalogViewDataObjects.C07>>(strFileContent);
    }
    public IEnumerable<CatalogViewDataObjects.C08> GetDataC08()
    {
        var strFileContent = _fileProvider.GetFileInfo(CatalogViewDataObjects.C08.F08).ReadAsString();
        return JsonConvert.DeserializeObject<List<CatalogViewDataObjects.C08>>(strFileContent);
    }
    public IEnumerable<CatalogViewDataObjects.C09> GetDataC09()
    {
        var strFileContent = _fileProvider.GetFileInfo(CatalogViewDataObjects.C09.F09).ReadAsString();
        return JsonConvert.DeserializeObject<List<CatalogViewDataObjects.C09>>(strFileContent);
    }
    public IEnumerable<CatalogViewDataObjects.C10> GetDataC10()
    {
        var strFileContent = _fileProvider.GetFileInfo(CatalogViewDataObjects.C10.F10).ReadAsString();
        return JsonConvert.DeserializeObject<List<CatalogViewDataObjects.C10>>(strFileContent);
    }
    public IEnumerable<CatalogViewDataObjects.C11> GetDataC11()
    {
        var strFileContent = _fileProvider.GetFileInfo(CatalogViewDataObjects.C11.F11).ReadAsString();
        return JsonConvert.DeserializeObject<List<CatalogViewDataObjects.C11>>(strFileContent);
    }
    public IEnumerable<CatalogViewDataObjects.C12> GetDataC12()
    {
        var strFileContent = _fileProvider.GetFileInfo(CatalogViewDataObjects.C12.F12).ReadAsString();
        return JsonConvert.DeserializeObject<List<CatalogViewDataObjects.C12>>(strFileContent);
    }
    public IEnumerable<CatalogViewDataObjects.C14> GetDataC14()
    {
        var strFileContent = _fileProvider.GetFileInfo(CatalogViewDataObjects.C14.F14).ReadAsString();
        return JsonConvert.DeserializeObject<List<CatalogViewDataObjects.C14>>(strFileContent);
    }
    public IEnumerable<CatalogViewDataObjects.C15> GetDataC15()
    {
        var strFileContent = _fileProvider.GetFileInfo(CatalogViewDataObjects.C15.F15).ReadAsString();
        return JsonConvert.DeserializeObject<List<CatalogViewDataObjects.C15>>(strFileContent);
    }
    public IEnumerable<CatalogViewDataObjects.C16> GetDataC16()
    {
        var strFileContent = _fileProvider.GetFileInfo(CatalogViewDataObjects.C16.F16).ReadAsString();
        return JsonConvert.DeserializeObject<List<CatalogViewDataObjects.C16>>(strFileContent);
    }
    public IEnumerable<CatalogViewDataObjects.C17> GetDataC17()
    {
        var strFileContent = _fileProvider.GetFileInfo(CatalogViewDataObjects.C17.F17).ReadAsString();
        return JsonConvert.DeserializeObject<List<CatalogViewDataObjects.C17>>(strFileContent);
    }
    public IEnumerable<CatalogViewDataObjects.C18> GetDataC18()
    {
        var strFileContent = _fileProvider.GetFileInfo(CatalogViewDataObjects.C18.F18).ReadAsString();
        return JsonConvert.DeserializeObject<List<CatalogViewDataObjects.C18>>(strFileContent);
    }
    public IEnumerable<CatalogViewDataObjects.C19> GetDataC19()
    {
        var strFileContent = _fileProvider.GetFileInfo(CatalogViewDataObjects.C19.F19).ReadAsString();
        return JsonConvert.DeserializeObject<List<CatalogViewDataObjects.C19>>(strFileContent);
    }
    public IEnumerable<CatalogViewDataObjects.C20> GetDataC20()
    {
        var strFileContent = _fileProvider.GetFileInfo(CatalogViewDataObjects.C20.F20).ReadAsString();
        return JsonConvert.DeserializeObject<List<CatalogViewDataObjects.C20>>(strFileContent);
    }
    public IEnumerable<CatalogViewDataObjects.C21> GetDataC21()
    {
        var strFileContent = _fileProvider.GetFileInfo(CatalogViewDataObjects.C21.F21).ReadAsString();
        return JsonConvert.DeserializeObject<List<CatalogViewDataObjects.C21>>(strFileContent);
    }
    public IEnumerable<CatalogViewDataObjects.C22> GetDataC22()
    {
        var strFileContent = _fileProvider.GetFileInfo(CatalogViewDataObjects.C22.F22).ReadAsString();
        return JsonConvert.DeserializeObject<List<CatalogViewDataObjects.C22>>(strFileContent);
    }
    public IEnumerable<CatalogViewDataObjects.C23> GetDataC23()
    {
        var strFileContent = _fileProvider.GetFileInfo(CatalogViewDataObjects.C23.F23).ReadAsString();
        return JsonConvert.DeserializeObject<List<CatalogViewDataObjects.C23>>(strFileContent);
    }
    public IEnumerable<CatalogViewDataObjects.C24> GetDataC24()
    {
        var strFileContent = _fileProvider.GetFileInfo(CatalogViewDataObjects.C24.F24).ReadAsString();
        return JsonConvert.DeserializeObject<List<CatalogViewDataObjects.C24>>(strFileContent);
    }
    public IEnumerable<CatalogViewDataObjects.C26> GetDataC26()
    {
        var strFileContent = _fileProvider.GetFileInfo(CatalogViewDataObjects.C26.F26).ReadAsString();
        return JsonConvert.DeserializeObject<List<CatalogViewDataObjects.C26>>(strFileContent);
    }
    public IEnumerable<CatalogViewDataObjects.C27> GetDataC27()
    {
        var strFileContent = _fileProvider.GetFileInfo(CatalogViewDataObjects.C27.F27).ReadAsString();
        return JsonConvert.DeserializeObject<List<CatalogViewDataObjects.C27>>(strFileContent);
    }
    public IEnumerable<CatalogViewDataObjects.C51> GetDataC51()
    {
        var strFileContent = _fileProvider.GetFileInfo(CatalogViewDataObjects.C51.F51).ReadAsString();
        return JsonConvert.DeserializeObject<List<CatalogViewDataObjects.C51>>(strFileContent);
    }
    public IEnumerable<CatalogViewDataObjects.C52> GetDataC52()
    {
        var strFileContent = _fileProvider.GetFileInfo(CatalogViewDataObjects.C52.F52).ReadAsString();
        return JsonConvert.DeserializeObject<List<CatalogViewDataObjects.C52>>(strFileContent);
    }
    public IEnumerable<CatalogViewDataObjects.C53> GetDataC53()
    {
        var strFileContent = _fileProvider.GetFileInfo(CatalogViewDataObjects.C53.F53).ReadAsString();
        return JsonConvert.DeserializeObject<List<CatalogViewDataObjects.C53>>(strFileContent);
    }
    public IEnumerable<CatalogViewDataObjects.C54> GetDataC54()
    {
        var strFileContent = _fileProvider.GetFileInfo(CatalogViewDataObjects.C54.F54).ReadAsString();
        return JsonConvert.DeserializeObject<List<CatalogViewDataObjects.C54>>(strFileContent);
    }
    public IEnumerable<CatalogViewDataObjects.C55> GetDataC55()
    {
        var strFileContent = _fileProvider.GetFileInfo(CatalogViewDataObjects.C55.F55).ReadAsString();
        return JsonConvert.DeserializeObject<List<CatalogViewDataObjects.C55>>(strFileContent);
    }
    public IEnumerable<CatalogViewDataObjects.C56> GetDataC56()
    {
        var strFileContent = _fileProvider.GetFileInfo(CatalogViewDataObjects.C56.F56).ReadAsString();
        return JsonConvert.DeserializeObject<List<CatalogViewDataObjects.C56>>(strFileContent);
    }
    public IEnumerable<CatalogViewDataObjects.C57> GetDataC57()
    {
        var strFileContent = _fileProvider.GetFileInfo(CatalogViewDataObjects.C57.F57).ReadAsString();
        return JsonConvert.DeserializeObject<List<CatalogViewDataObjects.C57>>(strFileContent);
    }
    public IEnumerable<CatalogViewDataObjects.C58> GetDataC58()
    {
        var strFileContent = _fileProvider.GetFileInfo(CatalogViewDataObjects.C58.F58).ReadAsString();
        return JsonConvert.DeserializeObject<List<CatalogViewDataObjects.C58>>(strFileContent);
    }
    public IEnumerable<CatalogViewDataObjects.C59> GetDataC59()
    {
        var strFileContent = _fileProvider.GetFileInfo(CatalogViewDataObjects.C59.F59).ReadAsString();
        return JsonConvert.DeserializeObject<List<CatalogViewDataObjects.C59>>(strFileContent);
    }
    public IEnumerable<CatalogViewDataObjects.C60> GetDataC60()
    {
        var strFileContent = _fileProvider.GetFileInfo(CatalogViewDataObjects.C60.F60).ReadAsString();
        return JsonConvert.DeserializeObject<List<CatalogViewDataObjects.C60>>(strFileContent);
    }

    #endregion

}

#endregion

// TODO: get common values for all

/// <summary>
/// Catalog file names and ViewData objects.
/// </summary>
public class CatalogViewDataObjects
{
    public const string Folder = "/CatalogFilesJson/";
    
    #region Catalog ViewData

    /// <summary>
    /// N° 01 - Tipo de documento
    /// </summary>
    public class C01
    {
        /// <summary>
        /// Json file name.
        /// </summary>
        public const string F01 = Folder + "01.json";
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public List<C01> GetCommons()
        {
            return new List<C01>()
            {
                
            };
        }
        public static C01 GetDefault()
        {
            return new C01
            {
                Codigo = "",
                Descripcion = "",
            };
        }
    }
    
    /// <summary>
    /// N° 02 - Tipo de monedas
    /// </summary>
    public class C02
    {
        /// <summary>
        /// Json file name.
        /// </summary>
        public const string F02 = Folder + "02.json";
        public string Currency { get; set; }
        public string CountryName { get; set; }
        public List<C02> GetCommons()
        {
            return new List<C02>()
            {
                
            };
        }
        public static C02 GetDefault()
        {
            return new C02
            {
                Currency = "",
                CountryName = "",
            };
        }
    }
    
    /// <summary>
    /// N° 03 - Tipo de unidad de medida comercial
    /// </summary>
    public class C03
    {
        /// <summary>
        /// Json file name.
        /// </summary>
        public const string F03 = Folder + "03.json";
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public List<C03> GetCommons()
        {
            return new List<C03>()
            {
                
            };
        }
        public static C03 GetDefault()
        {
            return new C03
            {
                Codigo = "",
                Descripcion = "",
            };
        }
    }
    
    /// <summary>
    /// N° 04 - Código de país
    /// </summary>
    public class C04
    {
        /// <summary>
        /// Json file name.
        /// </summary>
        public const string F04 = Folder + "04.json";
        public string A2 { get; set; }
        public string Country { get; set; }
        public List<C04> GetCommons()
        {
            return new List<C04>()
            {
                
            };
        }
        public static C04 GetDefault()
        {
            return new C04
            {
                A2 = "",
                Country = "",
            };
        }
    }
    
    /// <summary>
    /// N° 05 - Código de tipos de tributos y otros conceptos
    /// </summary>
    public class C05
    {
        /// <summary>
        /// Json file name.
        /// </summary>
        public const string F05 = Folder + "05.json";
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public List<C05> GetCommons()
        {
            return new List<C05>()
            {
                
            };
        }
        public static C05 GetDefault()
        {
            return new C05
            {
                Codigo = "",
                Descripcion = "",
            };
        }
    }
    
    /// <summary>
    /// N° 06 - Código de tipo de documento de identidad
    /// </summary>
    public class C06
    {
        /// <summary>
        /// Json file name.
        /// </summary>
        public const string F06 = Folder + "06.json";
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public List<C06> GetCommons()
        {
            return new List<C06>()
            {
                
            };
        }
        public static C06 GetDefault()
        {
            return new C06
            {
                Codigo = "",
                Descripcion = "",
            };
        }
    }
    
    /// <summary>
    /// N° 07 - Código de tipo de afectación del IGV
    /// </summary>
    public class C07
    {
        /// <summary>
        /// Json file name.
        /// </summary>
        public const string F07 = Folder + "07.json";
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public List<C07> GetCommons()
        {
            return new List<C07>()
            {
                
            };
        }
        public static C07 GetDefault()
        {
            return new C07
            {
                Codigo = "",
                Descripcion = "",
            };
        }
    }
    
    /// <summary>
    /// N° 08 - Código de tipos de sistema de cálculo del ISC
    /// </summary>
    public class C08
    {
        /// <summary>
        /// Json file name.
        /// </summary>
        public const string F08 = Folder + "08.json";
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public List<C08> GetCommons()
        {
            return new List<C08>()
            {
                
            };
        }
        public static C08 GetDefault()
        {
            return new C08
            {
                Codigo = "",
                Descripcion = "",
            };
        }
    }
    
    /// <summary>
    /// N° 09 - Códigos de tipo de nota de crédito electrónica
    /// </summary>
    public class C09
    {
        /// <summary>
        /// Json file name.
        /// </summary>
        public const string F09 = Folder + "09.json";
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public List<C09> GetCommons()
        {
            return new List<C09>()
            {
                
            };
        }
        public static C09 GetDefault()
        {
            return new C09
            {
                Codigo = "",
                Descripcion = "",
            };
        }
    }
    
    /// <summary>
    /// N° 10 - Códigos de tipo de nota de débito electrónica
    /// </summary>
    public class C10
    {
        /// <summary>
        /// Json file name.
        /// </summary>
        public const string F10 = Folder + "10.json";
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public List<C10> GetCommons()
        {
            return new List<C10>()
            {
                
            };
        }
        public static C10 GetDefault()
        {
            return new C10
            {
                Codigo = "",
                Descripcion = "",
            };
        }
    }
    
    /// <summary>
    /// N° 11 - Códigos de tipo de valor de venta (Resumen diario de boletas y notas)
    /// </summary>
    public class C11
    {
        /// <summary>
        /// Json file name.
        /// </summary>
        public const string F11 = Folder + "11.json";
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public List<C11> GetCommons()
        {
            return new List<C11>()
            {
                
            };
        }
        public static C11 GetDefault()
        {
            return new C11
            {
                Codigo = "",
                Descripcion = "",
            };
        }
    }
    
    /// <summary>
    /// N° 12 - Código de documentos relacionados tributarios
    /// </summary>
    public class C12
    {
        /// <summary>
        /// Json file name.
        /// </summary>
        public const string F12 = Folder + "12.json";
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public List<C12> GetCommons()
        {
            return new List<C12>()
            {
                
            };
        }
        public static C12 GetDefault()
        {
            return new C12
            {
                Codigo = "",
                Descripcion = "",
            };
        }
    }
    
    /// <summary>
    /// N° 14 - Código de otros conceptos tributarios
    /// </summary>
    public class C14
    {
        /// <summary>
        /// Json file name.
        /// </summary>
        public const string F14 = Folder + "14.json";
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public List<C14> GetCommons()
        {
            return new List<C14>()
            {
                
            };
        }
        public static C14 GetDefault()
        {
            return new C14
            {
                Codigo = "",
                Descripcion = "",
            };
        }
    }
    
    /// <summary>
    /// N° 15 - Códigos de elementos adicionales en la factura y boleta electrónica
    /// </summary>
    public class C15
    {
        /// <summary>
        /// Json file name.
        /// </summary>
        public const string F15 = Folder + "15.json";
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public List<C15> GetCommons()
        {
            return new List<C15>()
            {
                
            };
        }
        public static C15 GetDefault()
        {
            return new C15
            {
                Codigo = "",
                Descripcion = "",
            };
        }
    }
    
    /// <summary>
    /// N° 16 - Código de tipo de precio de venta unitario
    /// </summary>
    public class C16
    {
        /// <summary>
        /// Json file name.
        /// </summary>
        public const string F16 = Folder + "16.json";
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public List<C16> GetCommons()
        {
            return new List<C16>()
            {
                
            };
        }
        public static C16 GetDefault()
        {
            return new C16
            {
                Codigo = "",
                Descripcion = "",
            };
        }
    }
    
    /// <summary>
    /// N° 17 - Código de tipo de operación
    /// </summary>
    public class C17
    {
        /// <summary>
        /// Json file name.
        /// </summary>
        public const string F17 = Folder + "17.json";
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public List<C17> GetCommons()
        {
            return new List<C17>()
            {
                
            };
        }
        public static C17 GetDefault()
        {
            return new C17
            {
                Codigo = "",
                Descripcion = "",
            };
        }
    }
    
    /// <summary>
    /// N° 18 - Código de modalidad de transporte
    /// </summary>
    public class C18
    {
        /// <summary>
        /// Json file name.
        /// </summary>
        public const string F18 = Folder + "18.json";
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public List<C18> GetCommons()
        {
            return new List<C18>()
            {
                
            };
        }
        public static C18 GetDefault()
        {
            return new C18
            {
                Codigo = "",
                Descripcion = "",
            };
        }
    }
    
    /// <summary>
    /// N° 19 - Código de estado del ítem (resumen diario)
    /// </summary>
    public class C19
    {
        /// <summary>
        /// Json file name.
        /// </summary>
        public const string F19 = Folder + "19.json";
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public List<C19> GetCommons()
        {
            return new List<C19>()
            {
                
            };
        }
        public static C19 GetDefault()
        {
            return new C19
            {
                Codigo = "",
                Descripcion = "",
            };
        }
    }
    
    /// <summary>
    /// N° 20 - Código de motivo de traslado
    /// </summary>
    public class C20
    {
        /// <summary>
        /// Json file name.
        /// </summary>
        public const string F20 = Folder + "20.json";
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public List<C20> GetCommons()
        {
            return new List<C20>()
            {
                
            };
        }
        public static C20 GetDefault()
        {
            return new C20
            {
                Codigo = "",
                Descripcion = "",
            };
        }
    }
    
    /// <summary>
    /// N° 21 - Código de documentos relacionados (sólo guía de remisión electrónica)
    /// </summary>
    public class C21
    {
        /// <summary>
        /// Json file name.
        /// </summary>
        public const string F21 = Folder + "21.json";
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public List<C21> GetCommons()
        {
            return new List<C21>()
            {
                
            };
        }
        public static C21 GetDefault()
        {
            return new C21
            {
                Codigo = "",
                Descripcion = "",
            };
        }
    }
    
    /// <summary>
    /// N° 22 - Código de regimen de percepciones
    /// </summary>
    public class C22
    {
        /// <summary>
        /// Json file name.
        /// </summary>
        public const string F22 = Folder + "22.json";
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public List<C22> GetCommons()
        {
            return new List<C22>()
            {
                
            };
        }
        public static C22 GetDefault()
        {
            return new C22
            {
                Codigo = "",
                Descripcion = "",
            };
        }
    }
    
    /// <summary>
    /// N° 23 - Código de regimen de retenciones
    /// </summary>
    public class C23
    {
        /// <summary>
        /// Json file name.
        /// </summary>
        public const string F23 = Folder + "23.json";
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public List<C23> GetCommons()
        {
            return new List<C23>()
            {
                
            };
        }
        public static C23 GetDefault()
        {
            return new C23
            {
                Codigo = "",
                Descripcion = "",
            };
        }
    }
    
    /// <summary>
    /// N° 24 - Código de tarifa de servicios públicos
    /// </summary>
    public class C24
    {
        /// <summary>
        /// Json file name.
        /// </summary>
        public const string F24 = Folder + "24.json";
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public List<C24> GetCommons()
        {
            return new List<C24>()
            {
                
            };
        }
        public static C24 GetDefault()
        {
            return new C24
            {
                Codigo = "",
                Descripcion = "",
            };
        }
    }
    
    /// <summary>
    /// N° 26 - Tipo de préstamo (créditos hipotecarios)
    /// </summary>
    public class C26
    {
        /// <summary>
        /// Json file name.
        /// </summary>
        public const string F26 = Folder + "26.json";
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public List<C26> GetCommons()
        {
            return new List<C26>()
            {
                
            };
        }
        public static C26 GetDefault()
        {
            return new C26
            {
                Codigo = "",
                Descripcion = "",
            };
        }
    }
    
    /// <summary>
    /// N° 27 - Indicador de primera vivienda
    /// </summary>
    public class C27
    {
        /// <summary>
        /// Json file name.
        /// </summary>
        public const string F27 = Folder + "27.json";
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public List<C27> GetCommons()
        {
            return new List<C27>()
            {
                
            };
        }
        public static C27 GetDefault()
        {
            return new C27
            {
                Codigo = "",
                Descripcion = "",
            };
        }
    }
    
    /// <summary>
    /// N° 51 - Código de tipo de operación
    /// </summary>
    public class C51
    {
        /// <summary>
        /// Json file name.
        /// </summary>
        public const string F51 = Folder + "51.json";
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public List<C51> GetCommons()
        {
            return new List<C51>()
            {
                
            };
        }
        public static C51 GetDefault()
        {
            return new C51
            {
                Codigo = "",
                Descripcion = "",
            };
        }
    }
    
    /// <summary>
    /// N° 52 - Códigos de leyendas
    /// </summary>
    public class C52
    {
        /// <summary>
        /// Json file name.
        /// </summary>
        public const string F52 = Folder + "52.json";
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public List<C52> GetCommons()
        {
            return new List<C52>()
            {
                
            };
        }
        public static C52 GetDefault()
        {
            return new C52
            {
                Codigo = "",
                Descripcion = "",
            };
        }
    }
    
    /// <summary>
    /// N° 53 - Códigos de cargos, descuentos y otras deducciones
    /// </summary>
    public class C53
    {
        /// <summary>
        /// Json file name.
        /// </summary>
        public const string F53 = Folder + "53.json";
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public List<C53> GetCommons()
        {
            return new List<C53>()
            {
                
            };
        }
        public static C53 GetDefault()
        {
            return new C53
            {
                Codigo = "",
                Descripcion = "",
            };
        }
    }
    
    /// <summary>
    /// N° 54 - Códigos de bienes y servicios sujetos a detracciones
    /// </summary>
    public class C54
    {
        /// <summary>
        /// Json file name.
        /// </summary>
        public const string F54 = Folder + "54.json";
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public List<C54> GetCommons()
        {
            return new List<C54>()
            {
                
            };
        }
        public static C54 GetDefault()
        {
            return new C54
            {
                Codigo = "",
                Descripcion = "",
            };
        }
    }
    
    /// <summary>
    /// N° 55 - Código de identificación del concepto tributario
    /// </summary>
    public class C55
    {
        /// <summary>
        /// Json file name.
        /// </summary>
        public const string F55 = Folder + "55.json";
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public List<C55> GetCommons()
        {
            return new List<C55>()
            {
                
            };
        }
        public static C55 GetDefault()
        {
            return new C55
            {
                Codigo = "",
                Descripcion = "",
            };
        }
    }
    
    /// <summary>
    /// N° 56 - Código de tipo de servicio público
    /// </summary>
    public class C56
    {
        /// <summary>
        /// Json file name.
        /// </summary>
        public const string F56 = Folder + "56.json";
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public List<C56> GetCommons()
        {
            return new List<C56>()
            {
                
            };
        }
        public static C56 GetDefault()
        {
            return new C56
            {
                Codigo = "",
                Descripcion = "",
            };
        }
    }
    
    /// <summary>
    /// N° 57 - Código de tipo de servicio públicos - telecomunicaciones
    /// </summary>
    public class C57
    {
        /// <summary>
        /// Json file name.
        /// </summary>
        public const string F57 = Folder + "57.json";
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public List<C57> GetCommons()
        {
            return new List<C57>()
            {
                
            };
        }
        public static C57 GetDefault()
        {
            return new C57
            {
                Codigo = "",
                Descripcion = "",
            };
        }
    }
    
    /// <summary>
    /// N° 58 - Código de tipo de medidor (recibo de luz)
    /// </summary>
    public class C58
    {
        /// <summary>
        /// Json file name.
        /// </summary>
        public const string F58 = Folder + "58.json";
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public List<C58> GetCommons()
        {
            return new List<C58>()
            {
                
            };
        }
        public static C58 GetDefault()
        {
            return new C58
            {
                Codigo = "",
                Descripcion = "",
            };
        }
    }
    
    /// <summary>
    /// N° 59 - Medios de Pago
    /// </summary>
    public class C59
    {
        /// <summary>
        /// Json file name.
        /// </summary>
        public const string F59 = Folder + "59.json";
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public List<C59> GetCommons()
        {
            return new List<C59>()
            {
                
            };
        }
        public static C59 GetDefault()
        {
            return new C59
            {
                Codigo = "",
                Descripcion = "",
            };
        }
    }
    
    /// <summary>
    /// N° 60 - Código de tipo de dirección
    /// </summary>
    public class C60
    {
        /// <summary>
        /// Json file name.
        /// </summary>
        public const string F60 = Folder + "60.json";
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public List<C60> GetCommons()
        {
            return new List<C60>()
            {
                
            };
        }
        public static C60 GetDefault()
        {
            return new C60
            {
                Codigo = "",
                Descripcion = "",
            };
        }
    }
    
    #endregion
    
    /// <summary>
    /// Catalog names.
    /// </summary>
    public Dictionary<string, string> Catalogs = new Dictionary<string, string>()
    {
        {C01.F01,"N° 01 - Tipo de documento"},
        {C02.F02,"N° 02 - Tipo de monedas"},
        {C03.F03,"N° 03 - Tipo de unidad de medida comercial"},
        {C04.F04,"N° 04 - Código de país"},
        {C05.F05,"N° 05 - Código de tipos de tributos y otros conceptos"},
        {C06.F06,"N° 06 - Código de tipo de documento de identidad"},
        {C07.F07,"N° 07 - Código de tipo de afectación del IGV"},
        {C08.F08,"N° 08 - Código de tipos de sistema de cálculo del ISC"},
        {C09.F09,"N° 09 - Códigos de tipo de nota de crédito electrónica"},
        {C10.F10,"N° 10 - Códigos de tipo de nota de débito electrónica"},
        {C11.F11,"N° 11 - Códigos de tipo de valor de venta (Resumen diario de boletas y notas)"},
        {C12.F12,"N° 12 - Código de documentos relacionados tributarios"},
        {C14.F14,"N° 14 - Código de otros conceptos tributarios"},
        {C15.F15,"N° 15 - Códigos de elementos adicionales en la factura y boleta electrónica"},
        {C16.F16,"N° 16 - Código de tipo de precio de venta unitario"},
        {C17.F17,"N° 17 - Código de tipo de operación"},
        {C18.F18,"N° 18 - Código de modalidad de transporte"},
        {C19.F19,"N° 19 - Código de estado del ítem (resumen diario)"},
        {C20.F20,"N° 20 - Código de motivo de traslado"},
        {C21.F21,"N° 21 - Código de documentos relacionados (sólo guía de remisión electrónica)"},
        {C22.F22,"N° 22 - Código de regimen de percepciones"},
        {C23.F23,"N° 23 - Código de regimen de retenciones"},
        {C24.F24,"N° 24 - Código de tarifa de servicios públicos"},
        {C26.F26,"N° 26 - Tipo de préstamo (créditos hipotecarios)"},
        {C27.F27,"N° 27 - Indicador de primera vivienda"},
        {C51.F51,"N° 51 - Código de tipo de operación"},
        {C52.F52,"N° 52 - Códigos de leyendas"},
        {C53.F53,"N° 53 - Códigos de cargos, descuentos y otras deducciones"},
        {C54.F54,"N° 54 - Códigos de bienes y servicios sujetos a detracciones"},
        {C55.F55,"N° 55 - Código de identificación del concepto tributario"},
        {C56.F56,"N° 56 - Código de tipo de servicio público"},
        {C57.F57,"N° 57 - Código de tipo de servicio públicos - telecomunicaciones"},
        {C58.F58,"N° 58 - Código de tipo de medidor (recibo de luz)"},
        {C59.F59,"N° 59 - Medios de Pago"},
        {C60.F60,"N° 60 - Código de tipo de dirección"},
    };
}

