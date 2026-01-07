using FirstApplicationClass.Service;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using FirstApplicationClass.Repository;
using FirstApplicationClass.Model.Domains;
using Moq;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using FirstApplicationClass.Repository.Interface;
using System.Net;
using System.Threading.Tasks;

namespace FirstApplicatinClass.UnitTest
{
    public class PersonalInfoRepositoryTest
    {
        public ApplicationDbContext GetDBContext()
        {
            var context = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName:Guid.NewGuid().ToString()).Options;
            return new ApplicationDbContext(context);
        }
        [Fact]
        public  async void PostPersonalDetails_ToCheckResult()
        {
          var context = GetDBContext();
          IPersonalDetails personalRepo = new SQLPersonalDetailsRepository(context);
          var persons=await personalRepo.PostPersonalDetails(GetPersonalDetails());

          var count = personalRepo.ListOfPerson(filterBy: null, filterQuery: null, sortBy: null).Count();
          Console.WriteLine(count);
          Assert.Equal(1,count);
        }
        [Fact]
        public void ListOfPerson_Count()
        {
           var moq=new Mock<IPersonalDetails>();
           var result=moq.Setup(x => x.ListOfPerson(filterBy:"FirstName",filterQuery:"Test",sortBy:"FirstName",isAscending:true))
                .Returns(new List<PersonalDetails> { GetPersonalDetails() });
            Assert.NotNull(result);
         

        }
        [Fact]
        public async Task DeletePersonalInfo_ReturnsTrue()
        {
            var context = GetDBContext();
            var result = new SQLPersonalDetailsRepository(context);
            var user = GetPersonalDetails();
           await result.PostPersonalDetails(user);
          var response= await result.DeletePerson(user.Id);
            Assert.Equal(response.Id,user.Id);


        }
        [Fact]
        public async Task UpdatePersonalInfo_ReturnTrue()
        {
            var context=GetDBContext();
            var user=GetPersonalDetails();
            var repos = new SQLPersonalDetailsRepository(context);
            var result=await repos.PostPersonalDetails(user);
            user.FirstName = "alter";
            user.LastName = "test";
            var updatedResult = await repos.UpdatePersonalInfo(user.Id,user);
            Assert.Equal(updatedResult.Id, user.Id);
            Assert.Equal(updatedResult.FirstName, "alter");


        }

        public static PersonalDetails GetPersonalDetails()
        {
            var id=Guid.NewGuid().ToString();
            return new PersonalDetails
            {
                Id = Guid.NewGuid().ToString(),
                Address = "test",
                LastName = "test",
                FirstName = "test",
                City = "test",
                DOB = "2004",
                EmailAddress = "test@gmail.com",
                Income = "Testing",
                PhoneNumber = "9876087769",
                NationalIdentityId=id,
                NationalIdentity=new NationalIdentity
                {
                    Id=id,
                    NationalId=333
                }
            };
        }

    }

}
