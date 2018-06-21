using System.Collections.Generic;
using BookShop.Core.Models;

namespace BookShop.WebMVC.ViewModels
{
    public class BasketVIewModel
    {
        public ICollection<BookOrder> BookOrders { get; set; }
        public double TotalCost { get; set; }
    }
}