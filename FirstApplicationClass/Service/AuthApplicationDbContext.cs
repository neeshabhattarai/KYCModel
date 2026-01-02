using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace FirstApplicationClass.Service
{
    public class AuthApplicationDbContext : IdentityDbContext
    {
        public AuthApplicationDbContext(DbContextOptions<AuthApplicationDbContext> context) : base(context)
        {

        }
        


        
    }
}
