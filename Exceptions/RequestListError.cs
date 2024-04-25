using System.Net;

namespace Hospital.Exceptions;
public class RequestListError
: Exception
{
    public string? LoggerMessage { get; set; }
    public IList<string> ErrorList { get; set; } = new List<string>();
    public HttpStatusCode StatusCode { get; set; }
    public bool HasErrors => ErrorList.Count > 0;
    public RequestListError(
        string? loggerMessage,
        HttpStatusCode statusCode = HttpStatusCode.BadRequest)
    : base(loggerMessage)
    {
        LoggerMessage = loggerMessage;
        StatusCode = statusCode;
    }

    public void Add(string error)
    {
        ErrorList.Add(error);
    }
}