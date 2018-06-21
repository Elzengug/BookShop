using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookShop.Core.Models;
using BookShop.Data.Contexts;
using BookShop.Services.Interfaces;
using BookShop.WebMVC.ViewModels;
using Microsoft.AspNet.Identity;

namespace BookShop.WebMVC.Controllers
{
    public class BasketController : Controller
    {
        private readonly IBookOrderService _bookOrderService;
        private readonly IBasketService _basketService;

        public BasketController(IBookOrderService bookOrderService, IBasketService basketService)
        {
            _bookOrderService = bookOrderService;
            _basketService = basketService;
        }

        public async Task<ActionResult> Index()
        {
            BasketVIewModel basketVIewModel = new BasketVIewModel();
            string id = User.Identity.GetUserId();
            basketVIewModel.BookOrders = await _bookOrderService.GetBookOrdersByBasketId(id);
            basketVIewModel.TotalCost = await _basketService.GetTotalCostAsync(id);
            return View(basketVIewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Clear()
        {         
            string id = User.Identity.GetUserId();
            bool isDeleted = await _basketService.Clear(id);
            if (!isDeleted)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> ConfirmOrder()
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
