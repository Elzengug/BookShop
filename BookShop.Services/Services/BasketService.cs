using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using BookShop.Core.Models;
using BookShop.Data.Repositories.Interfaces;
using BookShop.Services.Interfaces;

namespace BookShop.Services.Services
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository _basketRepository;

        private readonly IBookOrderService _bookOrderService;

        public BasketService(IBasketRepository basketRepository, IBookOrderService bookOrderService)
        {
            _basketRepository = basketRepository;
            _bookOrderService = bookOrderService;
        }

        public void Clear()
        {
            
        }

        public async Task<double> GetTotalCostAsync(string id)
        {
            ICollection<BookOrder> bookOrders = await _bookOrderService.GetBookOrdersByBasketId(id);
            double totalCost = bookOrders.Count;
            return totalCost;
        }

    }
}