using auction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace auction
{
    public class addbid
    {
        public static void            addbidinview(int id,decimal price,int userid)
        {
            //  auctionContext db = new auctionContext();
            //  Bid bid = new Bid();

            //  //Add new values to each fields
            //  bid.Bid_ID = 2;
            //  bid.Price = price;
            //  bid.User.userID = id;
            //bid.Auction.Auction_ID = id;





            //      db.Bids.Add(bid);
            //  db.SaveChanges();


            

            auctionContext db = new auctionContext();
            db.Bids.Add(new Bid() { Auction_ID = id, userID = userid, Price = price });

            db.SaveChanges();
            


        }
    }
}