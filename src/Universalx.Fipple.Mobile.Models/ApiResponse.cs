using System.Net;

namespace Universalx.Fipple.Mobile.Models
{
    public class ApiResponse<T>
    {
        public Status Status { get; set; }
        public T Result { get; }

        public ApiResponse() { }

        public ApiResponse(T result)
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
