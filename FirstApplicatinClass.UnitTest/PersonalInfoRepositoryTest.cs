using FirstApplicationClass.Service;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using FirstApplicationClass.Repository;
using FirstApplicationClass.Model;

namespace FirstApplicatinClass.UnitTest
{
    public class PersonalInfoRepositoryTest
    {
      private static PersonalDetailsRepository GetContext()
        {
            var DbContext = new DbContextOptionsBuilder<ApplicationDbContext>()
                            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            return new PersonalDetailsRepository(new ApplicationDbContext(DbContext));
        }

        [Fact]
        public async Task  PostPersonalDetails_AddPerson()
        {
            var context = GetContext();
          var personalInfo=  context.PostPersonalDetails(personalDetails());
            Assert.NotNull(personalInfo);
            Assert.Equal(1,context.ListOfPerson().Count);
            
        }
        [Fact]
        public async Task UpdatePersonalInfo_UpdatePerson_WhenExists()
        {
            var context = GetContext();
            await context.PostPersonalDetails(personalDetails());
            var personalInfo =await context.UpdatePersonalInfo("1",personalDetails());
            Assert.NotNull(personalInfo);
            Assert.Equal("User Information Update",personalInfo);
        }
        [Fact]
        public async Task DeletePerson_DeletePerson_WhenExists()
        {
            var context = GetContext();
            await context.PostPersonalDetails(personalDetails());

            var personalInfo = await context.DeletePerson("1");
            Assert.NotNull(personalInfo);
            Assert.Equal("User deleted successfully", personalInfo);
        }
        [Fact]
        public async  Task ListOfPerson_DisplayCountOfPerson ()
        {
            var context = GetContext();
            await context.PostPersonalDetails(personalDetails());

            var personalInfo =  context.ListOfPerson();
            Assert.NotNull(personalInfo);
            Assert.Equal(context.ListOfPerson().Count, 1);
        }

        public static PersonalDetails personalDetails()
        {
            return new PersonalDetails
            {
                Id=1,
                Address="test",
                LastName="test",
                FirstName="test",
                City="test",
                DOB="2004",
                EmailAddress="test@gmail.com",
                Income="Testing",
                NationalId=0,
                PhoneNumber="9876087769"
            };
        }

    }
   
}
