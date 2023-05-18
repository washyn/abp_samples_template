using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Acme.Samples.Pages;

public class CatalogManage : AbpPageModel
{
    [Inject] public ICatalogEntityAppService AppService { get; set; }

    [BindProperty(SupportsGet = true)] public string Code { get; set; } = string.Empty;

    [BindProperty(SupportsGet = true)] public string ParentCode { get; set; } = string.Empty;
    
    public List<CatalogEntityRootDto> RootDtos { get; set; } = new List<CatalogEntityRootDto>();
    
    public async Task OnGetAsync()
    {
        if (string.IsNullOrEmpty(Code) && string.IsNullOrEmpty(ParentCode))
        {
            RootDtos = await AppService.GetRootAsync();
        }

        if (!string.IsNullOrEmpty(Code))
        {
            var childs = await AppService.GetChildAsync(Code);
            RootDtos = childs.Select(a => new CatalogEntityRootDto()
            {
                Code = a.Code,
                Description = a.Description,
                DisplayOrder = a.DisplayOrder,
                ExtraDescription = a.ExtraDescription
            }).ToList();
        }
    }
    
    public async Task OnPostAsync()
    {
        // if (string.IsNullOrEmpty(Code) && string.IsNullOrEmpty(ParentCode))
        // {
        //     RootDtos = await AppService.GetRootAsync();
        // }
    }
}