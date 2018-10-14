namespace SuperAwesome.AuthServer.Application
{
    public interface IHeader<out T>
    {
         T Header();
    }
}
