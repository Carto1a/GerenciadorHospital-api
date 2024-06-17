namespace Hospital.Dtos.Input.Agendamentos;
public record AgendamentoRetornoCreateDto : AgendamentoCreateDto
{
    public Guid ConsultaId { get; set; }
}