using Microsoft.AspNetCore.Builder;

namespace TestAppClient.Framework
{
    public static class Extensions
    {
        public static IApplicationBuilder UseExceptionHandler(this IApplicationBuilder builder)
            => builder.UseMiddleware(typeof(ExceptionHandlerMiddleware));
    }
}
