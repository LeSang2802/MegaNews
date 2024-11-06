using MegaNews.Data;
using MegaNews.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace MegaNews.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private PasswordHasher<AccountModel> _passwordHasher;

        private const string Session_LoggedIn = "LoggedIn";
        private const string Claim_Image = "ImageUrl";

        public AccountController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _passwordHasher = new PasswordHasher<AccountModel>();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp([FromBody] AccountModel accountModel)
        {
            var account = await _dbContext.tblAccount
                        .FirstOrDefaultAsync(a => a.Email == accountModel.Email);

            if (account == null)
            {
                accountModel.Password = _passwordHasher.HashPassword(accountModel, accountModel.Password);

                _dbContext.tblAccount.Add(accountModel);
                await _dbContext.SaveChangesAsync();
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false, message = "Email has been used to register another account" });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn([FromBody] SignInModel signInModel)
        {
            var account = await _dbContext.tblAccount
                .FirstOrDefaultAsync(a => a.Email == signInModel.Email);

            if (account != null)
            {
                var result = _passwordHasher.VerifyHashedPassword(account, account.Password, signInModel.Password);

                if (result == PasswordVerificationResult.Success)
                {
                    if (account.Role == "User")
                    {
                        //Create session to report successful login status
                        HttpContext.Session.SetString(Session_LoggedIn, "true");

                        //Create Claims get information User
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, account.UserName),
                            new Claim(ClaimTypes.Email, account.Email),
                            new Claim(Claim_Image, @Url.Content(account.ImageUrl) ?? @Url.Content("~/image/user-avatar.svg"))
                        };

                        //Create ClaimsIdentity and ClaimsPrincipal
                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, new AuthenticationProperties
                        {
                            IsPersistent = true, 
                            ExpiresUtc = DateTime.UtcNow.AddMinutes(30)
                        });


                        return Json(new { success = true, redirectUrl = Url.Action("Index", "Home") });
                    }
                    else
                    {
                        return Json(new { success = true, redirectUrl = Url.Action("Index", "Admin") });
                    }
                }
                else
                {
                    return Json(new { success = false, message = "Incorrect password account information" });
                }
            }
            else
            {
                return Json(new { success = false, message = "Account doesn't exist" });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            //Delete Cookies storages Claims
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            //Delete All Session
            HttpContext.Session.Clear();

            // Chuyển hướng đến trang chính
            return RedirectToAction("Index", "Home");
        }
    }
}
