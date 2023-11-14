using CourseContentManagement.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace CourseContentManagement
{
    public static class Extensions
    {
        public static int GetUserId(this ControllerBase controllerBase)
        {
            return Convert.ToInt32(controllerBase.HttpContext.User.Claims.Where(x => x.Type == "UserId").First().Value);
        }
        public static bool IsAuthed(this ControllerBase controllerBase)
        {
            return controllerBase.HttpContext.User.Claims.Where(x => x.Type == "UserId").FirstOrDefault() != null;
        }

        public static IApplicationBuilder UseProductionExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appBuilder =>
            {
                appBuilder.Run(async context =>
                {
                    var exceptionHandlerPathFeature =
                    context.Features.Get<IExceptionHandlerPathFeature>();
                    var exception = exceptionHandlerPathFeature?.Error;

                    context.Response.ContentType = "application/json";

                    switch (exception)
                    {
                        case NotFoundEntityException notFoundException:
                            context.Response.StatusCode = StatusCodes.Status404NotFound;
                            await context.Response.WriteAsync(notFoundException.Message);
                            break;
                        case NotEntityOwnerException notEntityOwnerException:
                            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                            await context.Response.WriteAsync(notEntityOwnerException.Message);
                            break;
                        case InvalidIdChainException invalidIdChainException:
                            context.Response.StatusCode = StatusCodes.Status400BadRequest;
                            await context.Response.WriteAsync(invalidIdChainException.Message);
                            break;
                        default:
                            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                            await context.Response.WriteAsync("An unexpected error occurred.");
                            break;
                    }
                });
            });

            return app;
        }
    }
}