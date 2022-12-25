using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TimirzinEShop.Areas.Identity.Data;
using TimirzinEShop.Models;
using Rep = TimirzinEShop.Models.ProductRepository;

namespace TimirzinEShop.Controllers
{
    public class CartController : Controller
    {
        [HttpGet]
        public void ClearCart()
        {
            Cart cart = HttpContext.Session.Get<Cart>("Cart") ?? new Cart();
            cart.Products.Clear();
        }
        [HttpPost]
        public IActionResult Ordered(ClientInfo clientInfo)
        {
            Cart cart = HttpContext.Session.Get<Cart>("Cart") ?? new Cart();
            var orderParams = new OrderParams(cart, clientInfo);
            HttpContext.Session.Set<Cart>("Cart", new Cart());
            return View(orderParams);
        }
        [HttpGet]
        public int GetCartNumber()
        {
            Cart cart = HttpContext.Session.Get<Cart>("Cart") ?? new Cart();
            return cart.GetTotalNumber();
        }
        public IActionResult Index()
        {
            return RedirectToAction("Index","Home");
        }
        public IActionResult Order()
        {
            Cart cart = HttpContext.Session.Get<Cart>("Cart") ?? new Cart();
            EShopUser user = Rep.FindUserByName(User.Identity.Name);
            OrderModel model = new OrderModel(cart, user);
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            Cart cart = HttpContext.Session.Get<Cart>("Cart") ?? new Cart();
            cart.Delete(Rep.GetViewById(id));
            HttpContext.Session.Set<Cart>("Cart", cart);
            return RedirectToAction("Show", "Cart");
        }
        public IActionResult SetNumber(int id, int number)
        {
            Cart cart = HttpContext.Session.Get<Cart>("Cart") ?? new Cart();
            cart.SetNumber(Rep.GetViewById(id), number);
            HttpContext.Session.Set<Cart>("Cart", cart);
            return RedirectToAction("Show", "Cart");
        }
        public IActionResult Add(int id)
        {
            Cart cart = HttpContext.Session.Get<Cart>("Cart") ?? new Cart();
            cart.AddProduct(Rep.GetViewById(id));
            HttpContext.Session.Set<Cart>("Cart", cart);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Show()
        {
            Cart cart = HttpContext.Session.Get<Cart>("Cart") ?? new Cart();
            return View("Cart", cart);
        }
    }
}
