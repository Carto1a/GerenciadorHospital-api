using System.Text.Json;

namespace Hospital.Dto;
public class AGetByQuery
{
    public DateTime? MinDate { get; set; }
    public DateTime? MaxDate { get; set; }
    public Guid? MedicoId { get; set; }
    public Guid? PacienteId { get; set; }
    public int? Limit { get; set; }
    public int? Page { get; set; }

    public string? Serialize()
    {
        return JsonSerializer.Serialize(this);
    }
}