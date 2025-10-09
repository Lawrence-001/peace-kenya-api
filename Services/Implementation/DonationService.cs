using AutoMapper;
using peace_kenya_api.Dtos.Donation;
using peace_kenya_api.Enums;
using peace_kenya_api.Helpers;
using peace_kenya_api.Models;
using peace_kenya_api.Repositories.Interfaces;
using peace_kenya_api.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace peace_kenya_api.Services.Implementation
{
    public class DonationService : IDonationService
    {
        private readonly IDonationRepository _donationRepository;
        private readonly ILogger<DonationService> _logger;
        private readonly IMapper _mapper;
        private readonly IMpesaService _mpesaService;

        public DonationService(IDonationRepository donationRepository, ILogger<DonationService> logger, IMapper mapper, IMpesaService mpesaService)
        {
            _donationRepository = donationRepository;
            _logger = logger;
            _mapper = mapper;
            _mpesaService = mpesaService;
        }

        public async Task<Result<DonationDto>> CreateDonation(CreateDonationDto dto)
        {
            if (dto == null)
            {
                return Result<DonationDto>.ValidationError("Request body is required");
            }

            try
            {
                var donation = _mapper.Map<Donations>(dto);
                var created = await _donationRepository.CreateDonation(donation);

                // trigger stk push
                var stkPush = await _mpesaService.InitiateStkPush(dto);

                // save checkout id for callback matching
                created.CheckoutRequestID = stkPush;
                await _donationRepository.UpdateDonation(created);

                var result = _mapper.Map<DonationDto>(created);
                return Result<DonationDto>.Success(result);
            }
            catch (ValidationException vex)
            {
                return Result<DonationDto>.ValidationError(vex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating donation");
                return Result<DonationDto>.Failure("An error occurred while creating donation");
            }
        }

        public async Task<Result<bool>> DeleteDonation(long donationId)
        {
            try
            {
                var deleted = await _donationRepository.DeleteDonation(donationId);
                if (!deleted)
                {
                    return Result<bool>.NotFound($"Donation with Id {donationId} does not exist");
                }

                return Result<bool>.Success(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting donation {DonationId}", donationId);
                return Result<bool>.Failure("An error occurred while deleting donation");
            }
        }

        public async Task<Result<IEnumerable<DonationDto>>> GetAll()
        {
            try
            {
                var donations = await _donationRepository.GetAllDonations();
                var result = _mapper.Map<IEnumerable<DonationDto>>(donations);

                return Result<IEnumerable<DonationDto>>.Success(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving donations");
                return Result<IEnumerable<DonationDto>>.Failure("An error occurred while retrieving donations");
            }
        }

        public async Task<Result<DonationDto>> GetDonationById(long donationId)
        {
            try
            {
                var donation = await _donationRepository.GetDonationById(donationId);
                if (donation == null)
                {
                    return Result<DonationDto>.NotFound($"Donation with Id {donationId} does not exist");
                }

                var result = _mapper.Map<DonationDto>(donation);
                return Result<DonationDto>.Success(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving donation {DonationId}", donationId);
                return Result<DonationDto>.Failure("An error occurred while retrieving donation");
            }
        }

        public async Task<Result<DonationDto>> UpdateDonation(long id, CreateDonationDto dto)
        {
            if (dto == null)
            {
                return Result<DonationDto>.ValidationError("Request body is required");
            }

            try
            {
                var existing = await _donationRepository.GetDonationById(id);
                if (existing == null)
                {
                    return Result<DonationDto>.NotFound($"Donation with Id {id} does not exist");
                }

                existing.Status = Enums.DonationStatus.Completed;
                _mapper.Map(dto, existing);


                var updated = await _donationRepository.UpdateDonation(existing);
                var result = _mapper.Map<DonationDto>(updated);

                return Result<DonationDto>.Success(result);
            }
            catch (ValidationException vex)
            {
                return Result<DonationDto>.ValidationError(vex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating donation {DonationId}", id);
                return Result<DonationDto>.Failure("An error occurred while updating donation");
            }
        }

        public async Task UpdateDonationStatus(string checkoutRequestId, bool success)
        {
            var donation = (await _donationRepository.GetAllDonations()).FirstOrDefault(d => d.CheckoutRequestID == checkoutRequestId);

            if (donation == null)
            {
                return;
            }

            donation.Status = success ? DonationStatus.Completed : DonationStatus.Failed;
            await _donationRepository.UpdateDonation(donation);
        }
    }
}
