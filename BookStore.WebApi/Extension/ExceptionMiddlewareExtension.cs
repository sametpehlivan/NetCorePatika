
using BookStore.WebApi.Middleware;

namespace BookStore.WebApi.Extensions;
public static class ExceptionMiddlewareExtension 
{
    public static IApplicationBuilder UseException(this IApplicationBuilder app)
    {
        return app.UseMiddleware<ExceptionMidlleware>();
    }                  
}