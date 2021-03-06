﻿using System.Collections.Generic;
using System.Threading.Tasks;
using BookShop.Core.Models;

namespace BookShop.Services.Interfaces
{
    public interface IBookOrderService
    {
        Task<BookOrder> AddBookOrder(BookOrder bookOrder);
        Task<ICollection<BookOrder>> GetActiveBookOrdersByBasketId(string basketId);
        Task<bool> RemoveBookOrder(int id);
    }
}