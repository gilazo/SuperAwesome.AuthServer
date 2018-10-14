using Newtonsoft.Json;
using SuperAwesome.AuthServer.Application;

namespace SuperAwesome.AuthServer.Infrastructure
{
    public sealed class JsonSerializer<T> : ISerialize<T>
    {
        public string Serialize(T item)
        {
            return JsonConvert.SerializeObject(item);
        }
    }
}
