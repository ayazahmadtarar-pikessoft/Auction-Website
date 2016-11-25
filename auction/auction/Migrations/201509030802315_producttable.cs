namespace auction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class producttable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        status = c.String(),
                        Publisheddate = c.DateTime(nullable: false),
                        Discription = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        categoryid = c.Int(nullable: false),
                        userID = c.Int(nullable: false),
                        PA_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.categoryid, cascadeDelete: true)
                .ForeignKey("dbo.Product_Auction", t => t.PA_ID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.userID, cascadeDelete: true)
                .Index(t => t.categoryid)
                .Index(t => t.userID)
                .Index(t => t.PA_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "userID", "dbo.Users");
            DropForeignKey("dbo.Products", "PA_ID", "dbo.Product_Auction");
            DropForeignKey("dbo.Products", "categoryid", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "PA_ID" });
            DropIndex("dbo.Products", new[] { "userID" });
            DropIndex("dbo.Products", new[] { "categoryid" });
            DropTable("dbo.Products");
        }
    }
}
