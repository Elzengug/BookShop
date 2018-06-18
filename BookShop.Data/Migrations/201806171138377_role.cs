namespace BookShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class role : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UserRoles", newName: "IdentityUserRoles");
            RenameTable(name: "dbo.Roles", newName: "IdentityRoles");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.IdentityRoles", newName: "Roles");
            RenameTable(name: "dbo.IdentityUserRoles", newName: "UserRoles");
        }
    }
}
