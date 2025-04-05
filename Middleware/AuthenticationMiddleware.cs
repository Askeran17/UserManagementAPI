using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
public class AuthenticationMiddleware
{
    private readonly RequestDelegate _next;

    public AuthenticationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (string.IsNullOrEmpty(token) || !IsTokenValid(token))
        {
            context.Response.StatusCode = 401; // Unauthorized
            await context.Response.WriteAsync("Invalid or missing token.");
            return;
        }

        await _next(context);
    }

    private bool IsTokenValid(string token)
    {
        // Add token validation logic here
        try
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadToken(token) as JwtSecurityToken;
            // Example: Check token signature, expiration, claims, etc.
            return jwtToken != null;
        }
        catch
        {
            return false;
        }
    }
}
