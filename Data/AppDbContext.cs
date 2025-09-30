using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using peace_kenya_api.Data.Configurations;
using peace_kenya_api.Models;

namespace peace_kenya_api.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Beneficiary> Beneficiaries { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<Donations> Donations { get; set; }
        public DbSet<NewsLetter> NewsLetters { get; set; }
        public DbSet<Volunteer> Volunteers { get; set; }




        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.ApplyConfiguration(new ContactUsConfig());
            builder.ApplyConfiguration(new BeneficiaryConfig());


            //convert table names to lowercase
            foreach (var entity in builder.Model.GetEntityTypes())
            {
                //table name
                entity.SetTableName(entity.GetTableName().ToLower());

                //field name
                foreach (var property in entity.GetProperties())
                {
                    property.SetColumnName(property.GetColumnName().ToLower());
                }

                //Keys
                foreach (var key in entity.GetKeys())
                {
                    key.SetName(key.GetName().ToLower());
                }

                // indexes
                foreach (var index in entity.GetIndexes())
                {
                    index.SetDatabaseName(index.GetDatabaseName().ToLower());
                }

                //fks
                foreach (var foreignKey in entity.GetForeignKeys())
                {
                    foreignKey.SetConstraintName(foreignKey.GetConstraintName().ToLower());
                }
            }
        }

    }
}
