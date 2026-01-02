using Microsoft.AspNetCore.Identity;

namespace FirstApplicationClass.Repository.Interface
{
    public interface IToken
    {
        string Create(IdentityUser user, IList<string> roles);
    }
}
