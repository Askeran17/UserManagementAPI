using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = 500;
            context.Response.ContentType = "application/json";
            var errorResponse = new { error = "Internal server error.", details = ex.Message };
            await context.Response.WriteAsJsonAsync(errorResponse);
        }
    }
}
