using System.Runtime.CompilerServices;
using WebApplication1.contratos;
using WebApplication1.Entities;
using WebApplication1.Repositorios;

namespace WebApplication1.services
{
    public class LoggedUser : ILoggerUsers
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly iUserRepository _repository;

        public LoggedUser(IHttpContextAccessor httpContext, iUserRepository repository)
        {
            _httpContextAccessor = httpContext;
            _repository = repository;
        }
        public User User()
        {

            var token = TokenOnRequest();

            var email = FromBase64String(token);

            return _repository.GetUserByEmail(email);

        }
        private string TokenOnRequest()
        {
            var authentication = _httpContextAccessor.HttpContext.Request.Headers.Authorization.ToString();


            return authentication["Bearer ".Length..];
        }

        private string FromBase64String(string base64)
        {
            var data = Convert.FromBase64String(base64);
            return System.Text.Encoding.UTF8.GetString(data);
        }
    }
}
