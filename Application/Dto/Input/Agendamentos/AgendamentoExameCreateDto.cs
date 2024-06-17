namespace Hospital.Application.Dto.Input.Agendamentos;
public record AgendamentoExameCreateDto : AgendamentoCreateDto
{
    public Guid ConsultaId { get; set; }
}