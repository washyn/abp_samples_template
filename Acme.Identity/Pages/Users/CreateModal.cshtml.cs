using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;
using Acme.Identity.IdentityUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Volo.Abp.ObjectMapping;

namespace Acme.Identity.Pages.Users
{
    [Authorize(Roles = Consts.RolConsts.Administrador)]
    public class CreateModal : PageModel
    {

        [Inject]
        public UserAppService Service { get; set; }
        [Inject]
        public IObjectMapper ObjectMapper { get; set; }

        [BindProperty]
        public CreateUserViewModel Model { get; set; }
        
        public void OnGet()
        {
            
        }
        
        public async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateUserViewModel, CreateUserDto>(Model);
            await Service.CreateAsync(dto);
            return this.StatusCode((int)HttpStatusCode.OK);
        }
    }


    public class CreateUserViewModel
    {
        [Required]
        [Display(Name = "Usuario")]
        [Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form.InputInfoText("Nombre de usuario.")]
        public string UserName { get; set; }
        public string Email { get; set; }
        
        [Display(Name = "Nombre")]
        public string Name { get; set; }
        
        [Display(Name = "Apellido")]
        public string Surname { get; set; }

        [Display(Name = "Numero de cel")]
        public string PhoneNumber { get; set; }
        
        [Display(Name = "Contrasena")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Display(Name = "Rol")]
        [EnumDataType(typeof(Consts.Roles))]
        public Consts.Roles Roles { get; set; }
    }
}