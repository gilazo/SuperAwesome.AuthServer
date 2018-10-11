using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SuperAwesomeAuthServer.Application;
using SuperAwesomeAuthServer.Application.Users;
using SuperAwesomeAuthServer.Presentation.Models;

namespace SuperAwesomeAuthServer.Presentation
{
    public sealed class UsersHandler
    {
        private readonly UsersTokenRequest _request;

        public UsersHandler(UsersTokenRequest request)
        {
            _request = request;
        }

        public TokenResponse Handle()
        {
            var header = new Jwt("HS256").Get();
            var payload = JsonConvert.SerializeObject(
                new Claims(_request.Username, "user", "Jon Doe"), 
                new JsonSerializerSettings 
                { 
                    ContractResolver = new DefaultContractResolver { NamingStrategy = new CamelCaseNamingStrategy() }
                });

            return new TokenResponse(
                new Token(
                    new HashHMACSHA256(
                        header, 
                        payload, 
                        "hello"
                    ).Hash()
                )
            );
        }
    }
}
