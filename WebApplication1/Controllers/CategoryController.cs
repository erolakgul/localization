using Microsoft.AspNetCore.Mvc;
using WebApplication1.Resources;

namespace WebApplication1.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ISharedViewLocalizer _localizer;

        public CategoryController(ISharedViewLocalizer localizer)
        {
            _localizer = localizer;
        }

        public IActionResult Index()
        {
            var AAA = _localizer["HELLO"].ToString();
            ViewData["HELLO"] = _localizer["HELLO"];

            return View();
        }
    }
}
