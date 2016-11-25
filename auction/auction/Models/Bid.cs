using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace auction.Models
{
    public class Bid
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Bid_ID { get; set; }

        public decimal Price { get; set; }




        public int userID { get; set; }

        [ForeignKey("userID")]
        public virtual User User { get; set; }

        public int Auction_ID { get; set; }

        [ForeignKey("Auction_ID")]
        public virtual Auction Auction { get; set; }
    }
}