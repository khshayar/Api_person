namespace RestApi.Middleware;

public class IpFilterMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IConfiguration _config;

    public IpFilterMiddleware(RequestDelegate next, IConfiguration config)
    {
        _next = next;
        _config = config;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var allowedIps = _config.GetSection("AllowedIps").Get<List<string>>();
        var clientIp = context.Connection.RemoteIpAddress?.ToString();

        if (allowedIps == null || !allowedIps.Contains(clientIp))
        {
            context.Response.StatusCode = 403;
            await context.Response.WriteAsync("you are not allowed to access this page.");
            return;
        }
    }
}