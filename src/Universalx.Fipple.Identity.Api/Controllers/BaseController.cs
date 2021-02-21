using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Universalx.Fipple.Identity.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        protected ObjectResult OkResult(object value = null)
        {
            return StatusCode((int)HttpStatusCode.OK, value);
        }
    }
}
