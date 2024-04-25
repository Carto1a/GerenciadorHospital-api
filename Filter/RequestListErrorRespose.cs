using Hospital.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Filter;
public class RequestListErrorResponse
: IActionResult
{
    public IList<string> ErrorList { get; set; }
    public int StatusCode { get; set; }

    public RequestListErrorResponse(RequestListError error)
    {
        ErrorList = error.ErrorList;
        StatusCode = (int)error.StatusCode;
    }

    public Task ExecuteResultAsync(ActionContext context)
    {
        var ResposeData =
            new ObjectResult(ErrorList)
        {
            StatusCode = StatusCode,
        };

        return ResposeData.ExecuteResultAsync(context);
    }
}