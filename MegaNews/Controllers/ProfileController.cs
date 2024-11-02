using Microsoft.AspNetCore.Mvc;

namespace MegaNews.Controllers
{
    public class ProfileController : Controller
    {
        [HttpGet] 
        public IActionResult Marked()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View(); 
        }

        public IActionResult SendPost()
        {
            return View();
        }

        public IActionResult Posts()
        {
            return View();
        }
    }
}
