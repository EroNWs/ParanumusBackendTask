using BookStore.Business.Contracts;
using BookStore.Core.Utilities.Results.Concrete;
using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;

namespace BookStore.WebApi.Extensions;

public static class ExceptionMiddlewareExtensions
{
    public static void ConfigureExceptionHandler(this WebApplication app, ILoggerService loggerService)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.ContentType = "application/json";

                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature != null)
                {
                    ErrorResult result; // Just use your custom ErrorResult type directly

                    switch (contextFeature.Error)
                    {
                        case KeyNotFoundException ex:
                            context.Response.StatusCode = StatusCodes.Status404NotFound;
                            result = new ErrorResult($"Resource not found: {ex.Message}");
                            break;
                        default:
                            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                            result = new ErrorResult($"Internal server error: {contextFeature.Error.Message}");
                            break;
                    }

                    loggerService.LogError($"Something went wrong: {contextFeature.Error}");
                    var jsonResponse = JsonSerializer.Serialize(result);
                    await context.Response.WriteAsync(jsonResponse);
                }
            });
        });
    }

}