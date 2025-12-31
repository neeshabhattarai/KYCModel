using FirstApplicationClass.Model;
using FirstApplicationClass.Repository.Interface;
using FirstApplicationClass.Service;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FirstApplicationClass.Repository
{
    public class PersonalDetailsRepository:IPersonalInfo
    {
        private readonly ApplicationDbContext dbContext;
        public PersonalDetailsRepository(ApplicationDbContext applicationDb)
        {
           this.dbContext = applicationDb; 
        }
        public List<PersonalDetails> ListOfPerson()
        {
            var listOfPerson = dbContext.PersonalInfo.ToList();
            return listOfPerson;
        }
        public async Task<PersonalDetails> PostPersonalDetails(PersonalDetails person)
        {
            var result=await dbContext.PersonalInfo.AddAsync(person);
            await dbContext.SaveChangesAsync();
            return person;
        }
        public async Task<string> UpdatePersonalInfo(string id,PersonalDetails person)
        {
           
            var result = await dbContext.PersonalInfo.FindAsync(int.Parse(id));
            if (result == null)
            {
                return "User Not found";
            }
            result.PhoneNumber = person.PhoneNumber;
            result.FirstName = person.FirstName;
            result.LastName = person.LastName;
            result.EmailAddress = person.EmailAddress;
            await dbContext.SaveChangesAsync();
            return "User Information Update";

        }
        
        public async Task<string> DeletePerson(string id)
        {
            var user = await dbContext.PersonalInfo.FindAsync(Int32.Parse(id));
            if (user == null)
            {
                return "User Not found";
            }
            dbContext.PersonalInfo.Remove(user);
            await dbContext.SaveChangesAsync();

            return "User deleted successfully";
        }
    }
}
