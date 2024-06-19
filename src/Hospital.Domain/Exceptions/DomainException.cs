namespace Hospital.Domain.Exceptions;
public class DomainException
: Exception
{
    public string? LogMessage { get; set; }
    public IList<string> ErrorList { get; set; } = [];
    public bool HasErrors => ErrorList.Count > 0;

    public DomainException(
        string loggerMessage,
        List<string> errors)
    : base(loggerMessage)
    {
        LogMessage = loggerMessage;
        ErrorList = errors;
    }

    public DomainException(
        string loggerMessage,
        string error)
    : base(loggerMessage)
    {
        LogMessage = loggerMessage;
        ErrorList.Add(error);
    }

    public DomainException(
        string loggerMessage)
    : base(loggerMessage)
    {
        LogMessage = loggerMessage;
        Add(loggerMessage);
    }

    public void Add(string error)
    {
        ErrorList.Add(error);
    }
}