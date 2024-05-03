namespace Hospital.Dtos.Input.Agendamentos;
public record RetornoAgendamentoCreateDto
: AgendamentoCreateDto
{
    public Guid ConsultaId { get; set; }
}