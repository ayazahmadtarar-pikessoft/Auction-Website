namespace auction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        userID = c.Int(nullable: false, identity: true),
                        username = c.String(nullable: false, maxLength: 20),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(),
                        Password = c.String(),
                        Dob = c.String(),
                        City = c.String(),
                        Address = c.String(),
                        Gender = c.String(),
                        MobileNo = c.String(),
                    })
                .PrimaryKey(t => t.userID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
