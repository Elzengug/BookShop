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
            string id = User.Identity.GetUserId();
            var bookOrders = await _bookOrderService.GetBookOrdersByBasketId(id);
            return View(bookOrders);
        }
    }
}
