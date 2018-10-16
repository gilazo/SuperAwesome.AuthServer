using System;

namespace SuperAwesome.AuthServer.Application
{
    public sealed class Base64Url
    {
        public string Encode(byte[] bytes)
        {
            return Convert.ToBase64String(bytes)
                          .Split('=')[0]
                          .Replace('+', '-')
                          .Replace('/', '_');
        }
    }
}
