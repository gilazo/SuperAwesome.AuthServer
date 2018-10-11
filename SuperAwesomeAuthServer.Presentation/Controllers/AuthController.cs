using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SuperAwesomeAuthServer.Application;
using SuperAwesomeAuthServer.Presentation.Models;

namespace SuperAwesomeAuthServer.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public ActionResult Post([FromBody] TokenRequest request)
        {
            return Ok(new Handler(request).Handle());
        }
    }
}
