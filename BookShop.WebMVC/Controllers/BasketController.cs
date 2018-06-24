using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using BookShop.Services.Interfaces;
using BookShop.WebMVC.ViewModels;
using Microsoft.AspNet.Identity;

namespace BookShop.WebMVC.Controllers
{
    [Authorize]
    public class BasketController : Controller
    {
        private readonly IBookOrderService _bookOrderService;
        private readonly IBasketService _basketService;

        public BasketController(IBookOrderService bookOrderService, IBasketService basketService)
        {
            _bookOrderService = bookOrderService;
            _basketService = basketService;
        }

        public async Task<ActionResult> Index(string message)
        {
            if (message != null)
            {
                ViewBag.StatusMessage = message;
            }

            BasketVIewModel basketVIewModel = new BasketVIewModel();
            string id = User.Identity.GetUserId();
            basketVIewModel.BookOrders = await _bookOrderService.GetActiveBookOrdersByBasketId(id);
            basketVIewModel.TotalCost = await _basketService.GetTotalCostAsync(id);
            return View(basketVIewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Clear()
        {
            try
            {
                string id = User.Identity.GetUserId();
                bool isDeleted = await _basketService.Clear(id);
                if (!isDeleted)
                {
                    return HttpNotFound();
                }

                return RedirectToAction("Index");
            }
            catch(Exception)
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult> ConfirmOrder()
        {
            try
            {
                string id = User.Identity.GetUserId();
                bool isConfirm = await _basketService.ConfirmOrder(id);
                bool clear = await _basketService.Clear(id);
                if (!isConfirm || !clear)
                {
                    return HttpNotFound();
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", new { Message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult> DeleteBookOrder(int bookOrderId)
        {
            bool isDeleted = await _bookOrderService.RemoveBookOrder(bookOrderId);
            if (!isDeleted)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Index");
        }
    }
}
