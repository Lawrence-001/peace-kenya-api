using peace_kenya_api.Models;

namespace peace_kenya_api.Repositories.Interfaces
{
    public interface IBeneficiaryRepository
    {
        Task<Beneficiary> CreateBeneficiary(Beneficiary beneficiary);
        Task<Beneficiary> UpdateBeneficiary(Beneficiary beneficiary);
        Task<bool> DeleteBeneficiary(long beneficiaryId);
        Task<Beneficiary> GetBeneficiaryById(long beneficiaryId);
        Task<IEnumerable<Beneficiary>> GetAllBeneficiaries();
        Task<bool> EmailExists(string email);
        Task<bool> IdExists(int? id);
        Task<bool> PassportNumberExists(string? passportNumber);
    }
}
