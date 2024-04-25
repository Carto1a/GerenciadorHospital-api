using System.Net;

namespace Hospital.Exceptions;
public class InternalError
: RequestError
{
    public InternalError(
        string message,
        string? loggerMessage,
        HttpStatusCode statusCode =
            HttpStatusCode.InternalServerError)
    : base(message, loggerMessage, statusCode){ }
}