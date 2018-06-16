using System.Collections.Generic;
using System.Threading.Tasks;
using BookShop.Core.Models;

namespace BookShop.Services.Interfaces
{
    public interface IBookService
    {
        Task<ICollection<Book>> GetAllBooksAsync();
        Task<ICollection<Book>> GetBookByIdAsync();
        Task<ICollection<Book>> RemoveBookAsync();
    }
}