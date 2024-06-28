namespace Hospital.Infrastructure.Exceptions;
public class ServiceException : Exception
{
    public ServiceException(string message) : base(message) { }
}