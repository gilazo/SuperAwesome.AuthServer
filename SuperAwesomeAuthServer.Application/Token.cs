using Newtonsoft.Json;

namespace SuperAwesomeAuthServer.Application
{
    public sealed class Token
    {
        private readonly string _header;
        private readonly string _payload;
        private readonly IHash _hash;

        public Token(string header, string payload, IHash hash)
        {
            _header = header;
            _payload = payload;
            _hash = hash;
        }

        public string Get()
        {
            return _hash.Hash();
        }
    }
}