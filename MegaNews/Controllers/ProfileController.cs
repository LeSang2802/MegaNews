using MegaNews.Data;
using MegaNews.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserModel model, IFormFile fileImage)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _dbContext.tblAccount.FirstOrDefaultAsync(a => a.Email == email);

            if (user != null)
            {
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.UserName = model.UserName;

                if (fileImage != null && fileImage.Length > 0)
                {
                    var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "image");
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + fileImage.FileName;
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await fileImage.CopyToAsync(fileStream);
                    }

                    user.ImageUrl = Path.Combine("~image", uniqueFileName);
                }

                await _dbContext.SaveChangesAsync();
                return Json(new { success = true, message = "User information updated successfully." });
            }

            return Json(new { success = false, message = "Failed to update user information." });
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
