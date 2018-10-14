using System;
using Microsoft.AspNetCore.Mvc;
using SuperAwesome.AuthServer.Application;
using SuperAwesome.AuthServer.Application.Users;
using SuperAwesome.AuthServer.Infrastructure;
using SuperAwesome.AuthServer.Presentation.WebApi.Models;

namespace SuperAwesome.AuthServer.Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class UsersController : ControllerBase
    {
        private readonly IGet<User> _users;
        private readonly IHeader<string> _header;
        private readonly Secret _secret;
        private readonly ISerialize<Claims> _serializer;

        public UsersController(IGet<User> users, IHeader<string> header, Secret secret, ISerialize<Claims> serializer)
        {
            _users = users;
            _header = header;
            _secret = secret;
            _serializer = serializer;
        }

        [HttpPost]
        public ActionResult Post([FromBody] UsersTokenRequest request)
        {
            try
            {
                return Ok(
                    new Response<string>(
                        new Handler(
                            request.ToUser(),
                            _users,
                            _header,
                            _secret,
                            _serializer
                        ).Token()
                    )
                );
            }
            catch(Exception ex)
            {
                return Ok(new Response(ex.Message));
            }            
        }
    }
}
