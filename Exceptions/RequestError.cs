using System.Net;

namespace Hospital.Exceptions;
public class RequestError
: Exception
{
    public string? LoggerMessage { get; set; }
    public string ResponseMessage { get; set; }
    public HttpStatusCode StatusCode { get; set; }
    public RequestError(
        string message,
        string? loggerMessage,
        HttpStatusCode statusCode = HttpStatusCode.BadRequest)
    : base(message)
    {
        LoggerMessage = loggerMessage;
        StatusCode = statusCode;
        ResponseMessage = message;
    }
}