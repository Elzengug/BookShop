using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using BookShop.Core.Models;
using BookShop.Services.Interfaces;

namespace BookShop.WebMVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SellerController : Controller
    {
        private readonly IBookService _bookService;

        public SellerController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<ActionResult> Index()
        {
            var books = await _bookService.GetAllBooksAsync();
            return View(books);
        }

        public async Task<ActionResult> Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = await _bookService.GetBookByIdAsync(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Count,Author,Price,PublicationDate,Image")] Book book)
        {
            if (ModelState.IsValid)
            {
                await _bookService.CreateBookAsync(book);
                return RedirectToAction("Index");
            }

            return View(book);
        }

        public async Task<ActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = await _bookService.GetBookByIdAsync(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Count,Author,Price,PublicationDate,Image")] Book book)
        {
            if (ModelState.IsValid)
            {
                await _bookService.EditBookAsync(book);
                return RedirectToAction("Index");
            }
            return View(book);
        }

        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = await _bookService.GetBookByIdAsync(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            bool isDeleted = await _bookService.RemoveBookAsync(id);
            if (!isDeleted)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Index");
        }
    }
}
