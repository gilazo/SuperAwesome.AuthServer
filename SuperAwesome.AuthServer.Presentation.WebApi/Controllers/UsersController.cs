using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SuperAwesome.AuthServer.Application;
using SuperAwesome.AuthServer.Application.Users;
using SuperAwesome.AuthServer.Infrastructure;
using SuperAwesome.AuthServer.Presentation.WebApi.Models;
using SuperAwesome.AuthServer.Presentation.WebApi.Services;

namespace SuperAwesome.AuthServer.Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class UsersController : ControllerBase
    {
        private readonly IGet<User> _users;
        private readonly HashFactory _factory;
        private readonly Secret _secret;
        private readonly ISerialize<Claims> _serializer;

        public UsersController(IGet<User> users, HashFactory factory, Secret secret, ISerialize<Claims> serializer)
        {
            _users = users;
            _factory = factory;
            _secret = secret;
            _serializer = serializer;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] UsersTokenRequest request)
        {
            return Ok(
              await new RequestHandler<string>().HandleAsync(
                new Handler(
                  request.ToUser(),
                  _users,
                  _secret,
                  _serializer,
                  _factory
                )
                .TokenAsync
              )
            );
        }
    }
}
