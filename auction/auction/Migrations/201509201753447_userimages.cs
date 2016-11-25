namespace auction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userimages : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "userimgName", c => c.String());
            AddColumn("dbo.Users", "userimgPath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "userimgPath");
            DropColumn("dbo.Users", "userimgName");
        }
    }
}
