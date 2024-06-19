namespace Hospital.Application.Dto.Input.Laudos;
public record LaudoGetByQueryDto : GetByQueryDto
{
    public Guid ExameId { get; set; }
    public Guid ConsultaId { get; set; }
    public Guid MedicoId { get; set; }
    public Guid PacienteId { get; set; }
}