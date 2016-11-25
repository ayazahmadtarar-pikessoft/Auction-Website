namespace auction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class auctiontable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Auctions",
                c => new
                    {
                        Auction_ID = c.Int(nullable: false, identity: true),
                        Auction_Strat = c.DateTime(nullable: false),
                        Auction_End = c.DateTime(nullable: false),
                        Auction_Winner = c.String(),
                        winning_amount = c.Double(nullable: false),
                        PA_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Auction_ID)
                .ForeignKey("dbo.Product_Auction", t => t.PA_ID, cascadeDelete: true)
                .Index(t => t.PA_ID);
            
            CreateTable(
                "dbo.Product_Auction",
                c => new
                    {
                        PA_ID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.PA_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Auctions", "PA_ID", "dbo.Product_Auction");
            DropIndex("dbo.Auctions", new[] { "PA_ID" });
            DropTable("dbo.Product_Auction");
            DropTable("dbo.Auctions");
        }
    }
}
