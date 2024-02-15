using WebApplication1.contratos;
using WebApplication1.Entities;

namespace WebApplication1.Repositorios.DataAcess
{
    public class UserRepository : iUserRepository
    {
        private readonly projetoDBcontext _dBcontext;
        public UserRepository(projetoDBcontext dBcontext) => _dBcontext = dBcontext;

        public bool ExistUserWithEmail(string email) 
        {
            return _dBcontext.Users.Any(user => user.Email.Equals(email));
        }

        public User GetUserByEmail(string email)
        {
            return _dBcontext.Users.FirstOrDefault(user => user.Email.Equals(email));
        }


    }
}
