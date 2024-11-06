using MegaNews.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace MegaNews.Middleware
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        private const string Session_LoggedIn = "LoggedIn";
        private const string Claim_Image = "ImageUrl";

        public AuthMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            var isLoggedIn = httpContext.Session.GetString(Session_LoggedIn) != null;
            
            httpContext.Items[Session_LoggedIn] = isLoggedIn;
            httpContext.Items["username"] = httpContext.User.FindFirstValue(ClaimTypes.Name);
            httpContext.Items["ImageUrl"] = httpContext.User.FindFirstValue(Claim_Image);

            await _requestDelegate(httpContext);
        }
    }
}
