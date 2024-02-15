using Microsoft.EntityFrameworkCore;
using WebApplication1.contratos;
using WebApplication1.Entities;


namespace WebApplication1.Repositorios.DataAcess
{
    
    public class OfferRepository : IOfferRepository
    {
        private readonly projetoDBcontext _dBcontext;
        public OfferRepository(projetoDBcontext dBcontext) => _dBcontext = dBcontext;

        public void Add(Offer offer)
        {
            _dBcontext.Offers.Add(offer);
            _dBcontext.SaveChanges();
        }
    }
}
