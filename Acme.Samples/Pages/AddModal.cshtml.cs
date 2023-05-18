using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Acme.Samples.Pages;

public class AddModal : PageModel
{
    [BindProperty]
    public CreateEntityRoot EntityRoot { get; set; }


    [Inject]
    public ICatalogEntityAppService AppService { get; set; }
    public void OnGet()
    {
        
    }
    public async Task OnPostAsync()
    {
        await AppService.CreateRootAsync(EntityRoot);
    }
}