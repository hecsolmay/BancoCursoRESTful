using WebAPI.Middleware;

namespace WebAPI.Extentions
{
    public static class AppExtentions
    {
        public static void UseErrorHandlingMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandleMiddleware>();
        }
    }
}
