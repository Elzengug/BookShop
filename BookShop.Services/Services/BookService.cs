using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookShop.Core.Models;
using BookShop.Data.Repositories.Interfaces;
using BookShop.Services.Interfaces;

namespace BookShop.Services.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<ICollection<Book>> GetAllBooksAsync()
        {
            var books = await _bookRepository.GetItemsAsync();
            return books;
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            var book = await _bookRepository.FindFirstAsync(b => b.Id == id);
            return book;
        }

        public async Task<bool> RemoveBookAsync(int id)
        {
            var book = await GetBookByIdAsync(id);
            return await _bookRepository.RemoveAsync(book);
        }

        public async Task<Book> CreateBookAsync(Book book)
        {
            var addedBook = await _bookRepository.AddAsync(book);
            return addedBook;
        }

        public async Task<Book> EditBookAsync(Book book)
        {
            var editBook = await _bookRepository.UpdateAsync(book);
            return editBook;
        }
    }
}