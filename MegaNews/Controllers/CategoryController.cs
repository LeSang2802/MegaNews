using MegaNews.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MegaNews.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext; 
        }

        public async Task<IActionResult> Index(string category)
        {
            var articles = await _dbContext.tblArticle
                .Where(a => a.Category == category)
                .ToListAsync();

            ViewBag.Category = category;


            return View(articles);
        }
    }
}
