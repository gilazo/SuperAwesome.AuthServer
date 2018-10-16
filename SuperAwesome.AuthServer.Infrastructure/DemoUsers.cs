using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SuperAwesome.AuthServer.Application;
using SuperAwesome.AuthServer.Application.Users;

namespace SuperAwesome.AuthServer.Infrastructure
{
    public sealed class DemoUsers : IGet<User>
    {
        private readonly List<User> _users;

        public DemoUsers()
            : this(new List<User> { new User("Jon", "Doe", "jon.doe@jd.com", "iloveauth", new[] { "" }) }) { }

        public DemoUsers(List<User> users)
        {
            _users = users;
        }

        public IEnumerable<User> Get(Expression<Func<User, bool>> predicate)
        {
            return _users.Where(predicate.Compile());
        }
    }
}
