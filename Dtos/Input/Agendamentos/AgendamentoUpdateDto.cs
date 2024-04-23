using Hospital.Enums;

namespace Hospital.Dtos.Input.Agendamentos;
public record AgendamentoUpdateDto
{
    public Guid MedicoId { get; set; }
    public Guid PacienteId { get; set; }
    public Guid ConvenioId { get; set; }
    public decimal Custo { get; set; }
    public DateTime DataHora { get; set; }
    public AgendamentoStatus Status { get; set; }
}