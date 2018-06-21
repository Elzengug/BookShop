using System.Collections.Generic;
using System.Threading.Tasks;
using BookShop.Core.Models;

namespace BookShop.Services.Interfaces
{
    public interface IBasketService
    {
        Task<double> GetTotalCostAsync(string id);
        Task<bool> Clear(string id);
        Task<bool> ConfirmOrder(string id);
    }
}