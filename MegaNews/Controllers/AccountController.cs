using MegaNews.Data;
using MegaNews.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace MegaNews.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public AccountController(ApplicationDbContext dbContext)
        {

            _dbContext = dbContext; 
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([FromBody]AccountModel accountModel)
        {
            if (accountModel == null) {
                return Json(new { success = false, message = "Invalid data" });
            }
            else
            {
                _dbContext.tblAccount.Add(accountModel);
                await _dbContext.SaveChangesAsync();
                return Json(new { success = true });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> VerifyLogin([FromBody]AccountModel accountModel)
        {
            var account = await _dbContext.tblAccount
                        .FirstOrDefaultAsync(a => a.Email == accountModel.Email && a.Password == accountModel.Password);

            if (account == null)
            {
                return Json(new { success = false, message = "Account doesn't exist" });
            }
            else
            {
                HttpContext.Session.SetString("UserName", account.UserName);
                HttpContext.Session.SetString("Email", account.Email);
                HttpContext.Session.SetString("Password", account.Password);

                if (account.Role == "User")
                {
                    return Json(new { success = true, redirectUrl = Url.Action("Index", "Home") });
                }

                else
                {
                    return Json(new { success = true, redirectUrl = Url.Action("Index", "Admin") });
                }
            }
        }
    }
}
