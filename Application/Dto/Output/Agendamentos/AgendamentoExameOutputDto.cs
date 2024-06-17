namespace Hospital.Application.Dto.Output.Agendamentos;
public record AgendamentoExameOutputDto : AgendamentoOutputDto
{
    public Guid ConsultaId { get; set; }
}