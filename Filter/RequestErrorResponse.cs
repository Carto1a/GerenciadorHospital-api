using Hospital.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Filter;
public class RequestErrorResponse
: IActionResult
{
    public string Message { get; set; }
    public int StatusCode { get; set; }

    public RequestErrorResponse(RequestError error)
    {
        Message = error.Message;
        StatusCode = (int)error.StatusCode;
    }

    public Task ExecuteResultAsync(ActionContext context)
    {
        var ResposeData =
            new ObjectResult(Message)
        {
            StatusCode = StatusCode,
        };

        return ResposeData.ExecuteResultAsync(context);
    }
}