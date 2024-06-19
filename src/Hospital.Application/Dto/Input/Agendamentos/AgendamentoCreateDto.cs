namespace Hospital.Application.Dto.Input.Agendamentos;
public record AgendamentoCreateDto
{
    public Guid MedicoId { get; set; }
    public Guid PacienteId { get; set; }
    public Guid? ConvenioId { get; set; }
    public DateTime DataHora { get; set; }
    public decimal Custo { get; set; }
}