using Microsoft.AspNetCore.Mvc;

namespace MegaNews.Controllers
{
    public class CategoryController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
