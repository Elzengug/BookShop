using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BookShop.Services.Interfaces;

namespace BookShop.WebMVC.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET: Book
        public async Task<ActionResult> Index()
        {
           var books = await _bookService.GetAllBooksAsync();
            return View(books);
        }
    }
}