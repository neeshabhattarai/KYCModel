using FirstApplicationClass.Model.Domains;
using FirstApplicationClass.Repository;
using FirstApplicationClass.Repository.Interface;
using FirstApplicationClass.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FirstApplicatinClass.UnitTest
{
    public class NationalIdentityRepositoryTest
    {
        public ApplicationDbContext GetContext()
        {
            return new ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options);
        }
        [Fact]
        public  async Task PostNationIdentitites_ShouldReturnTrue()
        {
            var context = GetContext();
            var user = AddData();
            var identity = new SQLNationalIDentityRepository(context);
           await identity.Create(user);
           var list= context.NationalIdentities.FirstOrDefault(x=>x.Id == user.Id);
            Assert.NotNull(list);
            Assert.Equal(user.Id, list.Id);
            Assert.Equal(user.NationalId,list.NationalId);

        }
        [Fact]
        public async Task GetAllNationalIdentities_ShouldReturnTrue()
        {
            var context = GetContext();
            var repos = new SQLNationalIDentityRepository(context);
            await repos.Create(AddData());
            var list = context.NationalIdentities.Count();
            Assert.Equal(1, list);

        }
        [Fact]
        public async Task UpdateNationalIdentities_ShouldReturnTrue()
        {
            var context = GetContext();
       
            var repos = new SQLNationalIDentityRepository(context);
            var user = AddData();
            await repos.Create(user);
            user.NationalId = 444;
           var updated=await repos.Update(user.Id, user);
            Assert.NotNull(updated);
            Assert.Equal(user.NationalId, updated.NationalId);

        }
        [Fact]
        public async Task DeleteNationalIdentities_ShouldReturnTrue()
        {
            var context = GetContext();
            var user = AddData();
            var repos=new SQLNationalIDentityRepository(context);
            await repos.Create(user);
           var deleted=await repos.Delete(user.Id);
            Assert.NotNull(deleted);
            Assert.Equal(deleted.NationalId, user.NationalId);
            Assert.Equal(deleted.Id, user.Id);
        }
        private static NationalIdentity AddData()
        {
            return new NationalIdentity
            {
                Id = Guid.NewGuid().ToString(),
                NationalId = 222
            };
        }
    }
}
