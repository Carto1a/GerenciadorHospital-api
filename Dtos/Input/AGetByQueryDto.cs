using System.Text.Json;

namespace Hospital.Dtos.Input;
public record AGetByQuery
{
    public DateTime? MinDateCriado { get; set; }
    public DateTime? MaxDateCriado { get; set; }
    public Guid? MedicoId { get; set; }
    public Guid? PacienteId { get; set; }
    public int? Limit { get; set; } = 1;
    public int? Page { get; set; } = 0;

    public string? Serialize()
    {
        return JsonSerializer.Serialize(this);
    }
}