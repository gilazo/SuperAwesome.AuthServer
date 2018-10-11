namespace SuperAwesomeAuthServer.Application
{
    public interface IHeader<out T>
    {
         T Get();
    }
}
