using System.Threading.Tasks;
using BookShop.Services.Interfaces;

namespace BookShop.Services.Services
{
    public class BasketService : IBasketService
    {
        public Task<double> GetTotalCostAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}