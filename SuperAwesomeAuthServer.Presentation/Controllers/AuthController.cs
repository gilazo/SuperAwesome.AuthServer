using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace SuperAwesomeAuthServer.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        const string secret = "ThisIsAwesome";

        [HttpPost]
        public ActionResult Post([FromBody] JwtRequest request)
        {
            var encodedHeader = Base64UrlEncoder.Encode(JsonConvert.SerializeObject(request.Header));
            var encodedPayload = Base64UrlEncoder.Encode(JsonConvert.SerializeObject(request.Payload));
            var data = encodedHeader + '.' + encodedPayload;
                        
            if (request.Header.Alg == "HS256")
            {
                string sig;
                using (var car = new HMACSHA256(Encoding.ASCII.GetBytes(secret)))
                {
                    sig = Base64UrlEncoder.Encode(car.ComputeHash(Encoding.ASCII.GetBytes(data)));
                    return Ok($"{encodedHeader}.{encodedPayload}.{sig}");
                }                
            }

            return Ok();
        }
    }
    
    public class JwtRequest
    {
        public Header Header { get; set; }
        public Payload Payload { get; set; }
    }

    public class Header 
    {
        public string Alg { get; set; }
        public string Typ { get; set; }
    }

    public class Payload
    {
        public string Sub { get; set; }
    }
}
