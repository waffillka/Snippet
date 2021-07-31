using Contracts.LoggerService;
using Entities.ErrorModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Snippet.Services.Exceptions;
using System.Net;

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
                        if (contextFeature.Error is BadRequestException exception)
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                            logger.LogError(exception.Message);

                            await context.Response.WriteAsync(exception.Message).ConfigureAwait(false);

                            return;
                        }

                        logger.LogError($"Something went wrong: {contextFeature.Error}");
                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = "Internal Server Error."
                        }.ToString()).ConfigureAwait(false);
                    }
                });
            });
        }
    }
}
