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
            // Lấy 3 bài viết mới nhất (theo Id)
            var latestArticles = _context.tblArticle
                                          .OrderByDescending(a => a.Id) // Sắp xếp theo Id giảm dần
                                          .Take(3) // Lấy 3 bài viết mới nhất
                                          .ToList();

            // Trả về View với danh sách bài viết mới nhất
            return View(latestArticles);
        }

        [HttpGet]
        public IActionResult LoadMoreArticles(int lastArticleId, int take = 3)
        {
            var articles = _context.tblArticle
                                   .Where(a => a.Id < lastArticleId) // Lấy bài viết có Id nhỏ hơn bài cuối cùng
                                   .OrderByDescending(a => a.Id)      // Sắp xếp giảm dần
                                   .Take(take)
                                   .ToList();

            // Trả về Partial View chứa các bài viết mới
            return PartialView("_ArticlePartial", articles);
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



        // GET: Articles/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ArticleModel model, IFormFile ImageFile)
        {
            if (ModelState.IsValid)
            {
                // Xử lý file hình ảnh
                if (ImageFile != null && ImageFile.Length > 0)
                {
                    var fileName = Path.GetFileName(ImageFile.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/image", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await ImageFile.CopyToAsync(stream);
                    }
                    model.ImageUrl = $"/image/{fileName}"; // Lưu đường dẫn ảnh
                }

                // Lưu bài viết vào cơ sở dữ liệu
                model.PublishedDate = DateTime.Now;
                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }


        // Cập nhật 
        // Action để hiển thị tất cả bài báo
        public IActionResult AllArticles()
        {
            var articles = _context.tblArticle.ToList(); // Lấy tất cả bài báo
            return View(articles); // Trả về view với danh sách bài báo
        }

        // Action để hiển thị form sửa bài viết
        public IActionResult Edit(int id)
        {
            var article = _context.tblArticle.Find(id);
            if (article == null)
            {
                return NotFound(); // Nếu không tìm thấy bài viết
            }
            return View(article); // Trả về view sửa bài viết
        }

        // Action để xử lý sửa bài viết
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ArticleModel articleModel)
        {
            if (ModelState.IsValid)
            {
                // Tìm bài viết trong cơ sở dữ liệu theo Id
                var articleToUpdate = _context.tblArticle.Find(articleModel.Id);
                if (articleToUpdate == null)
                {
                    return NotFound(); // Nếu không tìm thấy bài viết
                }

                // Cập nhật các thuộc tính của bài viết
                articleToUpdate.Title = articleModel.Title;
                articleToUpdate.Content = articleModel.Content;
                articleToUpdate.Summary = articleModel.Summary;
                articleToUpdate.Category = articleModel.Category;
                articleToUpdate.Author = articleModel.Author;

                _context.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
                return RedirectToAction("AllArticles"); // Quay lại danh sách bài viết
            }
            return View(articleModel); // Trả về view nếu có lỗi
        }

        // Action xóa bài viết
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var article = _context.tblArticle.Find(id);
            if (article == null)
            {
                return NotFound(); // Nếu không tìm thấy bài viết
            }

            _context.tblArticle.Remove(article); // Xóa bài viết
            _context.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
            return RedirectToAction("AllArticles"); // Quay lại danh sách bài viết
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

