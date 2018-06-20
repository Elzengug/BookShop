using System.Data.Entity;
using BookShop.Core.Models;
using BookShop.Data.Contexts;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BookShop.Data.Initializer
{
    public class RoleInitializer : DropCreateDatabaseIfModelChanges<BookShopDbContext>
    {
        protected override void Seed(BookShopDbContext db)
        {
            Book user = new Book { Name = "User"};
            //IdentityRole admin = new IdentityRole { Name = "Admin" };

            db.Books.Add(user);
            //db.IdentityRoles.Add(admin);
            db.SaveChanges();
            base.Seed(db);
        }
    }
}