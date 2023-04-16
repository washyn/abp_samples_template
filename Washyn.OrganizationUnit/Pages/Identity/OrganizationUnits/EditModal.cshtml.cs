using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.Identity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Validation;

namespace Washyn.OrganizationUnit.Pages.Identity.OrganizationUnits
{
    public class EditModal : AbpPageModel
    {
        [BindProperty] public EditModal.OrganizationUnitInfoModel OrganizationUnit { get; set; }

        protected IOrganizationUnitAppService OrganizationUnitAppService { get; }

        public EditModal(IOrganizationUnitAppService organizationUnitAppService)
        {
            // fbWsbJn1PdrYD0ZTul.tc9fB3genUu3t();
            // ISSUE: explicit constructor call
            // base.\u002Ector();
            this.OrganizationUnitAppService = organizationUnitAppService;
        }

        public virtual async Task OnGetAsync(Guid id)
        {
            EditModal editModalModel = this;
            IObjectMapper objectMapper = editModalModel.ObjectMapper;
            OrganizationUnitWithDetailsDto source =
                await editModalModel.OrganizationUnitAppService.GetAsync(id).ConfigureAwait(false);
            editModalModel.OrganizationUnit =
                objectMapper.Map<OrganizationUnitWithDetailsDto, EditModal.OrganizationUnitInfoModel>(source);
            objectMapper = (IObjectMapper)null;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            EditModal editModalModel = this;
            editModalModel.ValidateModel();
            OrganizationUnitUpdateDto input =
                editModalModel.ObjectMapper.Map<EditModal.OrganizationUnitInfoModel, OrganizationUnitUpdateDto>(
                    editModalModel.OrganizationUnit);
            OrganizationUnitWithDetailsDto unitWithDetailsDto = await editModalModel.OrganizationUnitAppService
                .UpdateAsync(editModalModel.OrganizationUnit.Id, input)
                .ConfigureAwait(false);
            return (IActionResult)editModalModel.NoContent();
        }

        public class OrganizationUnitInfoModel : ExtensibleObject
        {
            [HiddenInput] public Guid Id { get; set; }

            [DynamicStringLength(typeof(OrganizationUnitConsts), "MaxDisplayNameLength", null)]
            [Required]
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