using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Core.Models;
using BookShop.Data.Repositories.Interfaces;
using BookShop.Services.Interfaces;

namespace BookShop.Services.Services
{
    public class BasketService : IBasketService
    {
        private readonly IBookOrderService _bookOrderService;
        private readonly IBookOrderRepository _bookOrderRepository;
        private readonly IBookRepository _bookRepository;

        public BasketService(IBookOrderService bookOrderService, IBookOrderRepository bookOrderRepository, IBookRepository bookRepository)
        {
            _bookOrderService = bookOrderService;
            _bookOrderRepository = bookOrderRepository;
            _bookRepository = bookRepository;
        }

        public async Task<bool> Clear(string id)
        {
            try
            {
                ICollection<BookOrder> bookOrders = await _bookOrderService.GetBookOrdersByBasketId(id);
                foreach (var removedBookOrder in bookOrders)
                {
                    await _bookOrderRepository.RemoveAsync(removedBookOrder);
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<double> GetTotalCostAsync(string id)
        {
            ICollection<BookOrder> bookOrders = await _bookOrderService.GetBookOrdersByBasketId(id);
            double totalCost = bookOrders.Sum(x => x.Book.Price );
            return totalCost;
        }

        public async Task<bool> ConfirmOrder(string id)
        {
            try
            {
                ICollection<BookOrder> bookOrders = await _bookOrderService.GetBookOrdersByBasketId(id);
                foreach (var order in bookOrders)
                {
                    order.Book.Count -= order.Count;
                    await _bookRepository.UpdateAsync(order.Book);
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}