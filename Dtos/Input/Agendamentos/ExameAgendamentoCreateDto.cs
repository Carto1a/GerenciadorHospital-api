namespace Hospital.Dtos.Input.Agendamentos;
public record ExameAgendamentoCreateDto
: AgendamentoCreateDto
{
    public Guid ConsultaId { get; set; }
}