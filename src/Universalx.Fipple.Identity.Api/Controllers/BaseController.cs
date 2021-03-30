using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Universalx.Fipple.Identity.Api.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]/[action]")]
    public class BaseController : ControllerBase
    {
        protected ObjectResult OkResult(object value = null)
        {
            return StatusCode((int)HttpStatusCode.OK, value);
        }
    }
}
