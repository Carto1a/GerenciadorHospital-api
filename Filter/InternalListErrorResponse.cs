using Hospital.Exceptions;

namespace Hospital.Filter;
public class InternalListErrorResponse
: RequestListErrorResponse
{
    public InternalListErrorResponse(
        InternalListError error)
    : base(error){ }
}