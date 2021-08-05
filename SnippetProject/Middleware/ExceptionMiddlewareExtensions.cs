using System;
using Contracts.LoggerService;
using Entities.ErrorModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Snippet.Services.Exceptions;
using System.Net;
using Snippet.Common.Exceptions;

namespace SnippetProject.Middleware
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILoggerManager logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (contextFeature != null)
                    {
                        logger.LogError($"Something went wrong: {contextFeature.Error}");
                        
                        switch (contextFeature.Error)
                        {
                            case BadRequestException:
                            case ArgumentNullException:
                            {
                                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                                await context.Response.WriteAsync(contextFeature.Error.Message).ConfigureAwait(false);
                                break;
                            }
                            case UserNotFoundException:
                            {
                                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                                await context.Response.WriteAsync(contextFeature.Error.Message).ConfigureAwait(false);
                                break;
                            }
                            default:
                            {
                                await context.Response.WriteAsync(new ErrorDetails()
                                {
                                    StatusCode = context.Response.StatusCode,
                                    Message = "Internal Server Error."
                                }.ToString()).ConfigureAwait(false);
                                break;
                            }
                        }
                    }
                });
            });
        }
    }
}
