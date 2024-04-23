namespace Hospital.Dtos.Input.Laudos;
public record LaudoCreateDto
{
    public Guid MedicoId { get; set; }
    public Guid PacienteId { get; set; }
    public Guid ExameId { get; set; }
    public Guid ConsultaId { get; set; }
    public string Descricao { get; set; }
}