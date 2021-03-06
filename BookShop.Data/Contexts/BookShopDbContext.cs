﻿using System.Data.Entity;
using BookShop.Core.Models;
using BookShop.Core.Models.Authorization;
using BookShop.Data.Initializer;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BookShop.Data.Contexts
{
    public class BookShopDbContext : DbContext, IDbContext
    {

        public const string ConnectionString =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BookShopDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public BookShopDbContext() : base(ConnectionString)
        {
            Database.SetInitializer<BookShopDbContext>(new RoleInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin>().HasKey(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
            modelBuilder.Entity<IdentityUserRole>();
        }

        public static BookShopDbContext Create()
        {
            return new BookShopDbContext();
        }

        public IDbSet<Book> Books { get; set; }
        public IDbSet<BookOrder> BookOrders { get; set; }
        public IDbSet<Basket> Baskets { get; set; }
        public IDbSet<User> Users { get; set; }
        public IDbSet<IdentityRole> Roles { get; set; }

    }
}