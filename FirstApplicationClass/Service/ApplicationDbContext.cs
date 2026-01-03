using FirstApplicationClass.Model.Domains;
using Microsoft.EntityFrameworkCore;

namespace FirstApplicationClass.Service
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> context):base(context)
        {
            
        }
        public DbSet<PersonalDetails> PersonalInfo { get; set; }
        public DbSet<NationalIdentity> NationalIdentities { get; set; }
        public DbSet<RegisterImage> RegisterImages { get; set; }

    }
}
