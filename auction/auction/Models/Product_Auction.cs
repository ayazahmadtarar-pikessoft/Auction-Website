using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace auction.Models
{
    public class Product_Auction
   {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PA_ID { get; set; }

      

        //    public int Auction_ID { get; set; }
        //    [ForeignKey("Auction_ID")]
        //    public virtual Product Product { get; set; }



        //    public int ID { get; set; }
        //    [ForeignKey("ID")]
        //    public virtual Auction Auction { get; set; }
    }
}