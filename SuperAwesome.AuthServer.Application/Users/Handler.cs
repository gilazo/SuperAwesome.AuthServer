using System.Linq;

namespace SuperAwesome.AuthServer.Application.Users
{
    public sealed class Handler
    {
        private readonly User _user;
        private readonly IGet<User> _users;
        private readonly IHeader<string> _header;
        private readonly string _secret;
        private readonly ISerialize<Claims> _serialzer;

        public Handler(User user, IGet<User> users, IHeader<string> header, Secret secret, ISerialize<Claims> serializer)
            : this(user, users, header, secret.Value, serializer) { }
        public Handler(User user, IGet<User> users, IHeader<string> header, string secret, ISerialize<Claims> serializer)
        {
            _user = user;
            _users = users;
            _header = header;
            _secret = secret;
            _serialzer = serializer;
        }

        public string Token()
        {
            var user = _users.Get(u => u.Email == _user.Email).First();
            if (user.Password != _user.Password)
                return string.Empty;
            
            var claims = new Claims(user.Name, "user", user.Name, user.Email, user.Scopes);
            return new HashHMACSHA256(_header.Header(), _serialzer.Serialize(claims), _secret).Hash();
        }
    }
}
