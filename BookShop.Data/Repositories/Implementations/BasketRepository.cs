using BookShop.Core.Models;
using BookShop.Data.Contexts;
using BookShop.Data.Repositories.Interfaces;

namespace BookShop.Data.Repositories.Implementations
{
    public class BasketRepository : GenericRepository<Basket, string>, IBasketRepository
    {
        public BasketRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}