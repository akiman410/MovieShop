using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MovieShopMVC.Infra
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MovieShopExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<MovieShopExceptionMiddleware> _logger;

        public MovieShopExceptionMiddleware(RequestDelegate next, ILogger<MovieShopExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            // logic 
            _logger.LogInformation("Inside exception Middleware");

            try {
                    await _next(httpContext);
                }
            catch(Exception ex) {
                _logger.LogError("Exception happened, Handle here : ");
                await HandleExceptionLogic(httpContext, ex);
                  }
            //return _next(httpContext);
        }

        private async Task HandleExceptionLogic(HttpContext httpContext, Exception ex)
        {
            _logger.LogError("Something Went wrong");
            // get the exception details
            var exceptionDetails = new
            {
                ExceptionMessage = ex.Message,
                ExceptionStackTrace = ex.StackTrace,
                ExceptionType=ex.GetType(),
                ExceptionDetails=ex.InnerException?.Message,
                ExceptionDateTime = DateTime.UtcNow,
                Path = httpContext.Request.Path,
                HttpMethod = httpContext.Request.Method,
                User = httpContext.User.Identity.IsAuthenticated ? httpContext.User.Identity.Name : null,
            };
            // log the above object details to text or Json File using Serilog or Nlog

            _logger.LogError(exceptionDetails.ExceptionMessage);

            httpContext.Response.Redirect("/Home/Error");
            await Task.CompletedTask;
        }
    }


    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MovieShopExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseMovieShopExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MovieShopExceptionMiddleware>();
        }
    }
}
