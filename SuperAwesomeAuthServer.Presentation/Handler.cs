using System;
using Newtonsoft.Json;
using SuperAwesomeAuthServer.Application;
using SuperAwesomeAuthServer.Presentation.Models;

namespace SuperAwesomeAuthServer.Presentation
{
    public sealed class Handler
    {
        private readonly TokenRequest _request;

        public Handler(TokenRequest request)
        {
            _request = request;
        }

        public string Handle()
        {
            var header = JsonConvert.SerializeObject(_request.Header);
            var payload = JsonConvert.SerializeObject(_request.Payload);

            if (_request.Header.Alg.Equals("HS256", StringComparison.CurrentCultureIgnoreCase))
            {
                return Response(new TokenResponse(new Models.Token(new Application.Token(header, payload, new HashHMACSHA256(header, payload, "hello")).Get())));
            }

            return Response(new TokenResponse(new Message("Algorithm not yet supported.")));
        }

        private string Response(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}