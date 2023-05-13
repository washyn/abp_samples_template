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
    public C01AppService(CatalogDataProvider catalogDataProvider) : base(catalogDataProvider)
    {
    }
    protected override async Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var tempData = CatalogDataProvider.GetDataC01();
        return tempData.Select(a => new LookupEntity<string>()
        {
            Id = a.Codigo,
            DisplayName = a.Descripcion,
        }).AsQueryable();
    }
}

public class C02AppService : SunatCatalogBase, IC02AppService
{
    public C02AppService(CatalogDataProvider catalogDataProvider) : base(catalogDataProvider)
    {
    }
    protected override async Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var tempData = CatalogDataProvider.GetDataC02();
        return tempData.Select(a => new LookupEntity<string>()
        {
            Id = a.Currency,
            DisplayName = a.CountryName,
        }).AsQueryable();
    }
}

public class C03AppService : SunatCatalogBase, IC03AppService
{
    public C03AppService(CatalogDataProvider catalogDataProvider) : base(catalogDataProvider)
    {
    }
    protected override async Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var tempData = CatalogDataProvider.GetDataC03();
        return tempData.Select(a => new LookupEntity<string>()
        {
            Id = a.Codigo,
            DisplayName = a.Descripcion,
        }).AsQueryable();
    }
}

public class C04AppService : SunatCatalogBase, IC04AppService
{
    public C04AppService(CatalogDataProvider catalogDataProvider) : base(catalogDataProvider)
    {
    }
    protected override async Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var tempData = CatalogDataProvider.GetDataC04();
        return tempData.Select(a => new LookupEntity<string>()
        {
            Id = a.A2,
            DisplayName = a.Country,
        }).AsQueryable();
    }
}

public class C05AppService : SunatCatalogBase, IC05AppService
{
    public C05AppService(CatalogDataProvider catalogDataProvider) : base(catalogDataProvider)
    {
    }
    protected override async Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var tempData = CatalogDataProvider.GetDataC05();
        return tempData.Select(a => new LookupEntity<string>()
        {
            Id = a.Codigo,
            DisplayName = a.Descripcion,
        }).AsQueryable();
    }
}

public class C06AppService : SunatCatalogBase, IC06AppService
{
    public C06AppService(CatalogDataProvider catalogDataProvider) : base(catalogDataProvider)
    {
    }
    protected override async Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var tempData = CatalogDataProvider.GetDataC06();
        return tempData.Select(a => new LookupEntity<string>()
        {
            Id = a.Codigo,
            DisplayName = a.Descripcion,
        }).AsQueryable();
    }
}

public class C07AppService : SunatCatalogBase, IC07AppService
{
    public C07AppService(CatalogDataProvider catalogDataProvider) : base(catalogDataProvider)
    {
    }
    protected override async Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var tempData = CatalogDataProvider.GetDataC07();
        return tempData.Select(a => new LookupEntity<string>()
        {
            Id = a.Codigo,
            DisplayName = a.Descripcion,
        }).AsQueryable();
    }
}

public class C08AppService : SunatCatalogBase, IC08AppService
{
    public C08AppService(CatalogDataProvider catalogDataProvider) : base(catalogDataProvider)
    {
    }
    protected override async Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var tempData = CatalogDataProvider.GetDataC08();
        return tempData.Select(a => new LookupEntity<string>()
        {
            Id = a.Codigo,
            DisplayName = a.Descripcion,
        }).AsQueryable();
    }
}

public class C09AppService : SunatCatalogBase, IC09AppService
{
    public C09AppService(CatalogDataProvider catalogDataProvider) : base(catalogDataProvider)
    {
    }
    protected override async Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var tempData = CatalogDataProvider.GetDataC09();
        return tempData.Select(a => new LookupEntity<string>()
        {
            Id = a.Codigo,
            DisplayName = a.Descripcion,
        }).AsQueryable();
    }
}

public class C10AppService : SunatCatalogBase, IC10AppService
{
    public C10AppService(CatalogDataProvider catalogDataProvider) : base(catalogDataProvider)
    {
    }
    protected override async Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var tempData = CatalogDataProvider.GetDataC10();
        return tempData.Select(a => new LookupEntity<string>()
        {
            Id = a.Codigo,
            DisplayName = a.Descripcion,
        }).AsQueryable();
    }
}

public class C11AppService : SunatCatalogBase, IC11AppService
{
    public C11AppService(CatalogDataProvider catalogDataProvider) : base(catalogDataProvider)
    {
    }
    protected override async Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var tempData = CatalogDataProvider.GetDataC11();
        return tempData.Select(a => new LookupEntity<string>()
        {
            Id = a.Codigo,
            DisplayName = a.Descripcion,
        }).AsQueryable();
    }
}

public class C12AppService : SunatCatalogBase, IC12AppService
{
    public C12AppService(CatalogDataProvider catalogDataProvider) : base(catalogDataProvider)
    {
    }
    protected override async Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var tempData = CatalogDataProvider.GetDataC12();
        return tempData.Select(a => new LookupEntity<string>()
        {
            Id = a.Codigo,
            DisplayName = a.Descripcion,
        }).AsQueryable();
    }
}

