using System.Net;
using System.Threading.Tasks;
using Acme.Identity.IdentityUser;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Acme.Identity.Pages.Users
{
    public class UpdateModal : PageModel
    {

        [Inject]
        public UserAppService Service { get; set; }
        
        [BindProperty]
        public UpdateUserDto Model { get; set; }
        
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var temp = await Service.GetAsync(Id);
            Model = new UpdateUserDto()
            {
                PhoneNumber = temp.PhoneNumber,
                Email = temp.Email,
                Name = temp.Name,
                Surname = temp.Surname,
            };
            return Page();
        }
        
        public async Task<IActionResult> OnPostAsync()
        {
            await Service.UpdateAsync(Id, Model);
            return this.StatusCode((int)HttpStatusCode.NoContent);
        }
    }
}