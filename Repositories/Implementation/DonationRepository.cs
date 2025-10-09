using Microsoft.EntityFrameworkCore;
using peace_kenya_api.Data;
using peace_kenya_api.Models;
using peace_kenya_api.Repositories.Interfaces;

namespace peace_kenya_api.Repositories.Implementation
{
    public class DonationRepository : IDonationRepository
    {
        private readonly AppDbContext _context;

        public DonationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Donations> CreateDonation(Donations donation)
        {
            _context.Donations.Add(donation);
            await _context.SaveChangesAsync();
            return donation;
        }

        public async Task<bool> DeleteDonation(long donationId)
        {
            var donation = await _context.Donations.Where(x => x.DonationId == donationId).FirstOrDefaultAsync();
            if (donation == null)
            {
                return false;
            }
            donation.IsDeleted = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Donations>> GetAllDonations()
        {
            return await _context.Donations.OrderByDescending(x => x.CreatedAt).ToListAsync();
        }

        public async Task<Donations> GetDonationById(long donationId)
        {
            var donation = await _context.Donations.Where(x => x.DonationId == donationId).FirstOrDefaultAsync();
            if (donation == null)
            {
                return null;
            }
            return donation;
        }

        public async Task<Donations> UpdateDonation(Donations donation)
        {
            _context.Donations.Update(donation);
            await _context.SaveChangesAsync();
            return donation;
        }
    }
}
