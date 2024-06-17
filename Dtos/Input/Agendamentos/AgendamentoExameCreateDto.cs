namespace Hospital.Dtos.Input.Agendamentos;
public record AgendamentoExameCreateDto : AgendamentoCreateDto
{
    public Guid ConsultaId { get; set; }
}