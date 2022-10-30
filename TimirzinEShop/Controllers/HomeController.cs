using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TimirzinEShop.DB_Context;
using TimirzinEShop.Models;

namespace TimirzinEShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        readonly ProductRepository _repository;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _repository = new ProductRepository();
        }
        public IActionResult ProductView(int id)
        {
            DetailedProduct product = _repository.GetById(id) ?? new DetailedProduct();
            return View(product);
        }
        public IActionResult Index()
        {
            var products = new List<ProductView>(_repository.GetAll());

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
