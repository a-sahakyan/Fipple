using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using Universalx.Fipple.Identity.Constants;
using Universalx.Fipple.Identity.DTO;
using Universalx.Fipple.Identity.DTO.Exception;

namespace Universalx.Fipple.Identity.Api.Middlewares
{
    public static class GlobalExceptionHandler
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (contextFeature.Error is HttpException)
                    {
                        await context.AddHttpError(contextFeature);
                        return;
                    }

                    await context.AddApplicationError(contextFeature);
                });
            });
        }

        private static async Task AddHttpError(this HttpContext context, IExceptionHandlerFeature contenxtFeautre)
        {
            HttpException httpException = contenxtFeautre.Error as HttpException;
            context.Response.StatusCode = (int)httpException.HttpStatusCode;
            context.Response.ContentType = MediaTypeNames.Application.Json;

            await context.Response.WriteAsJsonAsync(new ApiResponse
            {
                Status = new Status
                {
                    Failed = true,
                    ErrorMessage = httpException.Message,
                    StatusCode = httpException.HttpStatusCode
                },
            });
        }

        private static async Task AddApplicationError(this HttpContext context, IExceptionHandlerFeature contenxtFeautre)
        {
            //TODO: log application errors
            await context.Response.WriteAsJsonAsync(new ApiResponse
            {
                Status = new Status
                {
                    Failed = true,
                    ErrorMessage = ResponseError.UnknownError,
                    StatusCode = HttpStatusCode.InternalServerError
                },
            });
        }
    }
}
