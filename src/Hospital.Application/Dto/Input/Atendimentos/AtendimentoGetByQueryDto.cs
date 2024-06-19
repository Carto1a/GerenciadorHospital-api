namespace Hospital.Application.Dto.Input.Atendimentos;
public record AtendimentoGetByQueryDto : GetByQueryDto
{
    public Guid? ConvenioId { get; set; }
    public Guid? PacienteId { get; set; }
    public Guid? MedicoId { get; set; }
}