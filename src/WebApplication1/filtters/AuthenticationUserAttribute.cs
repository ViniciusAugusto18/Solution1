using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using WebApplication1.contratos;
using WebApplication1.Repositorios;

namespace WebApplication1.filtters
{
    public class AuthenticationUserAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private readonly iUserRepository _repository;
        public AuthenticationUserAttribute(iUserRepository repository) => _repository = repository;
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            try
            {
                var token = TokenOnRequest(context.HttpContext);

                

                var email = FromBase64String(token);

                var exist = _repository.ExistUserWithEmail(email);

                if (exist == false)
                {
                    context.Result = new UnauthorizedObjectResult("Email not values");
                }
            }
            catch (Exception ex) 
            {
                context.Result = new UnauthorizedObjectResult(ex.Message);
            }
            



        }
        private string TokenOnRequest(HttpContext context)
        {
            var authentication = context.Request.Headers.Authorization.ToString();

            if(!string.IsNullOrEmpty(authentication) )
            {
                throw new Exception("Token perdido");
            }

            return authentication ["Bearer ".Length..];
        }

        private string FromBase64String(string base64)
        {
            var data = Convert.FromBase64String(base64);
            return System.Text.Encoding.UTF8.GetString(data);
        }
    }
}
