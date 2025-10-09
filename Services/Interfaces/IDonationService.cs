using peace_kenya_api.Dtos.Donation;
using peace_kenya_api.Helpers;

namespace peace_kenya_api.Services.Interfaces
{
    public interface IDonationService
    {
        Task<Result<DonationDto>> CreateDonation(CreateDonationDto dto);
        Task<Result<bool>> DeleteDonation(long donationId);
        Task<Result<DonationDto>> GetDonationById(long donationId);
        Task<Result<DonationDto>> UpdateDonation(long id, CreateDonationDto dto);
        Task<Result<IEnumerable<DonationDto>>> GetAll();
        Task UpdateDonationStatus(string checkoutRequestId, bool success);
    }
}
