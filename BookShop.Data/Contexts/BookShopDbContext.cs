using System.Data.Entity;
using BookShop.Core.Models;
using BookShop.Core.Models.Authorization;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BookShop.Data.Contexts
{
    public class BookShopDbContext : DbContext, IDbContext
    {
        public const string ConnectionString =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BookShopDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public BookShopDbContext() : base(ConnectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin>().HasKey(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
            modelBuilder.Entity<IdentityUserRole>();
            modelBuilder.Entity<IdentityUser>().HasMany(p => p.Roles).WithOne().HasForeignKey(p => p.UserId).HasPrincipalKey(p => p.Id);
        }

        public static BookShopDbContext Create()
        {
            return new BookShopDbContext();
        }

        public IDbSet<Book> Books { get; set; }
        public IDbSet<BookOrder> BookOrders { get; set; }
        public IDbSet<Basket> Baskets { get; set; }
        public IDbSet<User> Users { get; set; }

    }
}