namespace BookShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Image", c => c.Binary());
            AlterColumn("dbo.Books", "PublicationDate", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "PublicationDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Books", "Image");
        }
    }
}
