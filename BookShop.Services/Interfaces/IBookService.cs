using System.Collections.Generic;
using System.Threading.Tasks;
using BookShop.Core.Models;

namespace BookShop.Services.Interfaces
{
    public interface IBookService
    {
        Task<ICollection<Book>> GetAllBooksAsync();
        Task<Book> GetBookByIdAsync(int id);
        Task<bool> RemoveBookAsync(int id);
        Task<Book> CreateBookAsync(Book book);
        Task<Book> EditBookAsync(Book book);
    }
}