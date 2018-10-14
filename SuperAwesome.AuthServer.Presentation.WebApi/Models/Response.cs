namespace SuperAwesome.AuthServer.Presentation.WebApi.Models
{
    public sealed class Response : Response<object>
    {
        public Response()
            : base() { }

        public Response(params string[] errors)
            : base(errors) { }
    }

    public class Response<T>
    {
        public Response(T data)
            : this(data, string.Empty) { }

        public Response(T data, string message)
            : this(data, message, new string[] { }) { }

        public Response(params string[] errors)
            : this(default(T), string.Empty, errors) { }

        public Response(T data, string message, string[] errors)
        {
            Data = data;
            Message = message;
            Errors = errors;
        }

        public T Data { get; set; }
        public string Message { get; set; }
        public string[] Errors { get; set; }
    }
}
