using Demo.TestingKits.Factories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.TestingKits.Models
{
    public class OrderViewModel
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        [Required]
        [Display(Name="House Name/No")]
        public string HouseNameOrNo { get; set; }
        
        [Required]
        public string Street { get; set; }

        //Full Disclosure, I Googled the RegEx pattern for UK postcode validation, its not fully verified but it shows my thought process
        [Required]
        [Display(Name = "Postcode")]
        [RegularExpression(@"^([A-Z]{1,2})([0-9][0-9A-Z]?) ([0-9])([ABDEFGHJLNPQRSTUWXYZ]{2})$", ErrorMessage = "Invalid Postcode")]
        public string PostCode { get; set; }
        
        [Required]
        [Display(Name="E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string TelephoneNo { get; set; }
        
        [Required]
        [MinLength(1, ErrorMessage = "Please select at least 1 test type")]
        [Display(Name="Select which tests you would like to be sent a kit for?")]
        public IEnumerable<InfectionType> SelectedTestTypes { get; set; }

    }
}
