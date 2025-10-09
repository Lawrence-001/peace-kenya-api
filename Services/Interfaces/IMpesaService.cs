using peace_kenya_api.Dtos.Donation;
using peace_kenya_api.Models.Mpesa;

namespace peace_kenya_api.Services.Interfaces
{
    public interface IMpesaService
    {
        Task<MpesaTokenModel> GenerateAccessToken();
        Task<string> InitiateStkPush(CreateDonationDto donation);
    }
}
