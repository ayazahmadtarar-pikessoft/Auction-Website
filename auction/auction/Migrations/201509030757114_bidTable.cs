namespace auction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bidTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bids",
                c => new
                    {
                        Bid_ID = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        userID = c.Int(nullable: false),
                        Auction_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Bid_ID)
                .ForeignKey("dbo.Auctions", t => t.Auction_ID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.userID, cascadeDelete: true)
                .Index(t => t.userID)
                .Index(t => t.Auction_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bids", "userID", "dbo.Users");
            DropForeignKey("dbo.Bids", "Auction_ID", "dbo.Auctions");
            DropIndex("dbo.Bids", new[] { "Auction_ID" });
            DropIndex("dbo.Bids", new[] { "userID" });
            DropTable("dbo.Bids");
        }
    }
}
