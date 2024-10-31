using MegaNews.Data;
using MegaNews.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;

namespace MegaNews.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context; // Khai báo ApplicationDbContext
        private const string Session_LoggedIn = "LoggedIn";
        private const string Session_Cookie_UserName = "UserName";

        //Check Session Login exist ?
        [HttpGet]
        public JsonResult CheckLoginStatus()
        {
            var isLoggedIn = HttpContext.Session.GetString(Session_LoggedIn);

            if (string.IsNullOrEmpty(isLoggedIn))
            {
                return Json(new { loggedIn = false });
            }
            else
            {
                return Json(new { loggedIn = true });
            }
        }

        // Sửa constructor để nhận ApplicationDbContext
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context; // Gán giá trị cho _context
        }

        public IActionResult Index()
        {
            //Get userName
            var userName = HttpContext.Session.GetString(Session_Cookie_UserName);
            if (!string.IsNullOrEmpty(userName))
            {
                ViewBag.UserName = userName; // pass UserName to View
            }


            // Lấy 3 bài viết mới nhất
            var latestArticles = _context.tblArticle
                                          .OrderByDescending(a => a.PublishedDate)
                                          .Take(3) // Lấy 3 bài viết mới nhất
                                          .ToList();

            // Trả về View với danh sách bài viết mới nhất
            return View(latestArticles);
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

