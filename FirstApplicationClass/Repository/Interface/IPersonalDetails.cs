using FirstApplicationClass.Model.Domains;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FirstApplicationClass.Repository.Interface
{
    public interface IPersonalDetails
    {
        List<PersonalDetails> ListOfPerson(string? filterBy,string? filterQuery,string? sortBy,bool isAscending = true,int pageNumber = 1, int pageSize = 100);

        Task<PersonalDetails> GetById(string id);
        Task<PersonalDetails> PostPersonalDetails(PersonalDetails person);
        Task<PersonalDetails> UpdatePersonalInfo(string id, PersonalDetails person);
        Task<PersonalDetails?> DeletePerson(string id);
    }
}
