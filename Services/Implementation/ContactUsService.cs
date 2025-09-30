using AutoMapper;
using peace_kenya_api.Dtos.ContactUs;
using peace_kenya_api.Helpers;
using peace_kenya_api.Models;
using peace_kenya_api.Repositories.Interfaces;
using peace_kenya_api.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace peace_kenya_api.Services.Implementation
{
    public class ContactUsService : IContactUsService
    {
        private readonly IContactUsRepository _contactUsRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ContactUsService> _logger;

        public ContactUsService(IContactUsRepository contactUsRepository, IMapper mapper, ILogger<ContactUsService> logger)
        {
            _contactUsRepository = contactUsRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Result<ContactUsDto>> CreateContactUs(CreateContactUsDto dto)
        {
            if (dto == null)
            {
                return Result<ContactUsDto>.ValidationError("Request body is required");
            }

            try
            {
                var contact = _mapper.Map<ContactUs>(dto);
                var result = await _contactUsRepository.CreateContactUs(contact);

                var responseDto = _mapper.Map<ContactUsDto>(result);  //map back
                return Result<ContactUsDto>.Success(responseDto);
            }
            catch (ValidationException vex)
            {
                return Result<ContactUsDto>.ValidationError(vex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred when creating contact");

                return Result<ContactUsDto>.Failure("An error occurred while creating contact");
            }
        }


        public async Task<Result<bool>> DeleteContactUs(long contactUsId)
        {
            try
            {
                var contact = await _contactUsRepository.DeleteContactUs(contactUsId);
                if (!contact)
                {
                    return Result<bool>.NotFound($"Contact with Id {contactUsId} does not exist");
                }

                return Result<bool>.Success(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred when deleting contact {contactUsId}", contactUsId);
                return Result<bool>.Failure("An error occurred while deleting contact");
            }
        }


        public async Task<Result<IEnumerable<ContactUsDto>>> GetAll()
        {
            try
            {
                var contacts = await _contactUsRepository.GetAllContactUs();

                var result = _mapper.Map<IEnumerable<ContactUsDto>>(contacts);

                return Result<IEnumerable<ContactUsDto>>.Success(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred when retrieving contacts");
                return Result<IEnumerable<ContactUsDto>>.Failure("An error occurred when retrieving contacts");
            }
        }

        public async Task<Result<ContactUsDto>> GetContactUsById(long contactUsId)
        {
            try
            {
                var contact = await _contactUsRepository.GetContactUsById(contactUsId);
                if (contact == null)
                {
                    return Result<ContactUsDto>.NotFound($"Contact with {contactUsId} does not exist");
                }

                var responseDto = _mapper.Map<ContactUsDto>(contact);
                return Result<ContactUsDto>.Success(responseDto);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving contact with Id {contactUsId}");
                return Result<ContactUsDto>.Failure("An error occurred while retrieving contact");
            }

        }
    }
}
