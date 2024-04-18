namespace Hospital.Dto;
public class AGetByQuery
{
    public DateTime? MinDate { get; set; }
    public DateTime? MaxDate { get; set; }
    public string? MedicoId { get; set; }
    public string? PacienteId { get; set; }
    public int? Limit { get; set; }
    public int? Page { get; set; }
}
