namespace Hospital.Application.Dto.Output.Agendamentos;
public record AgendamentoRetornoOutputDto : AgendamentoOutputDto
{
    public Guid ConsultaId { get; set; }
}