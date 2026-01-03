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
    public class SQLPersonalDetailsRepository : IPersonalDetails
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public SQLPersonalDetailsRepository(ApplicationDbContext applicationDb)
        {
            this.dbContext = applicationDb;
            this.mapper = mapper;
        }
        public List<PersonalDetails> ListOfPerson(string? filterBy, string? filterQuery, string? sortBy, bool isAscending = true, int pageNumber = 1, int pageSize = 100)
        {
            //throw new Exception("Something you did wrong");
            var listOfPerson = dbContext.PersonalInfo.Include(x => x.NationalIdentity).AsQueryable();
            //Filtering
            if (!String.IsNullOrWhiteSpace(filterBy) && !String.IsNullOrWhiteSpace(filterQuery)) {
                if (filterBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    listOfPerson=listOfPerson.Where(x=>x.FirstName==filterBy);
                }
                    }
            //Sorting
            if (!String.IsNullOrWhiteSpace(sortBy))
            {
                if (sortBy.Equals("Id", StringComparison.OrdinalIgnoreCase))
                {
                    listOfPerson = isAscending ? listOfPerson.OrderBy(x => x.Id) : listOfPerson.OrderByDescending(x => x.Id);
                } else if (sortBy.Equals("FirstName", StringComparison.OrdinalIgnoreCase))
                {
                    listOfPerson = isAscending ? listOfPerson.OrderBy(x => x.FirstName) : listOfPerson.OrderByDescending(x => x.FirstName);
                }
                else if (sortBy.Equals("LastName", StringComparison.OrdinalIgnoreCase))
                {
                    listOfPerson = isAscending ? listOfPerson.OrderBy(x => x.LastName) : listOfPerson.OrderByDescending(x => x.LastName);
                }
                else if (sortBy.Equals("Address", StringComparison.OrdinalIgnoreCase))
                {
                    listOfPerson = isAscending ? listOfPerson.OrderBy(x => x.Address) : listOfPerson.OrderByDescending(x => x.Address);
                }
                else
                {
                     
                        listOfPerson = isAscending ? listOfPerson.OrderBy(x => x.City) : listOfPerson.OrderByDescending(x => x.City);
                    
                }
            }
            //Pagination
            var count = (pageNumber - 1) * pageSize;
            listOfPerson.Skip(count).Take(pageSize);

            return listOfPerson.ToList();

        }
        public async Task<PersonalDetails> PostPersonalDetails(PersonalDetails person)
        {
            var result = await dbContext.PersonalInfo.AddAsync(person);
            await dbContext.SaveChangesAsync();
            return person;
        }
        public async Task<PersonalDetails> UpdatePersonalInfo(string id, PersonalDetails person)
        {

            var result = await dbContext.PersonalInfo.FindAsync(id);
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
            var user = await dbContext.PersonalInfo.FindAsync(id);
            if (user == null)
            {
                return null;
            }

            dbContext.PersonalInfo.Remove(user);
            await dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<PersonalDetails> GetById(string id)
        {
            var result = await dbContext.PersonalInfo.FirstOrDefaultAsync(x => x.Id == id);
            if (result == null)
            {
                return null;
            }
            return result;
        }

       
    }
}
