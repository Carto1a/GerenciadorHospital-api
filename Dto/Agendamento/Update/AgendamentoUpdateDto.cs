
using Hospital.Models.Agendamentos;

namespace Hospital.Dto.Agendamento.Update;
public class AgendamentoUpdateDto
{
    public DateTime DataHora { get; set; }
    public string MedicoId { get; set; }
    public string PacienteId { get; set; }
    public decimal Custo { get; set; }
    public AgendamentoStatus Status { get; set; }
    public bool Convenio { get; set; }
}
