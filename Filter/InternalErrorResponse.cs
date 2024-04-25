using Hospital.Exceptions;

namespace Hospital.Filter;
public class InternalErrorResponse
: RequestErrorResponse
{
    public InternalErrorResponse(
        InternalError error)
    : base(error){ }
}