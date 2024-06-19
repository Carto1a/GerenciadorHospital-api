namespace Hospital.Application.Dto.Input.Agendamentos;
public record AgendamentoRetornoCreateDto : AgendamentoCreateDto
{
    public Guid ConsultaId { get; set; }
}