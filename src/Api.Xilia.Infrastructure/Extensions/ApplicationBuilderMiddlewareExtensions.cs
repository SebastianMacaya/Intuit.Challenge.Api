using Api.Intuit.Infrastructure.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace Api.Intuit.Infrastructure.Extensions
{
    public static class ApplicationBuilderMiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}