public class C14AppService : SunatCatalogBase, IC14AppService
{
    public C14AppService(CatalogDataProvider catalogDataProvider) : base(catalogDataProvider)
    {
    }
    protected override async Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var tempData = CatalogDataProvider.GetDataC14();
        return tempData.Select(a => new LookupEntity<string>()
        {
            Id = a.Codigo,
            DisplayName = a.Descripcion,
        }).AsQueryable();
    }
}

public class C15AppService : SunatCatalogBase, IC15AppService
{
    public C15AppService(CatalogDataProvider catalogDataProvider) : base(catalogDataProvider)
    {
    }
    protected override async Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var tempData = CatalogDataProvider.GetDataC15();
        return tempData.Select(a => new LookupEntity<string>()
        {
            Id = a.Codigo,
            DisplayName = a.Descripcion,
        }).AsQueryable();
    }
}

public class C16AppService : SunatCatalogBase, IC16AppService
{
    public C16AppService(CatalogDataProvider catalogDataProvider) : base(catalogDataProvider)
    {
    }
    protected override async Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var tempData = CatalogDataProvider.GetDataC16();
        return tempData.Select(a => new LookupEntity<string>()
        {
            Id = a.Codigo,
            DisplayName = a.Descripcion,
        }).AsQueryable();
    }
}

public class C17AppService : SunatCatalogBase, IC17AppService
{
    public C17AppService(CatalogDataProvider catalogDataProvider) : base(catalogDataProvider)
    {
    }
    protected override async Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var tempData = CatalogDataProvider.GetDataC17();
        return tempData.Select(a => new LookupEntity<string>()
        {
            Id = a.Codigo,
            DisplayName = a.Descripcion,
        }).AsQueryable();
    }
}

public class C18AppService : SunatCatalogBase, IC18AppService
{
    public C18AppService(CatalogDataProvider catalogDataProvider) : base(catalogDataProvider)
    {
    }
    protected override async Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var tempData = CatalogDataProvider.GetDataC18();
        return tempData.Select(a => new LookupEntity<string>()
        {
            Id = a.Codigo,
            DisplayName = a.Descripcion,
        }).AsQueryable();
    }
}

public class C19AppService : SunatCatalogBase, IC19AppService
{
    public C19AppService(CatalogDataProvider catalogDataProvider) : base(catalogDataProvider)
    {
    }
    protected override async Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var tempData = CatalogDataProvider.GetDataC19();
        return tempData.Select(a => new LookupEntity<string>()
        {
            Id = a.Codigo,
            DisplayName = a.Descripcion,
        }).AsQueryable();
    }
}

public class C20AppService : SunatCatalogBase, IC20AppService
{
    public C20AppService(CatalogDataProvider catalogDataProvider) : base(catalogDataProvider)
    {
    }
    protected override async Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var tempData = CatalogDataProvider.GetDataC20();
        return tempData.Select(a => new LookupEntity<string>()
        {
            Id = a.Codigo,
            DisplayName = a.Descripcion,
        }).AsQueryable();
    }
}

public class C21AppService : SunatCatalogBase, IC21AppService
{
    public C21AppService(CatalogDataProvider catalogDataProvider) : base(catalogDataProvider)
    {
    }
    protected override async Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var tempData = CatalogDataProvider.GetDataC21();
        return tempData.Select(a => new LookupEntity<string>()
        {
            Id = a.Codigo,
            DisplayName = a.Descripcion,
        }).AsQueryable();
    }
}

public class C22AppService : SunatCatalogBase, IC22AppService
{
    public C22AppService(CatalogDataProvider catalogDataProvider) : base(catalogDataProvider)
    {
    }
    protected override async Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var tempData = CatalogDataProvider.GetDataC22();
        return tempData.Select(a => new LookupEntity<string>()
        {
            Id = a.Codigo,
            DisplayName = a.Descripcion,
        }).AsQueryable();
    }
}

public class C23AppService : SunatCatalogBase, IC23AppService
{
    public C23AppService(CatalogDataProvider catalogDataProvider) : base(catalogDataProvider)
    {
    }
    protected override async Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var tempData = CatalogDataProvider.GetDataC23();
        return tempData.Select(a => new LookupEntity<string>()
        {
            Id = a.Codigo,
            DisplayName = a.Descripcion,
        }).AsQueryable();
    }
}

public class C24AppService : SunatCatalogBase, IC24AppService
{
    public C24AppService(CatalogDataProvider catalogDataProvider) : base(catalogDataProvider)
    {
    }
    protected override async Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var tempData = CatalogDataProvider.GetDataC24();
        return tempData.Select(a => new LookupEntity<string>()
        {
            Id = a.Codigo,
            DisplayName = a.Descripcion,
        }).AsQueryable();
    }
}

public class C26AppService : SunatCatalogBase, IC26AppService
{
    public C26AppService(CatalogDataProvider catalogDataProvider) : base(catalogDataProvider)
    {
    }
    protected override async Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var tempData = CatalogDataProvider.GetDataC26();
        return tempData.Select(a => new LookupEntity<string>()
        {
            Id = a.Codigo,
            DisplayName = a.Descripcion,
        }).AsQueryable();
    }
}

