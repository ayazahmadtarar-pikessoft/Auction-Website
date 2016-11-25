namespace auction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class images : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "PictureId", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "Name", c => c.String());
            AddColumn("dbo.Products", "Size", c => c.Long(nullable: false));
            AddColumn("dbo.Products", "Path", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Path");
            DropColumn("dbo.Products", "Size");
            DropColumn("dbo.Products", "Name");
            DropColumn("dbo.Products", "PictureId");
        }
    }
}
