using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentResults;
using Hospital.Dto;

namespace Hospital.Extensions;
public static class ResultDtoExtensions
{
    public static ResultDto<TResponse> ToResultDto<TResponse>(this Result<TResponse> result)
    {
        var errorMessages = result.Errors?.Select(error => error.Message);
        return new ResultDto<TResponse>(result.IsSuccess, result.ValueOrDefault, errorMessages);
    }
}