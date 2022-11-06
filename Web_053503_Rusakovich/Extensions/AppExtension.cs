using Microsoft.AspNetCore.Builder;

namespace Web_053503_Rusakovich.Extensions
{
    public static class AppExtension
    {
        public static IApplicationBuilder UseFileLogging(this IApplicationBuilder app) => app.UseMiddleware<Middleware.LogMiddleware>();
    }
}
