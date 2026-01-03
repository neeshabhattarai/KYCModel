using FirstApplicationClass.Model.Domains;

namespace FirstApplicationClass.Repository.Interface
{
    public interface IImage
    {
        Task<RegisterImage> Upload(RegisterImage registerImage);
    }
}
