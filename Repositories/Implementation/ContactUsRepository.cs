using Microsoft.EntityFrameworkCore;
using peace_kenya_api.Data;
using peace_kenya_api.Models;
using peace_kenya_api.Repositories.Interfaces;

namespace peace_kenya_api.Repositories.Implementation
{
    public class ContactUsRepository : IContactUsRepository
    {
        private readonly AppDbContext _context;

        public ContactUsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ContactUs> CreateContactUs(ContactUs contactUs)
        {
            _context.ContactUs.Add(contactUs);
            await _context.SaveChangesAsync();
            return contactUs;
        }

        public async Task<bool> DeleteContactUs(long contactUsId)
        {
            var recordToDelete = await _context.ContactUs.FirstOrDefaultAsync(x => x.ContactUsId == contactUsId);
            if (recordToDelete != null)
            {
                _context.ContactUs.Remove(recordToDelete);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<ContactUs>> GetAllContactUs()
        {
            return await _context.ContactUs.ToListAsync();
        }

        public async Task<ContactUs> GetContactUsById(long contactUsId)
        {
            var record = await _context.ContactUs.FirstOrDefaultAsync(x => x.ContactUsId == contactUsId);
            if (record != null)
            {
                return record;
            }
            return null;
        }
    }
}
