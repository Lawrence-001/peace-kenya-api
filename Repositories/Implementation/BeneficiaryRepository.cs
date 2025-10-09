using Microsoft.EntityFrameworkCore;
using peace_kenya_api.Data;
using peace_kenya_api.Models;
using peace_kenya_api.Repositories.Interfaces;

namespace peace_kenya_api.Repositories.Implementation
{
    public class BeneficiaryRepository : IBeneficiaryRepository
    {
        private readonly AppDbContext _context;

        public BeneficiaryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Beneficiary> CreateBeneficiary(Beneficiary beneficiary)
        {
            _context.Beneficiaries.Add(beneficiary);
            await _context.SaveChangesAsync();
            return beneficiary;
        }

        public async Task<bool> DeleteBeneficiary(long beneficiaryId)
        {
            var beneficiary = await _context.Beneficiaries.FirstOrDefaultAsync(x => x.BeneficiaryId == beneficiaryId);
            if (beneficiary == null)
            {
                return false;
            }
            beneficiary.IsDeleted = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Beneficiary>> GetAllBeneficiaries()
        {
            return await _context.Beneficiaries.ToListAsync();
        }

        public async Task<Beneficiary> GetBeneficiaryById(long beneficiaryId)
        {
            var beneficiary = await _context.Beneficiaries.FirstOrDefaultAsync(x => x.BeneficiaryId == beneficiaryId);
            if (beneficiary == null)
            {
                return null;
            }
            return beneficiary;
        }

        public async Task<Beneficiary> UpdateBeneficiary(Beneficiary beneficiary)
        {
            //var recordToUpdate = await _context.Beneficiaries.FirstOrDefaultAsync(x => x.BeneficiaryId == beneficiaryId);
            //if (recordToUpdate == null)
            //{
            //    return null;
            //}

            //recordToUpdate.FirstName = beneficiary.FirstName;
            //recordToUpdate.LastName = beneficiary.LastName;
            //recordToUpdate.MiddleName = beneficiary.MiddleName;
            //recordToUpdate.IdNumber = beneficiary.IdNumber;
            //recordToUpdate.Gender = beneficiary.Gender;
            //recordToUpdate.PhoneNumber = beneficiary.PhoneNumber;
            //recordToUpdate.PassportNumber = beneficiary.PassportNumber;
            //recordToUpdate.Programs = beneficiary.Programs;
            //recordToUpdate.Skills = beneficiary.Skills;
            //recordToUpdate.Location = beneficiary.Location;

            _context.Beneficiaries.Update(beneficiary);
            await _context.SaveChangesAsync();
            return beneficiary;

        }

        public async Task<bool> EmailExists(string email)
        {
            return await _context.Beneficiaries.AnyAsync(x => x.Email == email);
        }

        public async Task<bool> IdExists(int? id)
        {
            if (id == null)
            {
                return false;
            }
            return await _context.Beneficiaries.AnyAsync(x => x.IdNumber == id);
        }

        public async Task<bool> PassportNumberExists(string? passportNumber)
        {
            if (passportNumber == null)
            {
                return false;
            }
            return await _context.Beneficiaries.AnyAsync(x => x.PassportNumber == passportNumber);
        }
    }
}
