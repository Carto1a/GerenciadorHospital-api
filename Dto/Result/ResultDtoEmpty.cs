namespace Hospital.Dto.Result;
public class ResultDtoEmpty
{
    public const string Type = "ResultDto";
    public bool IsFailed { get; set; }
    public IEnumerable<string>? Errors { get; set; }
    public ResultDtoEmpty(bool isFailed, IEnumerable<string>? errors)
    {
        IsFailed = isFailed;
        Errors = errors;
    }
}
