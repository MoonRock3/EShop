using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TimirzinEShop.Models;

namespace TimirzinEShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly List<Product> products = new List<Product>()
        {
            new Product(1, "DEXP", "Описание1", 5499, "https://c.dns-shop.ru/thumb/st4/fit/300/300/cb10e446733f6cff0f0dd2dce8c1949d/d489c9311092ae6bbf46d114b5e308b5ccfca6f4901c39c246df62abe4e287c7.jpg.webp", "Китай", "Варочная панель", "4M2CTYL/B"),
            new Product(2, "Akpo", "Описание2", 7499, "https://c.dns-shop.ru/thumb/st1/fit/0/0/93ad95c00c0d188af944c04ba046e591/920a750214fc1af625eb57ec6c131db71031e53cdf856c11da978da9c880faea.jpg.webp", "Польша", "Варочная панель", "PKA 309005K BL"),
            new Product(3, "MAUNFELD", "Описание3", 7499, "https://c.dns-shop.ru/thumb/st1/fit/300/300/693cfde28ef77f2d03d2ef02c0dfefb0/5693cbec0cce07b08096d610a6e94a57994510e8880565be5a9dd3e1f3aaea7a.jpg.webp", "Турция", "Варочная панель", "EEHE.32.4B"),
            new Product(4, "HOMSair", "Описание4", 9299, "https://c.dns-shop.ru/thumb/st4/fit/300/300/534eb58510dd326e55866c92a1aa4657/f6e84a1f84450ba8f5a2ca9289d270324f3341cac3fc1c1f126d8807e6c530f5.jpg.webp", "Китай", "Варочная панель", "HIY32BK"),
            new Product(5, "LEX", "Описание5", 5999, "https://c.dns-shop.ru/thumb/st4/fit/300/300/eff7403d05dc1736cc30cfa3cbfb8c66/51da593cc29a974a6d97fce97749c446f5c54be67cf5a99642e5e57e2fac9cf3.jpg.webp", "Китай", "Варочная панель", "GVS 320 IX"),
            
            new Product(6, "Darina", "Описание6", 12999, "https://c.dns-shop.ru/thumb/st1/fit/300/300/19ff3f60742c32a2bf7860e459002819/8158a4b2014c43ce92d22ea77aa549261e6e1b73ec4f1ed599bebbf74986e220.jpg.webp", "Россия", "Духовой шкаф", "1U BDE 111 707 At"),
            new Product(7, "Gefest", "Описание7", 13999, "https://c.dns-shop.ru/thumb/st1/fit/300/300/4dd4a284128625f31bbbb32ba94345fa/53644c849c0b3298a7af9361591c71be16e146c6af6059dfadbc5aa00bdd6b78.jpg.webp", "Беларусь", "Духовой шкаф", "602-01 К"),
            new Product(8, "Ricci", "Описание8", 14999, "https://c.dns-shop.ru/thumb/st1/fit/300/300/e5529354a0e0d172e917dc9ebb81240a/e77b1e4350e511114a8d82573116761d926967c616d9be9973c79962fd776881.jpg.webp", "Турция", "Духовой шкаф", "RGO-611BG"),
            new Product(9, "MBS", "Описание9", 28699, "https://c.dns-shop.ru/thumb/st4/fit/300/300/7507b533a2ffedde6b275f5bf0a4b2b6/bef8e8b5ef9aaf3d7ca70d62fafba820076435158c7b349bde03d13a2833c005.jpg.webp", "Турция", "Духовой шкаф", "DG-604WH"),
            new Product(10, "Simfer", "Описание10", 29999, "https://c.dns-shop.ru/thumb/st4/fit/300/300/012be538a768affbdec4b7f0f30a4d97/92b90ceb6d4a95aa4d184d406072334e2f3193a5e1ff248b8a49d6d490cbcd0e.jpg.webp", "Турция", "Духовой шкаф", "B6GB12016"),

            new Product(11, "Kraft Technology", "Описание11", 13999, "https://c.dns-shop.ru/thumb/st1/fit/300/300/e4340164b16463db791a7c2040cb596a/31a6bc638597a5fa6721475d6eebe2a68949eac51a98d21cb00768305dc914fd.jpg.webp", "Китай", "Микроволновая печь", "TCH-BI20A7400DI"),
            new Product(12, "Midea", "Описание12", 15299, "https://c.dns-shop.ru/thumb/st4/fit/300/300/3316cb804340259e2d281ed1c4efb684/7b14b8caafeb1f2caea612096cf28e9e8f0683d84aee8aa7d590f7e811bd2cef.jpg.webp", "Китай", "Микроволновая печь", "MM820B2Q-SS"),
            new Product(13, "KRONA", "Описание13", 17999, "https://c.dns-shop.ru/thumb/st4/fit/300/300/f2363dabc64634d9345e47cd6612a7c8/ce4d5f6fe2f78355b62573ef57f28a7c882854a0dd695f1f1758cfba7c060298.jpg.webp", "Германия", "Микроволновая печь", "RAUM 60 S"),
            new Product(14, "Schaub Lorenz", "Описание14", 18999, "https://c.dns-shop.ru/thumb/st1/fit/300/300/f925cc1526f3b0057958e55b346e55c0/c0b2f58df4f58fa473218b2e47f76ec6052c7798bb6fe7ab935b33d08ce5daa9.jpg.webp", "Турция", "Микроволновая печь", "SLM ES21D"),
            new Product(15, "Samsung", "Описание15", 19499, "https://c.dns-shop.ru/thumb/st4/fit/300/300/3bf6a430f18c8d875bbd26162a811cd2/f5c2798aa91e607658cb5da07cd786faeb057f51d73e4fc7d6f780e786109906.jpg.webp", "Малайзия", "Микроволновая печь", "MS23A7013AL")
        };

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
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
        public IActionResult MyAction()
        {
            return Content("<h1>MyAction</h1>", "text/html");
        }
        public string MyAction2()
        {
            return "<h1>MyAction</h1>";
        }
    }
}
