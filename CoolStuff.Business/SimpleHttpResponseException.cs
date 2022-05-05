using System.Net;

namespace CoolStuff.Business;

public class SimpleHttpResponseException : Exception
{
    public HttpStatusCode StatusCode { get; }

    public SimpleHttpResponseException(HttpStatusCode statusCode, string content) : base(content)
    {
        StatusCode = statusCode;
    }
}