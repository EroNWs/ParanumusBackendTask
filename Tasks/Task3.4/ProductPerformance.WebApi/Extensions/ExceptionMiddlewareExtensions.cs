﻿using Microsoft.AspNetCore.Diagnostics;
using ProductPerformance.Application.Contracts;
using ProductPerformance.Models.ErrorModels;
using ProductPerformance.Models.Exceptions;

namespace ProductPerformance.WebApi.Extensions;

public static class ExceptionMiddlewareExtensions
{
    public static void ConfigureExtceptionHandler(this WebApplication app, ILoggerService loggerService)
    {
        app.UseExceptionHandler(appErr =>
        {
            appErr.Run(async context =>
            {
                context.Response.ContentType = "application/json";
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature is not null)
                {
                    context.Response.StatusCode = contextFeature.Error switch
                    {
                        NotFoundException => StatusCodes.Status404NotFound,
                        _ => StatusCodes.Status500InternalServerError
                    };

                    loggerService.LogError($"Something went wrong: {contextFeature.Error}");
                    await context.Response.WriteAsync(new ErrorDetails()
                    {
                        StatusCode = context.Response.StatusCode,
                        Message = contextFeature.Error.Message

                    }.ToString()
                    );
                }
            });
        });
    }
}
