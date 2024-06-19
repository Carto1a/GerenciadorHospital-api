namespace Hospital.Application.Dto.Input.Agendamentos;
public record AgendamentoExameGetByQuery : AgendamentoGetByQueryDto
{
    public Guid? ConsultaId { get; set; }
}