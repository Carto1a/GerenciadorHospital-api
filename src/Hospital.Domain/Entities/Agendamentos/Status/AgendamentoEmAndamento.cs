using Hospital.Domain.Entities.Atendimentos;
using Hospital.Domain.Enums;

namespace Hospital.Domain.Entities.Agendamentos.Status;
public class AgendamentoEmAndamento : AgendamentoStatus
{
    public override void Realizar(Agendamento agendamento, Atendimento atendimento)
    {
        atendimento.GetInfoAgendamento(agendamento);
        agendamento.Status = AgendamentoStatusEnum.Realizado;
    }

    public override void Ausente(Agendamento agendamento)
    {
        agendamento.State = new AgendamentoAusente();
        agendamento.Status = AgendamentoStatusEnum.Ausencia;
    }
}