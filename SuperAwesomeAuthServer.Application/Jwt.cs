namespace SuperAwesomeAuthServer.Application
{
    public sealed class Jwt : IHeader<string>
    {
        private readonly string _header;

        public Jwt(Algorithm algorithm)
            : this("{ \"alg\": \"" + algorithm + "\", \"typ\": \"JWT\" }") {}

        private Jwt(string header)
        {
            _header = header;
        }

        public string Get()
        {
            return _header;
        }
    }
}