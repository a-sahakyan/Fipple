using System.Net;

namespace Universalx.Fipple.Identity.DTO
{
    public class ApiResponse
    {
        public Status Status { get; set; }
        public object Result { get; }

        public ApiResponse() { }

        public ApiResponse(object result)
        {
            Result = result;
        }
    }

    public class Status
    {
        public bool Failed { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}
