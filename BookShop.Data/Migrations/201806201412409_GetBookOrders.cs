namespace BookShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GetBookOrders : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.BookOrders", new[] { "Basket_Id" });
            DropColumn("dbo.BookOrders", "BasketId");
            RenameColumn(table: "dbo.BookOrders", name: "Basket_Id", newName: "BasketId");
            AlterColumn("dbo.BookOrders", "BasketId", c => c.String(maxLength: 128));
            CreateIndex("dbo.BookOrders", "BasketId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.BookOrders", new[] { "BasketId" });
            AlterColumn("dbo.BookOrders", "BasketId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.BookOrders", name: "BasketId", newName: "Basket_Id");
            AddColumn("dbo.BookOrders", "BasketId", c => c.Int(nullable: false));
            CreateIndex("dbo.BookOrders", "Basket_Id");
        }
    }
}
