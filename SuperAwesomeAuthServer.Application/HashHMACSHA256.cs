using System.Security.Cryptography;
using System.Text;
using NeoSmart.Utils;

namespace SuperAwesomeAuthServer.Application
{
    public sealed class HashHMACSHA256 : IHash
    {   
        private readonly string _header;
        private readonly string _payload;
        private readonly string _secret;

        public HashHMACSHA256(string header, string payload, string secret)
        {
            _header = header;
            _payload = payload;
            _secret = secret;
        }

        public string Hash()
        {
            var header = UrlBase64.Encode(Encoding.UTF8.GetBytes(_header));
            var payload = UrlBase64.Encode(Encoding.UTF8.GetBytes(_payload));
            var data = $"{header}.{payload}";
                        
            string signature;
            using (var car = new HMACSHA256(Encoding.ASCII.GetBytes(_secret)))
            {
                signature = UrlBase64.Encode(car.ComputeHash(Encoding.ASCII.GetBytes(data)));
                return $"{header}.{payload}.{signature}";
            }             
        }
    }
}