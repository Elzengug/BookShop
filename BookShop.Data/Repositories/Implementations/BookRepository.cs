using BookShop.Core.Models;
using BookShop.Data.Contexts;
using BookShop.Data.Repositories.Interfaces;

namespace BookShop.Data.Repositories.Implementations
{
    public class BookRepository : GenericRepository<Book, int>, IBookRepository
    {
        public BookRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}