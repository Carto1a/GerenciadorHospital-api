using System.Net;

namespace Hospital.Exceptions;
public class InternalListError
: RequestListError
{
    public InternalListError(
        string? loggerMessage,
        HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
    : base(loggerMessage, statusCode){ }
}