using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BookShop.Core.Models;
using BookShop.Services.Interfaces;
using Microsoft.AspNet.Identity;

namespace BookShop.WebMVC.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IBookOrderService _bookOrderService;

        public BookController(IBookService bookService, IBookOrderService bookOrderService)
        {
            _bookService = bookService;
            _bookOrderService = bookOrderService;
        }

        // GET: Book
        public async Task<ActionResult> Index()
        {
           var books = await _bookService.GetAllBooksAsync();
            return View(books);
        }
        [HttpPost]
        public async Task<ActionResult> AddBookToBasket(int bookId, int count)
        {
            
            var bookOrder = new BookOrder
            {
                BookId = bookId,
                Count = count,
                BasketId = User.Identity.GetUserId<string>()
            };

           await _bookOrderService.AddBookOrder(bookOrder);
            return RedirectToAction("Index");
        }
        


    }
}