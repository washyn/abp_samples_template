using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.Identity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Validation;

namespace Washyn.OrganizationUnit.Pages.Identity.OrganizationUnits
{
    // Volo.Abp.Identity.Web.Pages.Identity.OrganizationUnits.CreateModalModel
    public class CreateModal : AbpPageModel
    {
        [BindProperty]
        public CreateModal.OrganizationUnitInfoModel OrganizationUnit { get; set; }
    
        protected IOrganizationUnitAppService OrganizationUnitAppService { get; }
    
        public CreateModal(
            IOrganizationUnitAppService organizationUnitAppService)
        {
            // fbWsbJn1PdrYD0ZTul.tc9fB3genUu3t();
            // ISSUE: explicit constructor call
            // base.\u002Ector();
            this.OrganizationUnitAppService = organizationUnitAppService;
            this.OrganizationUnit = new CreateModal.OrganizationUnitInfoModel();
        }
    
        public virtual Task OnGetAsync(Guid? parentId)
        {
            this.OrganizationUnit.ParentId = parentId;
            return Task.CompletedTask;
        }
    
        public virtual async Task<IActionResult> OnPostAsync()
        {
            CreateModal createModalModel = this;
            createModalModel.ValidateModel();
            OrganizationUnitCreateDto input = createModalModel.ObjectMapper.Map<CreateModal.OrganizationUnitInfoModel, OrganizationUnitCreateDto>(createModalModel.OrganizationUnit);
            OrganizationUnitWithDetailsDto unitWithDetailsDto = await createModalModel.OrganizationUnitAppService.CreateAsync(input).ConfigureAwait(false);
            return (IActionResult) createModalModel.NoContent();
        }
    
        public class OrganizationUnitInfoModel : ExtensibleObject
        {
            [HiddenInput]
            public Guid? ParentId { get; set; }
    
            [Required]
            [DynamicStringLength(typeof (OrganizationUnitConsts), "MaxDisplayNameLength", null)]
            public string DisplayName { get; set; }
    
            public OrganizationUnitInfoModel()
            {
                // fbWsbJn1PdrYD0ZTul.tc9fB3genUu3t();
                // ISSUE: explicit constructor call
                // base.\u002Ector();
            }
        }
    }
}