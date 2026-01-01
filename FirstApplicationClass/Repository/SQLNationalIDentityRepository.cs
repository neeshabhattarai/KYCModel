using FirstApplicationClass.Model.Domains;
using FirstApplicationClass.Repository.Interface;
using FirstApplicationClass.Service;
using Microsoft.EntityFrameworkCore;

namespace FirstApplicationClass.Repository
{
    public class SQLNationalIDentityRepository : INationalIdentity
    {
        private readonly ApplicationDbContext context;

        public SQLNationalIDentityRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<NationalIdentity> Create(NationalIdentity identity)
        {
            var result = await context.NationalIdentities.AddAsync(identity);
           await context.SaveChangesAsync();
            return identity;
        }

        public async Task<NationalIdentity> Delete(string id)
        {
           var result=await context.NationalIdentities.FindAsync(id);

            context.NationalIdentities.Remove(result);
            await context.SaveChangesAsync();
            return result;
        }

        public async Task<List<NationalIdentity>> GetAll()
        {
            return context.NationalIdentities.ToList();
        }

        public async Task<NationalIdentity> GetById(string id)
        {
            var result = await context.NationalIdentities.FirstOrDefaultAsync(x => x.Id==id);
            return result;
        }

        public async Task<NationalIdentity> Update(string id, NationalIdentity identity)
        {
            var result = await context.NationalIdentities.FindAsync(id);
            if (result != null)
            {
                return null;
            }
            result.NationalId = identity.NationalId;
            await context.SaveChangesAsync();
            return result;
        }
    }
}
