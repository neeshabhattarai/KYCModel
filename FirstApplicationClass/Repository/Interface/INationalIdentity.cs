using FirstApplicationClass.Model.Domains;

namespace FirstApplicationClass.Repository.Interface
{
    public interface INationalIdentity
    {
        Task<NationalIdentity> Create(NationalIdentity identity);
        Task<NationalIdentity> Update(string id, NationalIdentity identity);
        Task<NationalIdentity> Delete(string id);


        Task<NationalIdentity> GetById(string id);
        Task<List<NationalIdentity>> GetAll();

    }
}
