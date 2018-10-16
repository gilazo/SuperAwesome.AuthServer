namespace SuperAwesome.AuthServer.Application
{
    public sealed class JwtHeader : IHeader<string>
    {
        private readonly string _header;

        public JwtHeader(Algorithm algorithm)
            : this("{ \"alg\": \"" + algorithm + "\", \"typ\": \"JWT\" }") { }

        private JwtHeader(string header)
        {
            _header = header;
        }

        public string Header()
        {
            return _header;
        }
    }
}
