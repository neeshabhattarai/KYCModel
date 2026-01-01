using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FirstApplicationClass.Service
{
    public class AuthApplicationDbContext:DbContext
    {
        public AuthApplicationDbContext(DbContextOptions<AuthApplicationDbContext> context):base(context)
        {
            
        }
       
    }
}
