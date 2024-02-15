using WebApplication1.Entities;

namespace WebApplication1.contratos
{
    public interface iUserRepository
    {
        bool ExistUserWithEmail(string email);

        User GetUserByEmail(string email);
    }
}
