using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Core.Enums;
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
        private readonly IBasketRepository _basketRepository;
        private readonly IBookService _bookService;

        public BasketService(IBookOrderService bookOrderService,
            IBookOrderRepository bookOrderRepository,
            IBookRepository bookRepository,
            IBasketRepository basketRepository,
            IBookService bookService)
        {
            _bookOrderService = bookOrderService;
            _bookOrderRepository = bookOrderRepository;
            _bookRepository = bookRepository;
            _basketRepository = basketRepository;
            _bookService = bookService;
        }

        public async Task<bool> Clear(string id)
        {
            try
            {
                ICollection<BookOrder> bookOrders = await _bookOrderService.GetActiveBookOrdersByBasketId(id);
                foreach (var bookOrder in bookOrders)
                {
                    bookOrder.Book = null;
                    bookOrder.Basket = null;
                    bookOrder.Status = BookOrderStatus.Completed;
                    await _bookOrderRepository.UpdateAsync(bookOrder);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<double> GetTotalCostAsync(string id)
        {
            ICollection<BookOrder> bookOrders = await _bookOrderService.GetActiveBookOrdersByBasketId(id);
            double totalCost = bookOrders.Sum(x => x.Book.Price * x.Count);
            return totalCost;
        }

        public async Task<bool> ConfirmOrder(string id)
        {

                ICollection<BookOrder> bookOrders = await _bookOrderService.GetActiveBookOrdersByBasketId(id);
                foreach (var order in bookOrders)
                {

                    var book = await _bookService.GetBookByIdAsync(order.BookId);
                    book.Count -= order.Count;
                    if (book.Count == 0)
                    {
                        await _bookRepository.RemoveAsync(book);
                    }
                    else if (book.Count < 0)
                    {
                        await _bookRepository.RemoveAsync(book);
                        throw new Exception($"Not enough books for{book.Name}");
                    }
                    else
                    {
                        await _bookRepository.UpdateAsync(book);
                    }
                }
                return true;         
        }

        public async Task<Basket> AddAsync(Basket basket)
        {
            var addedBasket = await _basketRepository.AddAsync(basket);
            return addedBasket;
        }
    }
}