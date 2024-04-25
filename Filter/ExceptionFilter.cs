using Hospital.Exceptions;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Hospital.Filter;
public class ExceptionFilter
: IExceptionFilter
{
    private readonly ILogger<ExceptionFilter> _logger;
    public ExceptionFilter(ILogger<ExceptionFilter> logger)
    {
        _logger = logger;
    }

    public void OnException(ExceptionContext context)
    {
        if (context.Exception is RequestError)
        {
            RequestError error = (RequestError)context.Exception;

            context.Result = new RequestErrorResponse(error);

            if (error.LoggerMessage != null)
                _logger.LogError(error.LoggerMessage);
            return;
        }

        if (context.Exception is RequestListError)
        {
            RequestListError error =
                (RequestListError)context.Exception;

            context.Result = new RequestListErrorResponse(error);

            if (error.LoggerMessage != null)
                _logger.LogError(error.LoggerMessage);
            return;
        }

        // TODO: mudar isso
        context.Result =
            new BadRequestObjectResult("Erro interno no servidor");
        _logger.LogError(context.Exception.Message);
    }
}