using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;
using Volo.Abp.DependencyInjection;
using Volo.Abp.VirtualFileSystem;
using Washyn.Abp.Select2;

namespace Washyn.Sunat.Catalog;

#region Catalog data provider

// esto ya deberia haber injectado el 
// esto ya deberia haber injectado el 
public abstract class SunatCatalogBase : AbstractEntitySelectAppService<string>
{
    public readonly CatalogDataProvider CatalogDataProvider;

    public SunatCatalogBase(CatalogDataProvider catalogDataProvider)
    {
        CatalogDataProvider = catalogDataProvider;
    }
}

public class CatalogDataProvider : ISingletonDependency
{
    private readonly IVirtualFileProvider _fileProvider;

    public CatalogDataProvider(IVirtualFileProvider fileProvider)
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
