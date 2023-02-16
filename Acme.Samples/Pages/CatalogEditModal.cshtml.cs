using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Acme.Samples.Pages;

public class CatalogEditModal : AbpPageModel
{
    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public int Id { get; set; }
    
    [BindProperty]
    public CatalogEditViewModel Model { get; set; }
    
    [Inject]
    public CatalogEntityAppService AppService { get; set; }
    public async Task OnGetAsync()
    {
        var temp = await AppService.GetAsync(Id);
        Model = ObjectMapper.Map<CatalogEntityDto, CatalogEditViewModel>(temp);
    }

    public async Task OnPostAsync()
    {
        await AppService.UpdateAsync(Id, ObjectMapper.Map<CatalogEditViewModel, CatalogEntityDto>(Model));
    }
}


public class CatalogEditViewModel
{
    [Required]
    public string Code { get; set; }
    [Required]
    public string Description { get; set; }
    public string ExtraDescription { get; set; }
    public int DisplayOrder { get; set; }
    
    [HiddenInput]
    public string Grouper { get; set; }
    [HiddenInput]
    public string ParentCode { get; set; }
}