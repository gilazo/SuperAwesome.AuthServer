using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SuperAwesome.AuthServer.Application
{
    public interface IGet<T>
    {
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate);
    }
}