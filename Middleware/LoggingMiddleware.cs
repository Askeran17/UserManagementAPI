using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

public class LoggingMiddleware
{
    private readonly RequestDelegate _next;

    public LoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Log the incoming request
        Console.WriteLine($"HTTP Request: {context.Request.Method} {context.Request.Path}");

        // Call the next middleware
        await _next(context);

        // Log the outgoing response
        Console.WriteLine($"HTTP Response: {context.Response.StatusCode}");
    }
}
