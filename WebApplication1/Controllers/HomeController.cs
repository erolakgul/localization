using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Diagnostics;
using WebApplication1.Models;
using WebApplication1.Resources;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISharedViewLocalizer _localizer;

        public HomeController(ILogger<HomeController> logger, ISharedViewLocalizer localizer)
        {
            _localizer = localizer;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var AAA = _localizer["HELLO"].ToString();
            ViewData["HELLO"] = _localizer["HELLO"];

            return View();
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