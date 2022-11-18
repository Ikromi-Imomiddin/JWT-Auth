using System.Net;

namespace Domain.Wrapper;

public class Response<T>
{

    public T Data { get; set; }
    public int StatusCode { get; set; }
    public string Message { get; set; }

    public Response()
    {

    }

    public Response(T data)
    {
        Data = data;
        StatusCode = 200;
        Message = "Success";
    }

    public Response(HttpStatusCode statusCode, string message)
    {
        StatusCode = (int)statusCode;
        Message = message;
    }
}