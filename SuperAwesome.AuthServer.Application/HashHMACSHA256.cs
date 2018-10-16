using System;
using System.Security.Cryptography;
using System.Text;

namespace SuperAwesome.AuthServer.Application
{
    public sealed class HashHMACSHA256 : IHash
    {
        private readonly string _header;
        private readonly string _payload;
        private readonly string _secret;
        private readonly Base64Url _base64Url;

        public HashHMACSHA256(string header, string payload, string secret)
          : this(header, payload, secret, new Base64Url()) { }

        public HashHMACSHA256(string header, string payload, string secret, Base64Url base64Url)
        {
            _header = header;
            _payload = payload;
            _secret = secret;
            _base64Url = base64Url;
        }

        public string Hash()
        {
            var header = _base64Url.Encode(Encoding.UTF8.GetBytes(_header));
            var payload = _base64Url.Encode(Encoding.UTF8.GetBytes(_payload));

            string signature;
            using (var car = new HMACSHA256(Encoding.UTF8.GetBytes(_secret)))
            {
                signature = _base64Url.Encode(car.ComputeHash(Encoding.UTF8.GetBytes($"{header}.{payload}")));
                return $"{header}.{payload}.{signature}";
            }
        }
    }
}
