using FirstApplicationClass.Model.Domains;
using System.Threading.Tasks;

namespace FirstApplicationClass.Repository.Interface
{
    public interface IPersonalDetails
    {
        List<PersonalDetails> ListOfPerson();

        Task<PersonalDetails> GetById(string id);
        Task<PersonalDetails> PostPersonalDetails(PersonalDetails person);
        Task<PersonalDetails> UpdatePersonalInfo(string id, PersonalDetails person);
        Task<PersonalDetails?> DeletePerson(string id);
    }
}
