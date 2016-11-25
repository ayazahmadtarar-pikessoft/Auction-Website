using System.Data.Entity;

namespace auction.Models
{
    public class auctionContext : DbContext
    {
        
        
    
        public auctionContext() : base("name=auctionContext")
        {
        }

        public  DbSet<User> Users { get; set; }

        public   DbSet<Category> Categories { get; set; }

        public  DbSet<Auction> Auctions { get; set; }

        public  DbSet<Product_Auction> Product_Auction { get; set; }

        public DbSet<Bid> Bids { get; set; }

        public  DbSet<Product> Products { get; set; }
    }
}
