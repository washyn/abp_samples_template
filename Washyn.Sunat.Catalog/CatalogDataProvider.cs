using System.Collections.Generic;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;
using Volo.Abp.DependencyInjection;
using Volo.Abp.VirtualFileSystem;
using Washyn.Abp.Select2;

namespace Washyn.Sunat.Catalog
{

    #region Catalog data provider

    public class CatalogDataProvider : ISingletonDependency
    {
        private readonly IVirtualFileProvider _fileProvider;

        public CatalogDataProvider(IVirtualFileProvider fileProvider)
        {
            _fileProvider = fileProvider;
        }

        #region Functions for list catalog data(read json files and parse).


        public IEnumerable<C01> GetDataC01()
        {
            var strFileContent = _fileProvider.GetFileInfo(C01.F01).ReadAsString();
            return JsonConvert.DeserializeObject<List<C01>>(strFileContent);
        }
        public IEnumerable<C02> GetDataC02()
        {
            var strFileContent = _fileProvider.GetFileInfo(C02.F02).ReadAsString();
            return JsonConvert.DeserializeObject<List<C02>>(strFileContent);
        }
        public IEnumerable<C03> GetDataC03()
        {
            var strFileContent = _fileProvider.GetFileInfo(C03.F03).ReadAsString();
            return JsonConvert.DeserializeObject<List<C03>>(strFileContent);
        }
        public IEnumerable<C04> GetDataC04()
        {
            var strFileContent = _fileProvider.GetFileInfo(C04.F04).ReadAsString();
            return JsonConvert.DeserializeObject<List<C04>>(strFileContent);
        }
        public IEnumerable<C05> GetDataC05()
        {
            var strFileContent = _fileProvider.GetFileInfo(C05.F05).ReadAsString();
            return JsonConvert.DeserializeObject<List<C05>>(strFileContent);
        }
        public IEnumerable<C06> GetDataC06()
        {
            var strFileContent = _fileProvider.GetFileInfo(C06.F06).ReadAsString();
            return JsonConvert.DeserializeObject<List<C06>>(strFileContent);
        }
        public IEnumerable<C07> GetDataC07()
        {
            var strFileContent = _fileProvider.GetFileInfo(C07.F07).ReadAsString();
            return JsonConvert.DeserializeObject<List<C07>>(strFileContent);
        }
        public IEnumerable<C08> GetDataC08()
        {
            var strFileContent = _fileProvider.GetFileInfo(C08.F08).ReadAsString();
            return JsonConvert.DeserializeObject<List<C08>>(strFileContent);
        }
        public IEnumerable<C09> GetDataC09()
        {
            var strFileContent = _fileProvider.GetFileInfo(C09.F09).ReadAsString();
            return JsonConvert.DeserializeObject<List<C09>>(strFileContent);
        }
        public IEnumerable<C10> GetDataC10()
        {
            var strFileContent = _fileProvider.GetFileInfo(C10.F10).ReadAsString();
            return JsonConvert.DeserializeObject<List<C10>>(strFileContent);
        }
        public IEnumerable<C11> GetDataC11()
        {
            var strFileContent = _fileProvider.GetFileInfo(C11.F11).ReadAsString();
            return JsonConvert.DeserializeObject<List<C11>>(strFileContent);
        }
        public IEnumerable<C12> GetDataC12()
        {
            var strFileContent = _fileProvider.GetFileInfo(C12.F12).ReadAsString();
            return JsonConvert.DeserializeObject<List<C12>>(strFileContent);
        }
        public IEnumerable<C14> GetDataC14()
        {
            var strFileContent = _fileProvider.GetFileInfo(C14.F14).ReadAsString();
            return JsonConvert.DeserializeObject<List<C14>>(strFileContent);
        }
        public IEnumerable<C15> GetDataC15()
        {
            var strFileContent = _fileProvider.GetFileInfo(C15.F15).ReadAsString();
            return JsonConvert.DeserializeObject<List<C15>>(strFileContent);
        }
        public IEnumerable<C16> GetDataC16()
        {
            var strFileContent = _fileProvider.GetFileInfo(C16.F16).ReadAsString();
            return JsonConvert.DeserializeObject<List<C16>>(strFileContent);
        }
        public IEnumerable<C17> GetDataC17()
        {
            var strFileContent = _fileProvider.GetFileInfo(C17.F17).ReadAsString();
            return JsonConvert.DeserializeObject<List<C17>>(strFileContent);
        }
        public IEnumerable<C18> GetDataC18()
        {
            var strFileContent = _fileProvider.GetFileInfo(C18.F18).ReadAsString();
            return JsonConvert.DeserializeObject<List<C18>>(strFileContent);
        }
        public IEnumerable<C19> GetDataC19()
        {
            var strFileContent = _fileProvider.GetFileInfo(C19.F19).ReadAsString();
            return JsonConvert.DeserializeObject<List<C19>>(strFileContent);
        }
        public IEnumerable<C20> GetDataC20()
        {
            var strFileContent = _fileProvider.GetFileInfo(C20.F20).ReadAsString();
            return JsonConvert.DeserializeObject<List<C20>>(strFileContent);
        }
        public IEnumerable<C21> GetDataC21()
        {
            var strFileContent = _fileProvider.GetFileInfo(C21.F21).ReadAsString();
            return JsonConvert.DeserializeObject<List<C21>>(strFileContent);
        }
        public IEnumerable<C22> GetDataC22()
        {
            var strFileContent = _fileProvider.GetFileInfo(C22.F22).ReadAsString();
            return JsonConvert.DeserializeObject<List<C22>>(strFileContent);
        }
        public IEnumerable<C23> GetDataC23()
        {
            var strFileContent = _fileProvider.GetFileInfo(C23.F23).ReadAsString();
            return JsonConvert.DeserializeObject<List<C23>>(strFileContent);
        }
        public IEnumerable<C24> GetDataC24()
        {
            var strFileContent = _fileProvider.GetFileInfo(C24.F24).ReadAsString();
            return JsonConvert.DeserializeObject<List<C24>>(strFileContent);
        }
        public IEnumerable<C26> GetDataC26()
        {
            var strFileContent = _fileProvider.GetFileInfo(C26.F26).ReadAsString();
            return JsonConvert.DeserializeObject<List<C26>>(strFileContent);
        }
        public IEnumerable<C27> GetDataC27()
        {
            var strFileContent = _fileProvider.GetFileInfo(C27.F27).ReadAsString();
            return JsonConvert.DeserializeObject<List<C27>>(strFileContent);
        }
        public IEnumerable<C51> GetDataC51()
        {
            var strFileContent = _fileProvider.GetFileInfo(C51.F51).ReadAsString();
            return JsonConvert.DeserializeObject<List<C51>>(strFileContent);
        }
        public IEnumerable<C52> GetDataC52()
        {
            var strFileContent = _fileProvider.GetFileInfo(C52.F52).ReadAsString();
            return JsonConvert.DeserializeObject<List<C52>>(strFileContent);
        }
        public IEnumerable<C53> GetDataC53()
        {
            var strFileContent = _fileProvider.GetFileInfo(C53.F53).ReadAsString();
            return JsonConvert.DeserializeObject<List<C53>>(strFileContent);
        }
        public IEnumerable<C54> GetDataC54()
        {
            var strFileContent = _fileProvider.GetFileInfo(C54.F54).ReadAsString();
            return JsonConvert.DeserializeObject<List<C54>>(strFileContent);
        }
        public IEnumerable<C55> GetDataC55()
        {
            var strFileContent = _fileProvider.GetFileInfo(C55.F55).ReadAsString();
            return JsonConvert.DeserializeObject<List<C55>>(strFileContent);
        }
        public IEnumerable<C56> GetDataC56()
        {
            var strFileContent = _fileProvider.GetFileInfo(C56.F56).ReadAsString();
            return JsonConvert.DeserializeObject<List<C56>>(strFileContent);
        }
        public IEnumerable<C57> GetDataC57()
        {
            var strFileContent = _fileProvider.GetFileInfo(C57.F57).ReadAsString();
            return JsonConvert.DeserializeObject<List<C57>>(strFileContent);
        }
        public IEnumerable<C58> GetDataC58()
        {
            var strFileContent = _fileProvider.GetFileInfo(C58.F58).ReadAsString();
            return JsonConvert.DeserializeObject<List<C58>>(strFileContent);
        }
        public IEnumerable<C59> GetDataC59()
        {
            var strFileContent = _fileProvider.GetFileInfo(C59.F59).ReadAsString();
            return JsonConvert.DeserializeObject<List<C59>>(strFileContent);
        }
        public IEnumerable<C60> GetDataC60()
        {
            var strFileContent = _fileProvider.GetFileInfo(C60.F60).ReadAsString();
            return JsonConvert.DeserializeObject<List<C60>>(strFileContent);
        }

        #endregion

    }

    #endregion

}