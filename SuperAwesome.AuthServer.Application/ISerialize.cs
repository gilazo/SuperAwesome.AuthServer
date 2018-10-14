namespace SuperAwesome.AuthServer.Application
{
    public interface ISerialize<in T>
    {
        string Serialize(T item);
    }
}