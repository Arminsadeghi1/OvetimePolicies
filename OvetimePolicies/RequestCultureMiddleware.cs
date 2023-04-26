using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Newtonsoft.Json;
using OvetimePolicies_api.Dto;
using System.Net;
using System.Text;
using System.Xml;

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

            var dataSource = JsonConvert.DeserializeObject<CommandDto>(json);

            var a = JsonConvert.SerializeObject(dataSource);

            var requestContent = new StringContent(a, Encoding.UTF8, "application/json");
            stream = await requestContent.ReadAsStreamAsync();

            context.Request.Body = stream;
            context.Request.ContentLength = stream.Length;
            context.Request.Headers["Content-Type"] = "application/json";
            context.Response.ContentType = "application/json";
        }
        else if (dataType == "cs")
        {

        }
        else if (dataType == "custom")
        {
            var stream = context.Request.Body;
            var originalContent = await new StreamReader(stream).ReadToEndAsync();

            try
            {
                var key = originalContent.Split("\n")[0].Split('/');
                var value = originalContent.Split("\n")[1].Split('/');
                key[key.Length - 1] = key[key.Length - 1].Replace("\r", "");
                if (key.Length > value.Length

                    )
                {
                    await returnBadRequest(context);
                    return;
                }

                DateTime.TryParse(value[Array.FindIndex(key, f => f.ToLower().Equals("date"))], out var _date);
                decimal.TryParse(value[Array.FindIndex(key, f => f.ToLower().Equals("allowance"))], out var _allowance);
                decimal.TryParse(value[Array.FindIndex(key, f => f.ToLower().Equals("basicsalary"))], out var _basicsalary);
                decimal.TryParse(value[Array.FindIndex(key, f => f.ToLower().Equals("transportation"))], out var _transportation);

                var customData = new CommandDto()
                {
                    data = new PersonDto()
                    {
                        FirstName = value[Array.FindIndex(key, f => f.ToLower().Equals("firstname"))],
                        LastName = value[Array.FindIndex(key, f => f.ToLower().Equals("lastname"))],
                        Allowance = _allowance,
                        BasicSalary = _basicsalary,
                        Transportation = _transportation,
                        Date = _date,
                    }
                };

                var requestContent = new StringContent(JsonConvert.SerializeObject(customData), Encoding.UTF8, "application/json");
                stream = await requestContent.ReadAsStreamAsync();
            }
            catch (Exception)
            {
                await returnBadRequest(context);
                return;
            }


            context.Request.Body = stream;
            context.Request.ContentLength = stream.Length;
            context.Request.Headers["Content-Type"] = "application/json";
            context.Response.ContentType = "application/json";

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
