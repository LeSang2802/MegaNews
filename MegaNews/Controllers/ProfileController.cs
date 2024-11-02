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

        [HttpGet]
        public IActionResult Edit()
        {
            return View(); 
        }

        [HttpGet]
        public IActionResult SendPost()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Posts()
        {
            return View();
        }
    }
}
