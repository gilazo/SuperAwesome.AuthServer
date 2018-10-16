namespace SuperAwesome.AuthServer.Application
{
    public sealed class HashFactory
    {
        private readonly HashType _type;
        private readonly string _header;

        public HashFactory(HashType type, IHeader<string> header)
          : this(type, header.Header()) { }

        public HashFactory(HashType type, string header)
        {
            _type = type;
            _header = header;
        }

        public IHash Create(string payload, string secret)
        {
            switch (_type)
            {
                case HashType.HS256:
                    return new HashHMACSHA256(_header, payload, secret);
                case HashType.None:
                default:
                    return new HashHMACSHA256(_header, payload, secret);
            }
        }
    }
}
