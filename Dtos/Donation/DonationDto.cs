using peace_kenya_api.Enums;

namespace peace_kenya_api.Dtos.Donation
{
    public class DonationDto
    {
        public long DonationId { get; set; }
        public decimal Amount { get; set; }
        public string DonorFullName { get; set; }
        public string DonorEmail { get; set; }
        public string DonorPhone { get; set; }
        public DonationStatus Status { get; set; }
    }
}
