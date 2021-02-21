using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using System.Threading.Tasks;
using Universalx.Fipple.Identity.DTO;

namespace Universalx.Fipple.Identity.Api.Filters
{
    public class ApiResponseResultFilter : IAsyncResultFilter
    {
        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (context.Result is ObjectResult objectResult)
            {
                var response = new ApiResponse(objectResult.Value)
                {
                    Status = new Status
                    { 
                        Failed = false, 
                        StatusCode = (HttpStatusCode)objectResult.StatusCode 
                    }
                };

                context.Result = new ObjectResult(response)
                {
                    StatusCode = objectResult.StatusCode
                };

                await next();
            }
            else
            {
                context.Cancel = true;
            }
        }
    }
}
