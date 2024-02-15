using Microsoft.EntityFrameworkCore;
using WebApplication1.contratos;
using WebApplication1.Entities;

namespace WebApplication1.Repositorios.DataAcess
{
    public class LeilaoRepositorio : IAuctionRepository
    {
        private readonly projetoDBcontext _dBcontext;
        public LeilaoRepositorio(projetoDBcontext dBcontext) => _dBcontext = dBcontext;

        public Auction? GetCurrent()
        {
            var today = DateTime.Now;
            return _dBcontext
                .Auctions
                .Include(auction => auction.Items)
                .FirstOrDefault(auction => today >= auction.Starts);
        }
    }
}
