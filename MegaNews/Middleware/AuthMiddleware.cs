using System.Security.Claims;

namespace MegaNews.Middleware
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        private const string Session_LoggedIn = "LoggedIn";
        public AuthMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            var isLoggedIn = httpContext.Session.GetString(Session_LoggedIn) != null;
            var username = httpContext.User.FindFirstValue(ClaimTypes.Name);

            httpContext.Items[Session_LoggedIn] = isLoggedIn;
            httpContext.Items["username"] = username;

            await _requestDelegate(httpContext);
        }
    }
}
