using Microsoft.EntityFrameworkCore;
using WebApplication1.Controllers;
using WebApplication1.Entities;

namespace WebApplication1.Repositorios
{
    public class projetoDBcontext : DbContext 
    {
        public projetoDBcontext(DbContextOptions options) : base(options) { }
        
        public DbSet<Auction> Auctions { get; set; }

        public DbSet<User> Users { get; set; }

         public DbSet<Offer> Offers { get; set; }
       
    }
}
