using peace_kenya_api.Models;

namespace peace_kenya_api.Repositories.Interfaces
{
    public interface IContactUsRepository
    {
        Task<ContactUs> CreateContactUs(ContactUs contactUs);
        Task<bool> DeleteContactUs(long contactUsId);
        Task<ContactUs> GetContactUsById(long contactUsId);
        Task<IEnumerable<ContactUs>> GetAllContactUs();
    }
}
