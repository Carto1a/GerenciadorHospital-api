namespace Hospital.Domain.Exceptions;
public class DomainInternalException
: Exception
{
    public string? LogMessage { get; set; }
    public DomainInternalException(string loggerMessage)
    : base(loggerMessage) { }

}