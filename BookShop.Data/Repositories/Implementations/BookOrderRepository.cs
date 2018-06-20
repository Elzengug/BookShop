using System.Data.Entity;
using System.Linq;
using BookShop.Core.Models;
using BookShop.Data.Contexts;
using BookShop.Data.Repositories.Interfaces;

namespace BookShop.Data.Repositories.Implementations
{
    public class BookOrderRepository : GenericRepository<BookOrder, int>, IBookOrderRepository
    {
        public BookOrderRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<BookOrder> DetachedQueryable =>
            base.DetachedQueryable.Include(bo => bo.Book).Include(bo => bo.Basket);
    }
}