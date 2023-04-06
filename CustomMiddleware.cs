using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace PartyProductAPI
{
    public class CustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("Hello file 1");
            await next(context);
            await context.Response.WriteAsync("Hello file 2");
        }
    }
}
