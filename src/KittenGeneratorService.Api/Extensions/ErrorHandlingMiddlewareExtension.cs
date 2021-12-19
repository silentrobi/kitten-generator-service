using KittenGeneratorService.Api.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace KittenGeneratorService.Api.Extensions
{
    public static class ErrorHandlingMiddlewareExtension
    {
        public static IApplicationBuilder UseErrorHandlingMiddleware(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}
