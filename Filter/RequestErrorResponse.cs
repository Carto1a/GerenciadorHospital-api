using Hospital.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Filter;
public class RequestErrorResponse
: IActionResult
{
    public IList<string> ErrorList { get; set; }
    public int StatusCode { get; set; }

    public RequestErrorResponse(RequestError error)
    {
        ErrorList = error.ErrorList;
        StatusCode = (int)error.StatusCode;
    }

    public Task ExecuteResultAsync(ActionContext context)
    {
        var response = new ResponseDataObject(
            null,
            ErrorList
        );
        var ResposeData =
            new ObjectResult(response)
        {
            StatusCode = StatusCode,
        };

        return ResposeData.ExecuteResultAsync(context);
    }
}