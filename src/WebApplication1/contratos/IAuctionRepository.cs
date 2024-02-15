using WebApplication1.Entities;

namespace WebApplication1.contratos
{
    public interface IAuctionRepository
    {
        Auction? GetCurrent();
    }
}
