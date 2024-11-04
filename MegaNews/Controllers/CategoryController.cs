using MegaNews.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Unidecode.NET;

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

        public async Task<IActionResult> PostSearch(string search)
        {
            //Create ViewBag
            ViewBag.TextSearch = search;

            var articles = await _dbContext.tblArticle.ToListAsync();

            if (!string.IsNullOrEmpty(search))
            {
                //Remove accents and convert to lowercase
                var normalizedTextSearch = search.Unidecode().Trim().ToLower();

                articles = articles
                    .Where(a => a.Title.Unidecode().ToLower().Contains(normalizedTextSearch))
                    .ToList();
            }

            return View(articles);
        }
    }
}
