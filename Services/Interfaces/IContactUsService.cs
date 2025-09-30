using peace_kenya_api.Dtos.ContactUs;
using peace_kenya_api.Helpers;

namespace peace_kenya_api.Services.Interfaces
{
    public interface IContactUsService
    {
        Task<Result<ContactUsDto>> CreateContactUs(CreateContactUsDto dto);
        Task<Result<bool>> DeleteContactUs(long contactUsId);
        Task<Result<ContactUsDto>> GetContactUsById(long contactUsId);
        Task<Result<IEnumerable<ContactUsDto>>> GetAll();
    }
}
