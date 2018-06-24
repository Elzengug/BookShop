namespace BookShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStatusToBookOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookOrders", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BookOrders", "Status");
        }
    }
}
