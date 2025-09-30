using AutoMapper;
using peace_kenya_api.Dtos.Beneficiary;
using peace_kenya_api.Helpers;
using peace_kenya_api.Models;
using peace_kenya_api.Repositories.Interfaces;
using peace_kenya_api.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace peace_kenya_api.Services.Implementation
{
    public class BeneficiaryService : IBeneficiaryService
    {
        private readonly IBeneficiaryRepository _beneficiaryRepository;
        private readonly ILogger<BeneficiaryService> _logger;
        private readonly IMapper _mapper;

        public BeneficiaryService(IBeneficiaryRepository beneficiaryRepository, ILogger<BeneficiaryService> logger,
            IMapper mapper)
        {
            _beneficiaryRepository = beneficiaryRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<Result<BeneficiaryDto>> CreateBeneficiary(CreateBeneficiaryDto dto)
        {
            if (dto == null)
            {
                return Result<BeneficiaryDto>.ValidationError("Request body is required");
            }

            if (await _beneficiaryRepository.EmailExists(dto.Email))
            {
                return Result<BeneficiaryDto>.ValidationError("Email already in use");
            }

            if (await _beneficiaryRepository.IdExists(dto.IdNumber))
            {
                return Result<BeneficiaryDto>.ValidationError("ID number already in use");
            }

            if (await _beneficiaryRepository.PassportNumberExists(dto.PassportNumber))
            {
                return Result<BeneficiaryDto>.ValidationError("Passport number already in use");
            }

            if (dto.IdNumber.HasValue && dto.IdNumber.Value.ToString().Length > 8)
            {
                return Result<BeneficiaryDto>.ValidationError("ID must be at most 8 digits.");
            }

            try
            {
                var beneficiary = _mapper.Map<Beneficiary>(dto);
                var created = await _beneficiaryRepository.CreateBeneficiary(beneficiary);

                var result = _mapper.Map<BeneficiaryDto>(created);
                return Result<BeneficiaryDto>.Success(result);
            }
            catch (ValidationException vex)
            {
                return Result<BeneficiaryDto>.ValidationError(vex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating beneficiary");
                return Result<BeneficiaryDto>.Failure("An error occurred while creating beneficiary");
            }
        }

        public async Task<Result<bool>> DeleteBeneficiary(long beneficiaryId)
        {
            try
            {
                var deleted = await _beneficiaryRepository.DeleteBeneficiary(beneficiaryId);
                if (!deleted)
                {
                    return Result<bool>.NotFound($"Beneficiary with Id {beneficiaryId} does not exist");
                }

                return Result<bool>.Success(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting beneficiary {BeneficiaryId}", beneficiaryId);
                return Result<bool>.Failure("An error occurred while deleting beneficiary");
            }
        }

        public async Task<Result<IEnumerable<BeneficiaryDto>>> GetAll()
        {
            try
            {
                var beneficiaries = await _beneficiaryRepository.GetAllBeneficiaries();
                var result = _mapper.Map<IEnumerable<BeneficiaryDto>>(beneficiaries);

                return Result<IEnumerable<BeneficiaryDto>>.Success(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving beneficiaries");
                return Result<IEnumerable<BeneficiaryDto>>.Failure("An error occurred while retrieving beneficiaries");
            }
        }

        public async Task<Result<BeneficiaryDto>> GetBeneficiaryById(long beneficiaryId)
        {
            try
            {
                var beneficiary = await _beneficiaryRepository.GetBeneficiaryById(beneficiaryId);
                if (beneficiary == null)
                {
                    return Result<BeneficiaryDto>.NotFound($"Beneficiary with Id {beneficiaryId} does not exist");
                }

                var result = _mapper.Map<BeneficiaryDto>(beneficiary);
                return Result<BeneficiaryDto>.Success(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving beneficiary {BeneficiaryId}", beneficiaryId);
                return Result<BeneficiaryDto>.Failure("An error occurred while retrieving beneficiary");
            }
        }

        public async Task<Result<BeneficiaryDto>> UpdateBeneficiary(long id, CreateBeneficiaryDto dto)
        {
            if (dto == null)
            {
                return Result<BeneficiaryDto>.ValidationError("Request body is required");
            }
            if (dto.IdNumber.HasValue && dto.IdNumber.Value.ToString().Length > 8)
            {
                return Result<BeneficiaryDto>.ValidationError("ID must be at most 8 digits.");
            }

            try
            {
                var existing = await _beneficiaryRepository.GetBeneficiaryById(id);
                if (existing == null)
                {
                    return Result<BeneficiaryDto>.NotFound($"Beneficiary with Id {id} does not exist");
                }

                _mapper.Map(dto, existing);

                var updated = await _beneficiaryRepository.UpdateBeneficiary(existing);
                var result = _mapper.Map<BeneficiaryDto>(updated);

                return Result<BeneficiaryDto>.Success(result);
            }
            catch (ValidationException vex)
            {
                return Result<BeneficiaryDto>.ValidationError(vex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating beneficiary {BeneficiaryId} {@Beneficiary}", id, dto);
                return Result<BeneficiaryDto>.Failure("An error occurred while updating beneficiary");
            }
        }
    }
}
