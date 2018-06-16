using System.Collections.Generic;
using System.Threading.Tasks;
using BookShop.Core.Models;
using BookShop.Services.Interfaces;

namespace BookShop.Services.Services
{
    public class BookService : IBookService
    {
        public Task<ICollection<Book>> GetAllBooksAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<ICollection<Book>> GetBookByIdAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<ICollection<Book>> RemoveBookAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}