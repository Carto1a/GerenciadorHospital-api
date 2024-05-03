using Hospital.Dtos.Input.Agendamentos;
using Hospital.Models.Atendimento;

namespace Hospital.Models.Agendamentos;
public class ConsultaAgendamento
: Agendamento
{
    public virtual Consulta? Consulta { get; set; }

    public ConsultaAgendamento() { }
    public ConsultaAgendamento(AgendamentoCreateDto request)
    : base(request)
    { }
}