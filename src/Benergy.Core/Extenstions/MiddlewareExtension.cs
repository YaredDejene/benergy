
using Microsoft.AspNetCore.Builder;

namespace Benergy.Core.Extenstions
{
    /// <summary>
    /// Extension method to invoke Middleware modules
    /// </summary>
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseContextMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ContextMiddleware>();
        }
    }
}