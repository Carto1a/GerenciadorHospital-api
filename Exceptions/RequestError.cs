using System.Net;

namespace Hospital.Exceptions;
public class RequestError
: Exception
{
    public string? LoggerMessage { get; set; }
    public IList<string> ErrorList { get; set; } = [];
    public HttpStatusCode StatusCode { get; set; }
    public bool HasErrors => ErrorList.Count > 0;

    public RequestError(
        string errorMessage,
        string? loggerMessage = null,
        HttpStatusCode statusCode = HttpStatusCode.BadRequest)
    : base(errorMessage)
    {
        LoggerMessage = loggerMessage ?? errorMessage;
        if(loggerMessage != null)
            Add(errorMessage);

        StatusCode = statusCode;
    }

    public void Add(string error)
    {
        ErrorList.Add(error);
    }
}