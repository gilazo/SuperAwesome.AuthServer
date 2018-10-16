using System.Linq;
using System.Threading.Tasks;

namespace SuperAwesome.AuthServer.Application.Users
{
    public sealed class Handler
    {
        private readonly User _user;
        private readonly IGet<User> _users;
        private readonly string _secret;
        private readonly ISerialize<Claims> _serialzer;
        private readonly HashFactory _factory;

        public Handler(User user, IGet<User> users, Secret secret, ISerialize<Claims> serializer, HashFactory factory)
            : this(user, users, secret.Value, serializer, factory) { }

        public Handler(User user, IGet<User> users, string secret, ISerialize<Claims> serializer, HashFactory factory)
        {
            _user = user;
            _users = users;
            _secret = secret;
            _serialzer = serializer;
            _factory = factory;
        }

        public async Task<string> TokenAsync()
        {
            var user = _users.Get(u => u.Email == _user.Email).First();
            if (user?.Password != _user.Password)
                return string.Empty;

            var claims = new Claims(user.Name, "user", user.Name, user.Email, user.Scopes);
            return await Task.FromResult(_factory.Create(_serialzer.Serialize(claims), _secret).Hash());
        }
    }
}
