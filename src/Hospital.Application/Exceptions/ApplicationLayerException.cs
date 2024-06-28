namespace Hospital.Application.Exceptions;
public class ApplicationLayerException : Exception
{
    public string LogMessage { get; set; }
    public ApplicationLayerException(string LogMessage, string message)
    : base(message)
    {
        this.LogMessage = LogMessage;
    }

    public ApplicationLayerException(string message)
    : base(message)
    {
        LogMessage = message;
    }
}