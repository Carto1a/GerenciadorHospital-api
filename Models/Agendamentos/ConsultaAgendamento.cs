using Hospital.Models.Atendimento;

namespace Hospital.Models.Agendamentos;
public class ConsultaAgendamento
: Agendamento
{
    public virtual Consulta? Consulta { get; set; }

    public ConsultaAgendamento() { }
}