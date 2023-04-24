using System.IO;
using System.Net;
using System.Text;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OvetimePolicies_api.Dto;

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

        context.Request.RouteValues.TryGetValue("datatype", out var data);
        var dataType = data.ToString().ToLower();

        if (string.IsNullOrEmpty(dataType))
        {
            await returnBadRequest(context);
            return;
        }

        if (dataType == "json")
        {

        }
        else if (dataType == "xml")
        {
            var stream = context.Request.Body;
            var originalContent = await new StreamReader(stream).ReadToEndAsync();

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(originalContent);

            var json = JsonConvert.SerializeXmlNode(doc);
            var jObject = JObject.Parse(json);
            jObject.TryGetValue("data",out var d);



            var requestContent = new StringContent(json, Encoding.UTF8, "application/json");
            stream = await requestContent.ReadAsStreamAsync();//modified stream



            context.Request.Body = stream;

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
            return;
        }


        await _next(context);
    }

    private async Task returnBadRequest(HttpContext context)
    {
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        context.Response.ContentType = "text/plain";
        await context.Response.WriteAsync("dataType not found");
        //ToDo: log 
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
