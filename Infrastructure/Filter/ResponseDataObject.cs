namespace Hospital.Filter;
public class ResponseDataObject
{
    public object? Value { get; set; }
    public IList<string> Errors { get; set; }
    public bool IsFailed => Errors.Count > 0;

    public ResponseDataObject(
        object? value,
        IList<string>?errors = null)
    {
        Value = value;
        Errors = errors ?? new List<string>();
    }
}
