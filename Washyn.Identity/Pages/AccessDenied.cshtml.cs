using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Acme.Identity.Pages
{
    public class AccessDenied : PageModel
    {

        [BindProperty]
        public string ReturnUrl { get; set; }
        
        public void OnGet()
        {
            
        }
    }
}