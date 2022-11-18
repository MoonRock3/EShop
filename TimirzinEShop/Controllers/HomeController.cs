using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TimirzinEShop.DB_Context;
using TimirzinEShop.Models;
using Rep = TimirzinEShop.Models.ProductRepository;

namespace TimirzinEShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult DetailedProduct(int id)
        {
            DetailedProduct product = Rep.GetDetailedById(id) ?? new DetailedProduct();
            return View(product);
        }
        public IActionResult Index()
        {
            var products = new List<ProductView>(Rep.GetAll());

            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
