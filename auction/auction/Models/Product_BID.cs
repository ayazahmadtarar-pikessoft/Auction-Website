using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace auction.Models
{
    public class Product_BID
    {
        public Product Products { get; set; }
        public Bid Bid_list { get; set; }
        public Category Category { get; set; }
        public Product_Auction Product_Auction { get; set; }
        public User User { get; set; }
    }
}