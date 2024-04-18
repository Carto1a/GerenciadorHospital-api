
using Hospital.Models.Agendamentos;

namespace Hospital.Dto.Agendamento.Update;
public class AgendamentoUpdateDto
{
    public DateTime DataHora { get; set; }
    public Guid MedicoId { get; set; }
    public Guid PacienteId { get; set; }
    public decimal Custo { get; set; }
    public AgendamentoStatus Status { get; set; }
}