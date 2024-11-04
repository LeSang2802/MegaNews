using MegaNews.Data;
using MegaNews.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Security.Claims;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MegaNews.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public ProfileController(ApplicationDbContext dbContext, IWebHostEnvironment webHostEnvironment)
        {
            _dbContext = dbContext;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet] 
        public IActionResult Marked()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EditProfile()
        {
            //Get information from Claims
            var username = User.FindFirstValue(ClaimTypes.Name);
            var email = User.FindFirstValue(ClaimTypes.Email);

            ViewBag.Username = username;
            ViewBag.Email = email;

            //Get account from database by email
            var account = _dbContext.tblAccount.FirstOrDefault(a => a.Email == email);
            
            return View(account); 
        }

/*        [HttpPost]
        public async Task<IActionResult> UpdateUser(UpdateUserModel model)
        {
        }
*/

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
