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



        // Sửa constructor để nhận ApplicationDbContext
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context; // Gán giá trị cho _context
        }

        public IActionResult Index()
        {
            // Lấy 3 bài viết mới nhất
            var latestArticles = _context.tblArticle
                                          .OrderByDescending(a => a.PublishedDate)
                                          .Take(3) // Lấy 3 bài viết mới nhất
                                          .ToList();

            // Trả về View với danh sách bài viết mới nhất
            return View(latestArticles);
        }

        // GET: Article/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var article = await _context.tblArticle.FindAsync(id);
            if (article == null)
            {
                return NotFound();
            }
            return View(article);
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