public class C27AppService : SunatCatalogBase, IC27AppService
{
    public C27AppService(CatalogDataProvider catalogDataProvider) : base(catalogDataProvider)
    {
    }
    protected override async Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var tempData = CatalogDataProvider.GetDataC27();
        return tempData.Select(a => new LookupEntity<string>()
        {
            Id = a.Codigo,
            DisplayName = a.Descripcion,
        }).AsQueryable();
    }
}

public class C51AppService : SunatCatalogBase, IC51AppService
{
    public C51AppService(CatalogDataProvider catalogDataProvider) : base(catalogDataProvider)
    {
    }
    protected override async Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var tempData = CatalogDataProvider.GetDataC51();
        return tempData.Select(a => new LookupEntity<string>()
        {
            Id = a.Codigo,
            DisplayName = a.Descripcion,
        }).AsQueryable();
    }
}

public class C52AppService : SunatCatalogBase, IC52AppService
{
    public C52AppService(CatalogDataProvider catalogDataProvider) : base(catalogDataProvider)
    {
    }
    protected override async Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var tempData = CatalogDataProvider.GetDataC52();
        return tempData.Select(a => new LookupEntity<string>()
        {
            Id = a.Codigo,
            DisplayName = a.Descripcion,
        }).AsQueryable();
    }
}

public class C53AppService : SunatCatalogBase, IC53AppService
{
    public C53AppService(CatalogDataProvider catalogDataProvider) : base(catalogDataProvider)
    {
    }
    protected override async Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var tempData = CatalogDataProvider.GetDataC53();
        return tempData.Select(a => new LookupEntity<string>()
        {
            Id = a.Codigo,
            DisplayName = a.Descripcion,
        }).AsQueryable();
    }
}

public class C54AppService : SunatCatalogBase, IC54AppService
{
    public C54AppService(CatalogDataProvider catalogDataProvider) : base(catalogDataProvider)
    {
    }
    protected override async Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var tempData = CatalogDataProvider.GetDataC54();
        return tempData.Select(a => new LookupEntity<string>()
        {
            Id = a.Codigo,
            DisplayName = a.Descripcion,
        }).AsQueryable();
    }
}

public class C55AppService : SunatCatalogBase, IC55AppService
{
    public C55AppService(CatalogDataProvider catalogDataProvider) : base(catalogDataProvider)
    {
    }
    protected override async Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var tempData = CatalogDataProvider.GetDataC55();
        return tempData.Select(a => new LookupEntity<string>()
        {
            Id = a.Codigo,
            DisplayName = a.Descripcion,
        }).AsQueryable();
    }
}

public class C56AppService : SunatCatalogBase, IC56AppService
{
    public C56AppService(CatalogDataProvider catalogDataProvider) : base(catalogDataProvider)
    {
    }
    protected override async Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var tempData = CatalogDataProvider.GetDataC56();
        return tempData.Select(a => new LookupEntity<string>()
        {
            Id = a.Codigo,
            DisplayName = a.Descripcion,
        }).AsQueryable();
    }
}

public class C57AppService : SunatCatalogBase, IC57AppService
{
    public C57AppService(CatalogDataProvider catalogDataProvider) : base(catalogDataProvider)
    {
    }
    protected override async Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var tempData = CatalogDataProvider.GetDataC57();
        return tempData.Select(a => new LookupEntity<string>()
        {
            Id = a.Codigo,
            DisplayName = a.Descripcion,
        }).AsQueryable();
    }
}

public class C58AppService : SunatCatalogBase, IC58AppService
{
    public C58AppService(CatalogDataProvider catalogDataProvider) : base(catalogDataProvider)
    {
    }
    protected override async Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var tempData = CatalogDataProvider.GetDataC58();
        return tempData.Select(a => new LookupEntity<string>()
        {
            Id = a.Codigo,
            DisplayName = a.Descripcion,
        }).AsQueryable();
    }
}

public class C59AppService : SunatCatalogBase, IC59AppService
{
    public C59AppService(CatalogDataProvider catalogDataProvider) : base(catalogDataProvider)
    {
    }
    protected override async Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var tempData = CatalogDataProvider.GetDataC59();
        return tempData.Select(a => new LookupEntity<string>()
        {
            Id = a.Codigo,
            DisplayName = a.Descripcion,
        }).AsQueryable();
    }
}

public class C60AppService : SunatCatalogBase, IC60AppService
{
    public C60AppService(CatalogDataProvider catalogDataProvider) : base(catalogDataProvider)
    {
    }
    protected override async Task<IQueryable<LookupEntity<string>>> CreateSelectQueryAsync()
    {
        var tempData = CatalogDataProvider.GetDataC60();
        return tempData.Select(a => new LookupEntity<string>()
        {
            Id = a.Codigo,
            DisplayName = a.Descripcion,
        }).AsQueryable();
    }
}

#endregion