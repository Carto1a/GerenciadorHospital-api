using Hospital.Domain.Exceptions;

using Microsoft.AspNetCore.Mvc.Filters;

namespace Hospital.Infrastructure.Filter;
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
        if (context.Exception is DomainException)
        {
            var error = (DomainException)context.Exception;

            context.Result = new RequestErrorResponse(
                error, StatusCodes.Status400BadRequest);

            if (error.LogMessage != null)
                _logger.LogError(error.LogMessage);
            return;
        }

        if (context.Exception is NotImplementedException)
        {
            context.Result = new RequestErrorResponse(
                new DomainException(
                    context.Exception.Message,
                    "Recurso não implementado"
                ),
                StatusCodes.Status501NotImplemented
            );
            return;
        }

        // TODO: mudar isso
        context.Result =
            new RequestErrorResponse(
                new DomainException(
                    context.Exception.Message,
                    "Error interno no servidor"
                ),
                StatusCodes.Status500InternalServerError
            );

        _logger.LogError(context.Exception.Message);
    }
}