using System.Net;
using System.Net.Mime;
using Microsoft.AspNetCore.Diagnostics;

namespace Bjay.Api.Host;

public class ExceptionHandler(ILogger<ExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        switch (exception)
        {
            case KeyNotFoundException keyNotFoundException:
                httpContext.Response.ContentType = MediaTypeNames.Application.Json;
                httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                await httpContext.Response.WriteAsJsonAsync(new
                {
                    keyNotFoundException.Message
                }, cancellationToken);
                break;
            default:
                logger.LogError(exception, "An error occurred: {Message}", exception.Message);
                httpContext.Response.ContentType = MediaTypeNames.Application.Json;
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await httpContext.Response.WriteAsJsonAsync(new
                {
                    StatusCode = httpContext.Response.StatusCode,
                    Message = "Internal Server Error"
                }, cancellationToken);
                break;
        }

        return true;
    }
}
