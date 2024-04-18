using FluentResults;

using Hospital.Dto.Result;

namespace Hospital.Extensions;
public static class ResultDtoExtensions
{
    public static ResultDto<TResponse> ToResultDto<TResponse>(this Result<TResponse> result)
    {
        var errorMessages = result.Errors?.Select(error => error.Message);
        return new ResultDto<TResponse>(result.IsFailed, result.ValueOrDefault, errorMessages);
    }
    public static ResultDtoEmpty ToResultDto(this Result result)
    {
        var errorMessages = result.Errors?.Select(error => error.Message);
        return new ResultDtoEmpty(result.IsFailed, errorMessages);
    }
}