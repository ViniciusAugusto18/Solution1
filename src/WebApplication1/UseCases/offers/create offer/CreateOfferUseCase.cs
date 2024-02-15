using WebApplication1.communication.Request;
using WebApplication1.contratos;
using WebApplication1.Entities;
using WebApplication1.Repositorios;
using WebApplication1.services;

namespace WebApplication1.UseCases.offers.create_offer
{
    public class CreateOfferUseCase
    {

        private readonly ILoggerUsers _loggedUsers;
        private readonly IOfferRepository _repository;

        public CreateOfferUseCase(ILoggerUsers loggedUsers, IOfferRepository repository)
        {
            _loggedUsers = loggedUsers;
            _repository = repository;
        }
        
        public int Execute(int ItemId,RequestCreatedOfferJson request) // ? e a forma de falar q vai retorna um
                                  // valor nulo se n for achado nada no banco de dados 
        {
            

            var user = _loggedUsers.User();

            var offer = new Offer
            {
                CreatedOn = DateTime.Now,
                ItemId = ItemId,
                Price = request.price,
                UserId = user.Id
            };

            _repository.Add(offer);
            return offer.Id;
        }
    }
}
