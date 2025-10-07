using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using peace_kenya_api.Models;

namespace peace_kenya_api.Data.Configurations
{
    public class BeneficiaryConfig : IEntityTypeConfiguration<Beneficiary>
    {
        public void Configure(EntityTypeBuilder<Beneficiary> config)
        {
            config.ToTable("beneficiaries");
            config.HasKey(x => x.BeneficiaryId);

            config.Property(x => x.FirstName).IsRequired();
            config.Property(x => x.LastName).IsRequired();
            config.Property(x => x.MiddleName);
            config.Property(x => x.Email);


            config.HasIndex(x => x.Email).IsUnique();
            config.HasIndex(x => x.IdNumber).IsUnique().HasFilter("\"id_number\" IS NOT NULL");
            config.HasIndex(x => x.PassportNumber).IsUnique().HasFilter("\"passport_number\" IS NOT NULL");

        }
    }
}