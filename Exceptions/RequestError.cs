namespace Hospital.Exceptions;
public class RequestError
: Exception
{
    public string? LoggerMessage { get; set; }
    public IList<string> ErrorList { get; set; } = [];
    public int StatusCode { get; set; }
    public bool HasErrors => ErrorList.Count > 0;

    public RequestError(
        string loggerMessage,
        List<string> errors,
        int statusCode = StatusCodes.Status400BadRequest)
    : base(loggerMessage)
    {
        LoggerMessage = loggerMessage;
        ErrorList = errors;
        StatusCode = statusCode;
    }

    public RequestError(
        string loggerMessage,
        string error,
        int statusCode = StatusCodes.Status400BadRequest)
    : base(loggerMessage)
    {
        LoggerMessage = loggerMessage;
        ErrorList.Add(error);
        StatusCode = statusCode;
    }

    public RequestError(
        string loggerMessage,
        int statusCode = StatusCodes.Status400BadRequest)
    : base(loggerMessage)
    {
        LoggerMessage = loggerMessage;
        StatusCode = statusCode;
        Add(loggerMessage);
    }

    public void Add(string error)
    {
        ErrorList.Add(error);
    }
}