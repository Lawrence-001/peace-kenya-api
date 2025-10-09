using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using peace_kenya_api.Models;

namespace peace_kenya_api.Data.Configurations
{
    public class DonationConfig : IEntityTypeConfiguration<Donations>
    {
        public void Configure(EntityTypeBuilder<Donations> config)
        {
            config.ToTable("donations");
            config.HasKey(x => x.DonationId);

            config.Property(x => x.DonorFullName);
            config.Property(x => x.DonorEmail);
        }
    }
}
