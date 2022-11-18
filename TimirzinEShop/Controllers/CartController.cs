using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimirzinEShop.Models;
using Rep = TimirzinEShop.Models.ProductRepository;

namespace TimirzinEShop.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Order()
        {
            Cart cart = HttpContext.Session.Get<Cart>("Cart") ?? new Cart();
            return View(cart);
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
