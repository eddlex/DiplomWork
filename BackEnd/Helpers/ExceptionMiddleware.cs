using System.Net;
using System.Text.Json;
using FrontEnd.Helpers;
using Exception = System.Exception;

namespace BackEnd.Helpers;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var statusCode = HttpStatusCode.InternalServerError;
        var message = "Internal Server Error";

        if (exception is CutomExeption badRequestException)
        {
            statusCode = HttpStatusCode.BadRequest;
            message = badRequestException.Message;
                
        }
        // Add more custom exception types as needed

        var response = new { ErrorMessage = message };
        var payload = JsonSerializer.Serialize(response);

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        return context.Response.WriteAsync(payload);
    }
}