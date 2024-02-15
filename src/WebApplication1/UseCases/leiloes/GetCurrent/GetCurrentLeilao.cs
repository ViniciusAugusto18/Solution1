using Microsoft.EntityFrameworkCore;
using WebApplication1.contratos;
using WebApplication1.Entities;
using WebApplication1.Repositorios;

namespace WebApplication1.UseCases.leiloes.GetCurrent
{
    public class GetCurrentLeilao
    {
        private readonly IAuctionRepository _repository;

        public GetCurrentLeilao(IAuctionRepository repository) => _repository = repository;
        
            
        
        public Auction? Execute() // ? e a forma de falar q vai retorna um
                                  // valor nulo se n for achado nada no banco de dados 
        {
            return _repository.GetCurrent();

        }
    }
}
