namespace BookShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class role1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Users", newName: "IdentityUsers");
            DropForeignKey("dbo.IdentityUserClaims", "UserId", "dbo.Users");
            DropForeignKey("dbo.IdentityUserRoles", "UserId", "dbo.Users");
            DropIndex("dbo.IdentityUserClaims", new[] { "UserId" });
            DropIndex("dbo.IdentityUserRoles", new[] { "UserId" });
            RenameColumn(table: "dbo.IdentityUserLogins", name: "User_Id", newName: "IdentityUser_Id");
            RenameIndex(table: "dbo.IdentityUserLogins", name: "IX_User_Id", newName: "IX_IdentityUser_Id");
            AddColumn("dbo.IdentityUsers", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.IdentityUserClaims", "IdentityUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.IdentityUserRoles", "IdentityUser_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.IdentityUserClaims", "UserId", c => c.String());
            CreateIndex("dbo.IdentityUserClaims", "IdentityUser_Id");
            CreateIndex("dbo.IdentityUserRoles", "IdentityUser_Id");
            AddForeignKey("dbo.IdentityUserClaims", "IdentityUser_Id", "dbo.IdentityUsers", "Id");
            AddForeignKey("dbo.IdentityUserRoles", "IdentityUser_Id", "dbo.IdentityUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRoles", "IdentityUser_Id", "dbo.IdentityUsers");
            DropForeignKey("dbo.IdentityUserClaims", "IdentityUser_Id", "dbo.IdentityUsers");
            DropIndex("dbo.IdentityUserRoles", new[] { "IdentityUser_Id" });
            DropIndex("dbo.IdentityUserClaims", new[] { "IdentityUser_Id" });
            AlterColumn("dbo.IdentityUserClaims", "UserId", c => c.String(maxLength: 128));
            DropColumn("dbo.IdentityUserRoles", "IdentityUser_Id");
            DropColumn("dbo.IdentityUserClaims", "IdentityUser_Id");
            DropColumn("dbo.IdentityUsers", "Discriminator");
            RenameIndex(table: "dbo.IdentityUserLogins", name: "IX_IdentityUser_Id", newName: "IX_User_Id");
            RenameColumn(table: "dbo.IdentityUserLogins", name: "IdentityUser_Id", newName: "User_Id");
            CreateIndex("dbo.IdentityUserRoles", "UserId");
            CreateIndex("dbo.IdentityUserClaims", "UserId");
            AddForeignKey("dbo.IdentityUserRoles", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.IdentityUserClaims", "UserId", "dbo.Users", "Id");
            RenameTable(name: "dbo.IdentityUsers", newName: "Users");
        }
    }
}
