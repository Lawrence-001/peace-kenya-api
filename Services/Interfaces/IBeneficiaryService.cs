using peace_kenya_api.Dtos.Beneficiary;
using peace_kenya_api.Helpers;

namespace peace_kenya_api.Services.Interfaces
{
    public interface IBeneficiaryService
    {
        Task<Result<BeneficiaryDto>> CreateBeneficiary(CreateBeneficiaryDto dto);
        Task<Result<bool>> DeleteBeneficiary(long beneficiaryId);
        Task<Result<BeneficiaryDto>> GetBeneficiaryById(long beneficiaryId);
        Task<Result<BeneficiaryDto>>UpdateBeneficiary(long id, CreateBeneficiaryDto dto);
        Task<Result<IEnumerable<BeneficiaryDto>>> GetAll();
    }
}
