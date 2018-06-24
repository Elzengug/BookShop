using System.Threading.Tasks;
using System.Web.Mvc;
using BookShop.Core.Enums;
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
        public async Task<ActionResult> Index(string message)
        {
            if (message != null)
            {
                ViewBag.StatusMessage = message;
            }
            var books = await _bookService.GetAllBooksAsync();
            return View(books);
        }

        [HttpPost]
        public async Task<ActionResult> AddBookToBasket(int bookId, int count)
        {

            if (count < 1)
            {
                return RedirectToAction("Index", new { Message = "Invalid books count" });
            }

            var book = await _bookService.GetBookByIdAsync(bookId);
            if (count > book.Count)
            {
                return RedirectToAction("Index", new { Message = "Not enough books" });
            }

            var bookOrder = new BookOrder
            {
                BookId = bookId,
                Count = count,
                BasketId = User.Identity.GetUserId<string>(),
                Status = BookOrderStatus.Active
            };

            await _bookOrderService.AddBookOrder(bookOrder);
            return RedirectToAction("Index");
        }



    }
}