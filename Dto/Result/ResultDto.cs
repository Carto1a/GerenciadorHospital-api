namespace Hospital.Dto.Result;
public class ResultDto<TResponse>
{
    public const string Type = "ResultDto";
    public bool IsFailed { get; set; }
    public TResponse? Response { get; set; }
    public IEnumerable<string>? Errors { get; set; }
    public ResultDto(bool isFailed, TResponse response, IEnumerable<string>? errors)
    {
        IsFailed = isFailed;
        Response = response;
        Errors = errors;
    }
}
