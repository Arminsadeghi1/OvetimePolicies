using System.Net;

namespace OvetimePolicies_api;

sealed public class RequestCultureMiddleware
{
    private readonly RequestDelegate _next;

    public RequestCultureMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {

        var path = context.Request.Path;
        var segments = path.Value?.Split('/');

        //context.GetRouteData().Values.TryGetValue("dataType", out var dataType);
        if (segments.Length < 2)
            await returnBadRequest(context);
        
        var dataType = segments[1]?.ToLower();

        if (string.IsNullOrEmpty(dataType))
            await returnBadRequest(context);

        if (dataType == "json")
        {

        }
        else if (dataType == "xml")
        {

        }
        else if (dataType == "cs")
        {

        }
        else if (dataType == "custom")
        {

        }
        else
        {
            await returnBadRequest(context);
        }


        await _next(context);
    }

    private async Task returnBadRequest(HttpContext context)
    {
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        context.Response.ContentType = "text/plain";
        await context.Response.WriteAsync("dataType not found");
        //ToDo: log 
        return;
    }
}

public static class RequestCultureMiddlewareExtensions
{
    public static IApplicationBuilder UseRequestCulture(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<RequestCultureMiddleware>();
    }
}
