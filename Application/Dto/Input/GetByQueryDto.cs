namespace Hospital.Application.Dto.Input;
public record GetByQueryDto
{
    public DateTime? MinDateCriado { get; set; }
    public DateTime? MaxDateCriado { get; set; }
    public bool? Ativo { get; set; } = true;
    public int? Limit { get; set; } = 10;
    public int? Page { get; set; } = 0;
}