using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Acme.Samples.Pages;

public class CatalogCreateModal : AbpPageModel
{
    [BindProperty(SupportsGet = true)]
    public string ParentCode { get; set; }
    
    [BindProperty]
    public CreateCatalogViewModel Model { get; set; }
    public CatalogEntityAppService AppService { get; set; }
    public void OnGet()
    {
        Model = new CreateCatalogViewModel()
        {
            DisplayOrder = 0,
            ParentCode = ParentCode,
            Grouper = ParentCode,
        };
    }
    
    public async Task OnPostAsync()
    {
        await AppService.CreateAsync(ObjectMapper.Map<CreateCatalogViewModel, CatalogEntityDto>(Model));
    }
}

public class CreateCatalogViewModel
{
    [Required]
    public string Code { get; set; }
    [Required]
    public string Description { get; set; }
    
    // [Required]
    [HiddenInput]
    public string Grouper { get; set; }
    
    // [Required]
    [HiddenInput]
    public string ParentCode { get; set; }
    public string ExtraDescription { get; set; }
    public int DisplayOrder { get; set; }
}