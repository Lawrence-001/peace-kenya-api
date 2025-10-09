using peace_kenya_api.BaseEntities;
using peace_kenya_api.Enums;
using System.ComponentModel.DataAnnotations;

namespace peace_kenya_api.Models
{
    public class Donations : BaseEntity
    {
        [Key]
        public long DonationId { get; set; }
        public decimal Amount { get; set; }
        public string DonorFullName { get; set; }
        public string DonorEmail { get; set; }
        public string DonorPhone { get; set; }
        //public DonationType DonationType { get; set; }
        public DonationStatus Status { get; set; } = DonationStatus.Pending;
        public string? CheckoutRequestID { get; set; } // from Mpesa response

    }
}