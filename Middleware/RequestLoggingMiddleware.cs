using Microsoft.AspNetCore.Http;
namespace StudentApi.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine(
                $"Request Path : {context.Request.Path}"
            );

            Console.WriteLine(
                $"Request Path : {context.Request.Method}"
            );

            Console.WriteLine(
                $"Request Time : {DateTime.Now}"
                );
            await _next(context);

        }
    }
}
