using System.ComponentModel.DataAnnotations;

namespace peace_kenya_api.Dtos.ContactUs
{
    public class CreateContactUsDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }

        public string? Phone { get; set; }

        [Required(ErrorMessage = "Message is required")]
        public string Message { get; set; }
    }
}
