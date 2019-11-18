using System.Threading.Tasks;
using Benergy.Core.Context;
using Microsoft.AspNetCore.Http;

namespace Benergy.Core.Extenstions
{
    /// <summary>
    /// Middleware used to store HttpContext
    /// </summary>
    public class ContextMiddleware
    {
        private RequestDelegate next;

        public ContextMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            NTContext.HttpContext = context;
            NTContext.Context = null;
            await this.next(context);
        }
    }
}