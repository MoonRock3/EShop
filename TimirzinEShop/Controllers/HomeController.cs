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
        [HttpPost]
        public JsonResult GetCategoryFilterValuesList(string category, string filterType)
        {
            List<HtmlOption> options = Rep.GetCategoryFilterValuesList(category, filterType);
            return Json(options ?? new List<HtmlOption>());
        }
        [HttpPost]
        public JsonResult GetCategoryFilterTypesList(string category)
        {
            List<HtmlOption> options = Rep.GetCategoryFilterTypesList(category);
            return Json(options ?? new List<HtmlOption>());
        }
        [HttpPost]
        public JsonResult GetCommonFilterValuesList(FilterType type)
        {
            List<HtmlOption> options = null;
            switch (type)
            {
                case FilterType.Brand:
                case FilterType.CategoryName:
                case FilterType.Country:
                    options = Rep.GetCommonFilterValuesList(type);
                    break;
            }
            return Json(options ?? new List<HtmlOption>());
        }
        public IActionResult DetailedProduct(int id)
        {
            DetailedProduct product = Rep.GetDetailedById(id) ?? new DetailedProduct();
            if (string.IsNullOrWhiteSpace(product.ProductView.Brand))
            {
                return View("NotFound");
            }
            else
            {
                return View(product);
            }
        }
        public IActionResult Index(DisplayOptions displayOptions)
        {
            var productViews = Rep.GetAll();
            DisplayOptionsApplier applier = new DisplayOptionsApplier(displayOptions);
            applier.ApplyToList(ref productViews);
            IndexParams @params = new IndexParams(productViews, displayOptions);
            return View(@params);
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
