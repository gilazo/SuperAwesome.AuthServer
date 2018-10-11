using Microsoft.AspNetCore.Mvc;
using SuperAwesomeAuthServer.Presentation.Models;

namespace SuperAwesomeAuthServer.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpPost]
        public ActionResult Post([FromBody] UsersTokenRequest request)
        {
            return Ok(new UsersHandler(request).Handle());
        }
    }
}
