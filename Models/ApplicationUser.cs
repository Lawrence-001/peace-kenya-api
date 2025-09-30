using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace peace_kenya_api.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FullName { get; set; } = string.Empty;
    }
}
