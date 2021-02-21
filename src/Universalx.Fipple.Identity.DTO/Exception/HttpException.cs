using System.Net;

namespace Universalx.Fipple.Identity.DTO.Exception
{
    public class HttpException : System.Exception
    {
        public HttpStatusCode HttpStatusCode { get; }

        public HttpException(HttpStatusCode httpStatusCode, string message)
            : base(message) 
        {
            HttpStatusCode = httpStatusCode;
        }
    }
}
