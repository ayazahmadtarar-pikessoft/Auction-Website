using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace auction.Models
{
    public class Auction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Auction_ID { get; set; }

        [DataType(DataType.Date)]
        public DateTime Auction_Strat { get; set; }

        [DataType(DataType.Date)]
        public DateTime Auction_End { get; set; }


        public  string Auction_Winner { get; set; }


        public Double winning_amount { get; set; }


        public int PA_ID { get; set; }

        [ForeignKey("PA_ID")]
        public virtual Product_Auction Product_Auction { get; set; }
    }
}