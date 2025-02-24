namespace RestApi.Filters;

public class IpFilterAttribute: ActionFilterAttribute
{
    private readonly IConfiguration _config;

    public IpFilterAttribute(IConfiguration config)
    {
        _config = config;
    }
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var allowedIps = _config.GetSection("AllowedIps").Get<List<string>>();
        var clientIp = context.HttpContext.Connection.RemoteIpAddress?.ToString();

        if (allowedIps == null || !allowedIps.Contains(clientIp))
        {
            context.Result = new StatusCodeResult(403); // Forbidden
            return;
        }
        base.OnActionExecuting(context);
    }
}
