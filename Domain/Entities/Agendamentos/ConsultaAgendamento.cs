using Hospital.Domain.Entities.Atendimentos;

namespace Hospital.Domain.Entities.Agendamentos;
public class ConsultaAgendamento : Agendamento
{
    public virtual Consulta? Consulta { get; set; }

    public ConsultaAgendamento() { }
}