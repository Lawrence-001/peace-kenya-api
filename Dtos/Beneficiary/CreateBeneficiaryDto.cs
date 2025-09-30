using peace_kenya_api.Enums;
using System.ComponentModel.DataAnnotations;

namespace peace_kenya_api.Dtos.Beneficiary
{
    public class CreateBeneficiaryDto
    {
        [Required(ErrorMessage ="First Name is required")]
        [Display(Name = "First Name")]
        public string FisrtName { get; set; }

        [Required(ErrorMessage ="Last Name is required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Middle Name")]
        public string? MiddleName { get; set; }

        [Display(Name = "ID")]
        public int? IdNumber { get; set; }

        [Display(Name = "Passport Number")]
        public string? PassportNumber { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public string PhoneNumber { get; set; }
        public Programs Programs { get; set; }
        public Skills Skills { get; set; }
        public Location Location { get; set; }
    }
}
