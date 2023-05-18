using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Acme.Samples.Pages;

public class AddChildModal : PageModel
{

    [BindProperty]
    public CreateEntityChild EntityChild { get; set; }

    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public string ParentCode { get; set; }

    [Inject]
    public ICatalogEntityAppService AppService { get; set; }
    public void OnGet()
    {
        
    }
    
    public async Task OnPostAsync()
    {
        await AppService.CreateChildAsync(ParentCode, EntityChild);
    }
}