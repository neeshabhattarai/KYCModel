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

    }
}
