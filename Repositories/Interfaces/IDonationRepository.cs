using peace_kenya_api.Models;

namespace peace_kenya_api.Repositories.Interfaces
{
    public interface IDonationRepository
    {
        Task<Donations> CreateDonation(Donations donation);
        Task<Donations> UpdateDonation(Donations donation);
        Task<bool> DeleteDonation(long donationId);
        Task<Donations> GetDonationById(long donationId);
        Task<IEnumerable<Donations>> GetAllDonations();
    }
}
