using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Washyn.Samples.Pages.Samples
{
    public class FormControls : AbpPageModel
    {
        [BindProperty]
        public DetailedModel MyDetailedModel { get; set; }

        public List<SelectListItem> CountryList { get; set; } = new List<SelectListItem>
    {
        new SelectListItem { Value = "CA", Text = "Canada"},
        new SelectListItem { Value = "US", Text = "USA"},
        new SelectListItem { Value = "UK", Text = "United Kingdom"},
        new SelectListItem { Value = "RU", Text = "Russia"}
    };

        public void OnGet()
        {
            MyDetailedModel = new DetailedModel
            {
                Name = "",
                Description = "Lorem ipsum dolor sit amet.",
                IsActive = true,
                Age = 65,
                Day = DateTime.Now,
                MyCarType = CarType.Coupe,
                YourCarType = CarType.Sedan,
                Country = "RU",
                NeighborCountries = new List<string>() { "UK", "CA" }
            };
        }

        public class DetailedModel
        {
            [Required]
            [Placeholder("Enter your name...")]
            [Display(Name = "Name")]
            public string Name { get; set; }

            [TextArea(Rows = 4)]
            [Display(Name = "Description")]
            [InputInfoText("Describe Yourself")]
            public string Description { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [Display(Name = "Is Active")]
            public bool IsActive { get; set; }

            [Required]
            [Display(Name = "Age")]
            public int Age { get; set; }

            [Required]
            [Display(Name = "My Car Type")]
            public CarType MyCarType { get; set; }

            [Required]
            [AbpRadioButton(Inline = true)]
            [Display(Name = "Your Car Type")]
            public CarType YourCarType { get; set; }

            [Required]
            [DataType(DataType.Date)]
            [Display(Name = "Day")]
            public DateTime Day { get; set; }

            [Required]
            [DataType(DataType.DateTime)]
            [Display(Name = "Day and time")]
            public DateTime DayAndTime { get; set; }

            [SelectItems(nameof(CountryList))]
            [Display(Name = "Country")]
            public string Country { get; set; }

            [SelectItems(nameof(CountryList))]
            [Display(Name = "Neighbor Countries")]
            public List<string> NeighborCountries { get; set; }
        }

        public enum CarType
        {
            Sedan,
            Hatchback,
            StationWagon,
            Coupe
        }
    }
}