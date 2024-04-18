namespace Hospital.Dto.Result;
public class ResultDto<TResponse>
{
    public const string Type = "ResultDto";
    public bool IsFailed { get; set; }
    public bool IsSuccess { get; set; }
    public TResponse? Response { get; set; }
    public IEnumerable<string>? Errors { get; set; }
    public ResultDto(bool isSuccess, bool isFailed, TResponse response, IEnumerable<string>? errors)
    {
        IsFailed = isFailed; 
        IsSuccess = isSuccess;
        Response = response;
        Errors = errors;
    }
}
