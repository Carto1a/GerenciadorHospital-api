namespace Hospital.Application.Dto.Input.Laudos;
public record LaudoUpdateDto
{
    public Guid MedicoId { get; set; }
    public Guid PacienteId { get; set; }
    public Guid ExameId { get; set; }
    public Guid ConsultaId { get; set; }
    public string Descricao { get; set; }
}