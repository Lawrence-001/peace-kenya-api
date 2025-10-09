using peace_kenya_api.Enums;
using System.ComponentModel.DataAnnotations;

namespace peace_kenya_api.Dtos.Donation
{
    public class CreateDonationDto
    {
        [Required(ErrorMessage = "Amount is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string DonorFullName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string DonorEmail { get; set; }
        public string DonorPhone { get; set; }
        public DonationStatus Status { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}
