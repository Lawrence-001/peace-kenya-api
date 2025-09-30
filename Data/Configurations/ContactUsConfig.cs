using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using peace_kenya_api.Models;

namespace peace_kenya_api.Data.Configurations
{
    public class ContactUsConfig : IEntityTypeConfiguration<ContactUs>
    {
        public void Configure(EntityTypeBuilder<ContactUs> contactUsConfig)
        {
            contactUsConfig.ToTable("contact_us");
            contactUsConfig.HasKey(x => x.ContactUsId);

            contactUsConfig.Property(x => x.FullName).IsRequired();
            contactUsConfig.Property(x => x.Email).IsRequired();
            //contactUsConfig.Property(x => x.Phone).IsRequired();
            contactUsConfig.Property(x => x.Message).IsRequired();

        }
    }
}
