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
    }
}