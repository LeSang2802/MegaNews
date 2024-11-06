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
            var email = User.FindFirstValue(ClaimTypes.Email);

            //Get account from database by email
            var account = _dbContext.tblAccount.FirstOrDefault(a => a.Email == email);

            if (string.IsNullOrEmpty(account.ImageUrl))
            {
                account.ImageUrl = "~/image/user-avatar.svg";
            }

            return View(account);
        }

        [HttpGet]
        public IActionResult EditProfile()
        {
            //Get information from Claims
            var email = User.FindFirstValue(ClaimTypes.Email);

            //Get account from database by email
            var account = _dbContext.tblAccount.FirstOrDefault(a => a.Email == email);

            if (string.IsNullOrEmpty(account.ImageUrl))
            {
                account.ImageUrl = "~/image/image_Preview.svg";
            }

            return View(account); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateUser(UpdataUserViewModel model)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var account = await _dbContext.tblAccount.FirstOrDefaultAsync(a => a.Email == email);

            if (account != null) {
                account.UserName = model.UserName;
                account.FirstName = model.FirstName;
                account.LastName = model.LastName;

                if (model.fileInput != null && model.fileInput.Length > 0)
                {
                    var fileName = Path.GetFileName(model.fileInput.FileName);
                    var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "image", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.fileInput.CopyToAsync(stream);
                    }

                    account.ImageUrl = "~/image/" + fileName;
                }

                _dbContext.tblAccount.Update(account);
                await _dbContext.SaveChangesAsync();

                return Json(new { success = true, message = "User information has been updated successfully." });
            }
            else
            {
                return Json(new { success = true, message = "User information update failed" });
            }
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
