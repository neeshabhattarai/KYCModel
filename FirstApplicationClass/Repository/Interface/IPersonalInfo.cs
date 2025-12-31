using FirstApplicationClass.Model;
using System.Threading.Tasks;

namespace FirstApplicationClass.Repository.Interface
{
    public interface IPersonalInfo
    {
        List<PersonalDetails> ListOfPerson();
        Task<PersonalDetails> PostPersonalDetails(PersonalDetails person);
        Task<string> UpdatePersonalInfo(string id, PersonalDetails person);
        Task<string> DeletePerson(string id);
    }
}
