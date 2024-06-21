namespace Hospital.Domain.Exceptions;
public class DomainException
: Exception
{
    public string? LogMessage { get; set; }
    public IDictionary<string, List<string>> Errors { get; set; } = new Dictionary<string, List<string>>();
    public List<string> ErrorList { get; set; } = new List<string>();
    public bool HasErrors => Errors.Count > 0;

    public DomainException(
        string loggerMessage,
        IDictionary<string, List<string>> errors)
    : base(loggerMessage)
    {
        LogMessage = loggerMessage;
        Errors = errors;
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