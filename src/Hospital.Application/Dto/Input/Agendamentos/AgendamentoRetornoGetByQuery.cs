namespace Hospital.Application.Dto.Input.Agendamentos;
public record AgendamentoRetornoGetByQuery : AgendamentoGetByQueryDto
{
    public Guid? ConsultaId { get; set; }
}