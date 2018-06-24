using System.Collections.Generic;
using System.Threading.Tasks;
using BookShop.Core.Enums;
using BookShop.Core.Models;
using BookShop.Data.Repositories.Interfaces;
using BookShop.Services.Interfaces;

namespace BookShop.Services.Services
{
    public class BookOrderService : IBookOrderService
    {
        private readonly IBookOrderRepository _bookOrderRepository;

        public BookOrderService(IBookOrderRepository bookOrderRepository)
        {
            _bookOrderRepository = bookOrderRepository;
        }
        public async Task<BookOrder> AddBookOrder(BookOrder bookOrder)
        {
            var addedBookOrder = await _bookOrderRepository.AddAsync(bookOrder);
            return addedBookOrder;
        }

        public async Task<ICollection<BookOrder>> GetActiveBookOrdersByBasketId(string basketId)
        {
            ICollection<BookOrder> bookOrder = await _bookOrderRepository
                .FindAllAsync(x => x.BasketId == basketId && x.Status == BookOrderStatus.Active);
            return bookOrder;
        }

        public async Task<bool> RemoveBookOrder(int id)
        {
            var bookOrder = await _bookOrderRepository.FindFirstAsync(x => x.Id == id);
            return await _bookOrderRepository.RemoveAsync(bookOrder);
        }
    }
}