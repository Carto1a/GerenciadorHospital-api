using Hospital.Domain.Exceptions;

using Microsoft.AspNetCore.Mvc;

namespace Hospital.Infrastructure.Filter;
public class RequestErrorResponse
: IActionResult
{
    public IList<string> ErrorList { get; set; }
    public int StatusCode { get; set; }

    // TODO: refazer isso
    public RequestErrorResponse(
        DomainException error,
        int statusCode)
    {
        ErrorList = error.ErrorList;
        StatusCode = statusCode;
    }

    public Task ExecuteResultAsync(ActionContext context)
    {
        var response = new ResponseDataObject(
            null,
            ErrorList
        );
        var resposeData =
            new ObjectResult(response)
            {
                StatusCode = StatusCode,
            };

        return resposeData.ExecuteResultAsync(context);
    }
}