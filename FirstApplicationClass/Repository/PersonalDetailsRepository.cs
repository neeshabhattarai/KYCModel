using AutoMapper;
using FirstApplicationClass.Model.Domains;
using FirstApplicationClass.Model.DTO;
using FirstApplicationClass.Repository.Interface;
using FirstApplicationClass.Service;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstApplicationClass.Repository
{
    public class PersonalDetailsRepository:IPersonalDetails
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public PersonalDetailsRepository(ApplicationDbContext applicationDb)
        {
           this.dbContext = applicationDb;
            this.mapper = mapper;
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
        public async Task<PersonalDetails> UpdatePersonalInfo(string id,PersonalDetails person)
        {
           
            var result = await dbContext.PersonalInfo.FindAsync(int.Parse(id));
            if (result == null)
            {
                return null;
            }
            result.PhoneNumber = person.PhoneNumber;
            result.FirstName = person.FirstName;
            result.LastName = person.LastName;
            result.EmailAddress = person.EmailAddress;
            await dbContext.SaveChangesAsync();
            return result;

        }
        
        public async Task<PersonalDetails?> DeletePerson(string id)
        {
            var user =await  dbContext.PersonalInfo.FindAsync(Int32.Parse(id));
            if (user == null)
            {
                return null;
            }
            
            dbContext.PersonalInfo.Remove(user);
             await dbContext.SaveChangesAsync();

            return user ;
        }

        public async Task<PersonalDetails> GetById(string id)
        {
            var result = await dbContext.PersonalInfo.FirstOrDefaultAsync(x=>x.Id==int.Parse(id));
            if (result == null)
            {
                return null;
            }
            return result;
        }
    }
}
